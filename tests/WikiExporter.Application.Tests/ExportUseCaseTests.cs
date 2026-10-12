using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Export.Services;
using WikiExporter.Domain;
using WikiExporter.Domain.Export;
using WikiExporter.Application.Persistence;

namespace WikiExporter.Application.Tests;

/// <summary>Represents export use case tests.</summary>
public sealed class ExportUseCaseTests
{
    [Fact]
    public async Task SingleExport_UsesReaderAndBuilder()
    {
        var reader = new Mock<IExportReaderAdapter>();
        var builder = new Mock<IDocumentBuilder>();
        var readers = new Mock<IExportReaderResolver>();
        var builders = new Mock<IDocumentBuilderResolver>();
        var data = new MovieExportData("m1", new("Original", "Movie", "Film"), null, null, null, null, null, null, Array.Empty<ExportRowData>());
        var document = new MarkdownDocument("Movie", "m1", new Dictionary<string,string?>(), Array.Empty<MarkdownBlock>());
        reader.Setup(x => x.GetAsync("m1", It.IsAny<CancellationToken>())).ReturnsAsync(data);
        builder.Setup(x => x.Build(data, ExportLanguage.English)).Returns(document);
        readers.Setup(x => x.Resolve(ExportEntityType.Movie)).Returns(reader.Object);
        builders.Setup(x => x.Resolve(ExportEntityType.Movie)).Returns(builder.Object);

        var sut = new ExportUseCase(readers.Object, builders.Object, new Mock<ILocalizedValueSelector>().Object, NullLogger<ExportUseCase>.Instance);
        var result = await sut.ExecuteAsync(new ExportRequest(ExportEntityType.Movie, new ExportScope.Single("m1"), ExportLanguage.English, ExportFormat.Obsidian, "out"));

        Assert.Equal(1, result.SuccessfullyBuilt);
        Assert.Single(result.Documents);
        builder.Verify(x => x.Build(data, ExportLanguage.English), Times.Once);
    }


    [Fact]
    public async Task SingleExport_WhenEntityDoesNotExist_ReturnsErrorWithoutBuildingDocument()
    {
        var reader = new Mock<IExportReaderAdapter>();
        var builder = new Mock<IDocumentBuilder>();
        var readers = new Mock<IExportReaderResolver>();
        var builders = new Mock<IDocumentBuilderResolver>();
        reader.Setup(x => x.GetAsync("missing", It.IsAny<CancellationToken>())).ReturnsAsync((ExportDataBase?)null);
        readers.Setup(x => x.Resolve(ExportEntityType.Movie)).Returns(reader.Object);
        builders.Setup(x => x.Resolve(ExportEntityType.Movie)).Returns(builder.Object);

        var sut = new ExportUseCase(readers.Object, builders.Object, new Mock<ILocalizedValueSelector>().Object, NullLogger<ExportUseCase>.Instance);
        var result = await sut.ExecuteAsync(new ExportRequest(ExportEntityType.Movie, new ExportScope.Single("missing"), ExportLanguage.English, ExportFormat.Obsidian, "out"));

        Assert.Equal(1, result.RequestedItems);
        Assert.Equal(0, result.SuccessfullyBuilt);
        Assert.Equal(1, result.FailedItems);
        Assert.Empty(result.Documents);
        Assert.Contains(result.Errors, error => error.EntityId == "missing");
        builder.Verify(x => x.Build(It.IsAny<ExportDataBase>(), It.IsAny<ExportLanguage>()), Times.Never);
    }

    [Fact]
    public async Task SingleExport_WhenBuilderThrows_RecordsFailureInsteadOfThrowing()
    {
        var reader = new Mock<IExportReaderAdapter>();
        var builder = new Mock<IDocumentBuilder>();
        var readers = new Mock<IExportReaderResolver>();
        var builders = new Mock<IDocumentBuilderResolver>();
        var data = new MovieExportData("m2", new("Original", "Movie", "Film"), null, null, null, null, null, null, Array.Empty<ExportRowData>());
        reader.Setup(x => x.GetAsync("m2", It.IsAny<CancellationToken>())).ReturnsAsync(data);
        builder.Setup(x => x.Build(data, ExportLanguage.English)).Throws(new InvalidOperationException("bad document"));
        readers.Setup(x => x.Resolve(ExportEntityType.Movie)).Returns(reader.Object);
        builders.Setup(x => x.Resolve(ExportEntityType.Movie)).Returns(builder.Object);

        var sut = new ExportUseCase(readers.Object, builders.Object, new Mock<ILocalizedValueSelector>().Object, NullLogger<ExportUseCase>.Instance);
        var result = await sut.ExecuteAsync(new ExportRequest(ExportEntityType.Movie, new ExportScope.Single("m2"), ExportLanguage.English, ExportFormat.Obsidian, "out"));

        Assert.Equal(1, result.RequestedItems);
        Assert.Equal(0, result.SuccessfullyBuilt);
        Assert.Equal(1, result.FailedItems);
        Assert.Empty(result.Documents);
        Assert.Contains(result.Errors, error => error.Message == "bad document");
    }

