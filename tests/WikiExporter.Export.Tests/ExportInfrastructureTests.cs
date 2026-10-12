using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.FileNames;
using WikiExporter.Export.FileSystem;
using WikiExporter.Export.Links;
using WikiExporter.Export.Markdown.DokuWiki;
using WikiExporter.Export.Markdown.Obsidian;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Tests;

/// <summary>Represents export infrastructure tests.</summary>
public sealed class ExportInfrastructureTests
{
/// <summary>Performs the document operation.</summary>
    private static MarkdownDocument Document() => new("Movie", "movie-1",
        new Dictionary<string,string?> { ["id"]="movie-1", ["type"]="Movie", ["title"]="Test Movie" },
        new MarkdownBlock[]
        {
            new HeadingBlock(1,"Test Movie"),
            new ParagraphBlock("Hello"),
            new TableBlock(new[]{"Field","Value"}, new[]{(IReadOnlyList<string>)new[]{"Year","2026"}}),
/// <summary>Initializes this link block instance.</summary>
            new LinkBlock("A Person", "Person", "person-1")
        });

    [Fact]
    public void ObsidianRenderer_ProducesFrontmatterAndWikiLink()
    {
        var path = new ExportPathResolver(new ExportFileNameGenerator());
        var renderer = new ObsidianRenderer(path, new ExportLinkResolver(path));
        var result = renderer.Render(Document());

        Assert.StartsWith("---", result.Content);
        Assert.Contains("type: Movie", result.Content);
        Assert.Contains("[[../Persons/Person-", result.Content);
        Assert.StartsWith("Movies/Movie-", result.RelativePath);
    }

    [Fact]
    public void DokuWikiRenderer_UsesDokuWikiHeadingAndLinks()
    {
        var path = new ExportPathResolver(new ExportFileNameGenerator());
        var renderer = new DokuWikiRenderer(path, new ExportLinkResolver(path));
        var result = renderer.Render(Document());

        Assert.Contains("====== Test Movie ======", result.Content);
        Assert.Contains("[[Persons:Person-", result.Content);
        Assert.DoesNotContain("---\n", result.Content);
    }

    [Fact]
    public async Task FileWriter_WritesUtf8WithoutBom()
    {
        var root = Path.Combine(Path.GetTempPath(), "WikiExporterTests", Guid.NewGuid().ToString("N"));
        try
        {
            var writer = new FileSystemExportFileWriter();
            await writer.WriteAsync(new("Movies/Movie-test.md", "äöü\n"), root);
            var path = Path.Combine(root, "Movies", "Movie-test.md");
            Assert.True(File.Exists(path));
            Assert.Equal("äöü\n", await File.ReadAllTextAsync(path));
        }
        finally { if (Directory.Exists(root)) Directory.Delete(root, recursive: true); }
    }

    [Fact]
    public async Task FileWriter_RejectsPathTraversal()
    {
        var root = Path.Combine(Path.GetTempPath(), "WikiExporterTests", Guid.NewGuid().ToString("N"));
        var writer = new FileSystemExportFileWriter();
        await Assert.ThrowsAsync<InvalidOperationException>(() => writer.WriteAsync(new("../escape.md", "x"), root));
    }


    [Fact]
    public void FileNameGenerator_IsDeterministicAndDependsOnEntityId()
    {
        var generator = new ExportFileNameGenerator();
        var first = generator.Generate(Document());
        var second = generator.Generate(Document());
        var other = generator.Generate(new MarkdownDocument("Movie", "movie-2", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>()));

        Assert.Equal(first, second);
        Assert.NotEqual(first, other);
        Assert.EndsWith(".md", first);
    }

    [Theory]
    [InlineData("Movie", "Movies")]
    [InlineData("Series", "Series")]
    [InlineData("Episode", "Episodes")]
    [InlineData("Book", "Books")]
    [InlineData("VideoGame", "VideoGames")]
    [InlineData("Person", "Persons")]
    [InlineData("Connection", "Connections")]
    [InlineData("Unknown", "Other")]
    public void PathResolver_MapsDocumentTypesToExpectedFolders(string documentType, string expectedFolder)
    {
        var resolver = new ExportPathResolver(new ExportFileNameGenerator());
        var document = new MarkdownDocument(documentType, "id", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());
        Assert.Equal(expectedFolder, resolver.GetDirectory(document, ExportFormat.Obsidian));
    }

    [Fact]
    public void DokuWikiRenderer_EscapesPipesInTableCells()
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var renderer = new DokuWikiRenderer(paths, new ExportLinkResolver(paths));
        var document = new MarkdownDocument("Movie", "movie-3", new Dictionary<string, string?>(), new MarkdownBlock[]
        {
            new TableBlock(new[] { "Field", "Value" }, new[] { (IReadOnlyList<string>)new[] { "Genre", "Action|Adventure" } })
        });

        var rendered = renderer.Render(document);
        Assert.Contains("Action\\|Adventure", rendered.Content);
    }
}
