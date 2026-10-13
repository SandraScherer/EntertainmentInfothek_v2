using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.FileNames;
using WikiExporter.Export.FileSystem;
using WikiExporter.Export.Links;
using WikiExporter.Export.Markdown;
using WikiExporter.Export.Markdown.DokuWiki;
using WikiExporter.Export.Markdown.Obsidian;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Tests;

/// <summary>Exercises rendering, link resolution, path generation, and real file output together.</summary>
public sealed class EndToEndExportTests
{
    [Theory]
    [InlineData(ExportFormat.Obsidian, "[[../Persons/")]
    [InlineData(ExportFormat.DokuWiki, "[[Persons:")]
    public async Task ExportService_WritesDocumentAndResolvableCrossDocumentLink(ExportFormat format, string expectedLinkPrefix)
    {
        var root = Path.Combine(Path.GetTempPath(), "WikiExporterEndToEnd", Guid.NewGuid().ToString("N"));
        try
        {
            var (service, names) = CreateService();
            var person = new MarkdownDocument("Person", "person-42",
                new Dictionary<string, string?> { ["id"] = "person-42", ["title"] = "Ada Example" },
                new MarkdownBlock[] { new HeadingBlock(1, "Ada Example") });
            var movie = new MarkdownDocument("Movie", "movie-17",
                new Dictionary<string, string?> { ["id"] = "movie-17", ["title"] = "Example Film" },
                new MarkdownBlock[]
                {
                    new HeadingBlock(1, "Example Film"),
                    new ParagraphBlock("A movie linked to a person."),
                    new LinkBlock("Ada Example", "Person", "person-42")
                });

            var movieResult = await service.ExportAsync(movie, format, root);
            var personResult = await service.ExportAsync(person, format, root);
            var moviePath = Path.Combine(root, movieResult.RelativePath.Replace('/', Path.DirectorySeparatorChar));
            var personPath = Path.Combine(root, personResult.RelativePath.Replace('/', Path.DirectorySeparatorChar));

            Assert.StartsWith("Movies/", movieResult.RelativePath);
            Assert.StartsWith("Persons/", personResult.RelativePath);
            Assert.True(File.Exists(moviePath));
            Assert.True(File.Exists(personPath));
            Assert.Equal(movieResult.Content, await File.ReadAllTextAsync(moviePath));
            Assert.Equal(personResult.Content, await File.ReadAllTextAsync(personPath));

            var expectedPersonName = Path.GetFileNameWithoutExtension(names.Generate(person));
            Assert.Contains(expectedLinkPrefix + expectedPersonName, movieResult.Content);
            Assert.Contains("A movie linked to a person.", movieResult.Content);
            Assert.Contains("Ada Example", personResult.Content);
        }
        finally
        {
            if (Directory.Exists(root)) Directory.Delete(root, recursive: true);
        }
    }

    [Fact]
    public async Task ExportService_ReExportingSameEntityIdOverwritesItsFileWithoutCreatingDuplicate()
    {
        var root = Path.Combine(Path.GetTempPath(), "WikiExporterEndToEnd", Guid.NewGuid().ToString("N"));
        try
        {
            var (service, _) = CreateService();
            var first = new MarkdownDocument("Movie", "same-movie-id",
                new Dictionary<string, string?> { ["title"] = "First title" },
                new MarkdownBlock[] { new HeadingBlock(1, "First title") });
            var revised = new MarkdownDocument("Movie", "same-movie-id",
                new Dictionary<string, string?> { ["title"] = "Revised title" },
                new MarkdownBlock[] { new HeadingBlock(1, "Revised title") });

            var firstResult = await service.ExportAsync(first, ExportFormat.Obsidian, root);
            var revisedResult = await service.ExportAsync(revised, ExportFormat.Obsidian, root);
            var files = Directory.GetFiles(Path.Combine(root, "Movies"), "*.md", SearchOption.AllDirectories);

            Assert.Equal(firstResult.RelativePath, revisedResult.RelativePath);
            Assert.Single(files);
            var written = await File.ReadAllTextAsync(Path.Combine(root, revisedResult.RelativePath.Replace('/', Path.DirectorySeparatorChar)));
            Assert.Contains("Revised title", written);
            Assert.DoesNotContain("First title", written);
        }
        finally
        {
            if (Directory.Exists(root)) Directory.Delete(root, recursive: true);
        }
    }

    private static (MarkdownExportService Service, ExportFileNameGenerator Names) CreateService()
    {
        var names = new ExportFileNameGenerator();
        var paths = new ExportPathResolver(names);
        var links = new ExportLinkResolver(paths);
        var obsidian = new ObsidianRenderer(paths, links);
        var dokuWiki = new DokuWikiRenderer(paths, links);
        var resolver = new MarkdownRendererResolver(dokuWiki, obsidian);
        return (new MarkdownExportService(resolver, new FileSystemExportFileWriter()), names);
    }
}
