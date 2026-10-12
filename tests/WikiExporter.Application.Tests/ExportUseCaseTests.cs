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
}
