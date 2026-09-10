using FluentAssertions;

using Microsoft.Extensions.Logging.Abstractions;

using Moq;

using WikiExporter.Application.Builders;
using WikiExporter.Application.DTOs;
using WikiExporter.Application.Interfaces;
using WikiExporter.Application.Models;
using WikiExporter.Application.UseCases;

using WikiExporter.Infrastructure.FileSystem;

using WikiExporter.Markdown.Rendering;
using WikiExporter.Markdown.Renderers;

using Xunit;

public sealed class ExportMovieUseCaseIntegrationTest
{
    [Fact]
    public async Task Should_Create_File()
    {
        var repository =
            new Mock<IMovieRepository>();

        repository
            .Setup(x =>
                x.GetForExportAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                CreateMovie());

        var tempFolder =
            Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString());

        var writer =
            new FileWriter();

        var builder =
            new MovieExportDocumentBuilder();

        var renderer =
            new ObsidianRenderer(
                new ObsidianBlockRenderer());

        var useCase =
            new ExportMovieUseCase(
                repository.Object,
                builder,
                renderer,
                writer,
                NullLogger<
                    ExportMovieUseCase>.Instance);

        var result =
            await useCase.ExecuteAsync(
                new ExportRequest
                {
                    RecordId = "_xxx",
                    Language = "de",
                    Format =
                        ExportFormat.Obsidian,
                    OutputFolder =
                        tempFolder
                },
                CancellationToken.None);

        result.Success.Should().BeTrue();

        File.Exists(
            result.FilePath)
            .Should()
            .BeTrue();
    }

    private static MovieExportDto
        CreateMovie()
    {
        return new MovieExportDto
        {
            Id = "_xxx",

            OriginalTitle =
                "The Matrix",

            GermanTitle =
                "Matrix",

            Genres =
            {
                new MovieGenreDto
                {
                    Name = "Science Fiction"
                }
            }
        };
    }
}