    [Fact]
    public async Task AllExport_ContinuesAfterOneBuilderFailureAndReportsCounts()
    {
        var reader = new Mock<IExportReaderAdapter>();
        var builder = new Mock<IDocumentBuilder>();
        var readers = new Mock<IExportReaderResolver>();
        var builders = new Mock<IDocumentBuilderResolver>();
        var first = new MovieExportData("m1", new("Original", "First", "Erster"), null, null, null, null, null, null, Array.Empty<ExportRowData>());
        var second = new MovieExportData("m2", new("Original", "Second", "Zweiter"), null, null, null, null, null, null, Array.Empty<ExportRowData>());
        var third = new MovieExportData("m3", new("Original", "Third", "Dritter"), null, null, null, null, null, null, Array.Empty<ExportRowData>());
        var firstDocument = new MarkdownDocument("Movie", "m1", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());
        var thirdDocument = new MarkdownDocument("Movie", "m3", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());

        reader.Setup(x => x.ReadAllAsync(It.IsAny<BatchOptions>(), It.IsAny<CancellationToken>()))
            .Returns((BatchOptions _, CancellationToken _) => Yield(first, second, third));
        builder.Setup(x => x.Build(first, ExportLanguage.English)).Returns(firstDocument);
        builder.Setup(x => x.Build(second, ExportLanguage.English)).Throws(new InvalidOperationException("broken second item"));
        builder.Setup(x => x.Build(third, ExportLanguage.English)).Returns(thirdDocument);
        readers.Setup(x => x.Resolve(ExportEntityType.Movie)).Returns(reader.Object);
        builders.Setup(x => x.Resolve(ExportEntityType.Movie)).Returns(builder.Object);

        var sut = new ExportUseCase(readers.Object, builders.Object, new Mock<ILocalizedValueSelector>().Object, NullLogger<ExportUseCase>.Instance);
        var result = await sut.ExecuteAsync(new ExportRequest(ExportEntityType.Movie, new ExportScope.All(2), ExportLanguage.English, ExportFormat.Obsidian, "out"));

        Assert.Equal(3, result.RequestedItems);
        Assert.Equal(2, result.SuccessfullyBuilt);
        Assert.Equal(1, result.FailedItems);
        Assert.Equal(new[] { "m1", "m3" }, result.Documents.Select(x => x.EntityId));
        Assert.Contains(result.Errors, error => error.EntityId == "m2" && error.Message == "broken second item");
        reader.Verify(x => x.ReadAllAsync(It.Is<BatchOptions>(options => options.Size == 2), It.IsAny<CancellationToken>()), Times.Once);
        builder.Verify(x => x.Build(third, ExportLanguage.English), Times.Once);
    }

    [Fact]
    public async Task AllExport_WithNoEntitiesReturnsZeroCountsAndNoDocuments()
    {
        var reader = new Mock<IExportReaderAdapter>();
        var readers = new Mock<IExportReaderResolver>();
        var builders = new Mock<IDocumentBuilderResolver>();
        reader.Setup(x => x.ReadAllAsync(It.IsAny<BatchOptions>(), It.IsAny<CancellationToken>()))
            .Returns((BatchOptions _, CancellationToken _) => Yield());
        readers.Setup(x => x.Resolve(ExportEntityType.Movie)).Returns(reader.Object);
        var sut = new ExportUseCase(readers.Object, builders.Object, new Mock<ILocalizedValueSelector>().Object, NullLogger<ExportUseCase>.Instance);

        var result = await sut.ExecuteAsync(new ExportRequest(ExportEntityType.Movie, new ExportScope.All(), ExportLanguage.English));

        Assert.Equal(0, result.RequestedItems);
        Assert.Equal(0, result.SuccessfullyBuilt);
        Assert.Equal(0, result.FailedItems);
        Assert.Empty(result.Documents);
        Assert.Empty(result.Errors);
        builders.Verify(x => x.Resolve(It.IsAny<ExportEntityType>()), Times.Once);
    }

    private static async IAsyncEnumerable<ExportDataBase> Yield(params ExportDataBase[] items)
    {
        foreach (var item in items)
        {
            await Task.Yield();
            yield return item;
        }
    }

}
