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
    public async Task FileWriter_CreatesNestedDirectoriesAndAllowsEmptyContent()
    {
        var root = Path.Combine(Path.GetTempPath(), "WikiExporterTests", Guid.NewGuid().ToString("N"));
        try
        {
            var writer = new FileSystemExportFileWriter();
            await writer.WriteAsync(new("Connections/Universes/connection-1.md", string.Empty), root);

            var path = Path.Combine(root, "Connections", "Universes", "connection-1.md");
            Assert.True(File.Exists(path));
            Assert.Equal(string.Empty, await File.ReadAllTextAsync(path));
        }
        finally
        {
            if (Directory.Exists(root)) Directory.Delete(root, recursive: true);
        }
    }

    [Fact]
    public async Task FileWriter_RejectsAbsolutePathOutsideOutputDirectory()
    {
        var root = Path.Combine(Path.GetTempPath(), "WikiExporterTests", Guid.NewGuid().ToString("N"));
        var outside = Path.Combine(Path.GetTempPath(), $"wiki-exporter-outside-{Guid.NewGuid():N}.md");
        var writer = new FileSystemExportFileWriter();

        try
        {
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                writer.WriteAsync(new(outside, "must not be written"), root));
            Assert.False(File.Exists(outside));
        }
        finally
        {
            if (Directory.Exists(root)) Directory.Delete(root, recursive: true);
            if (File.Exists(outside)) File.Delete(outside);
        }
    }

    [Fact]
    public async Task FileWriter_RejectsBlankRelativePathBeforeCreatingOutput()
    {
        var root = Path.Combine(Path.GetTempPath(), "WikiExporterTests", Guid.NewGuid().ToString("N"));
        var writer = new FileSystemExportFileWriter();

        await Assert.ThrowsAsync<ArgumentException>(() => writer.WriteAsync(new(" ", "content"), root));
        Assert.False(Directory.Exists(root));
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

    [Fact]
    public void ObsidianRenderer_QuotesYamlValuesWithSpecialCharactersAndEscapesQuotes()
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var renderer = new ObsidianRenderer(paths, new ExportLinkResolver(paths));
        var document = new MarkdownDocument("Movie", "movie-yaml", new Dictionary<string, string?>
        {
            ["description"] = "A \"quoted\" title: #1",
            ["empty"] = string.Empty,
            ["missing"] = null,
            ["plain"] = "simple"
        }, Array.Empty<MarkdownBlock>());

        var rendered = renderer.Render(document);

        Assert.Contains("description: \"A \\\"quoted\\\" title: #1\"", rendered.Content);
        Assert.Contains("empty: \"\"", rendered.Content);
        Assert.Contains("missing: null", rendered.Content);
        Assert.Contains("plain: simple", rendered.Content);
    }


    [Fact]
    public void FileNameGenerator_UsesEntityIdRatherThanTitleAndSanitizesDocumentType()
    {
        var generator = new ExportFileNameGenerator();
        var first = new MarkdownDocument("Movie/Unsafe:Type", "same-id", new Dictionary<string, string?> { ["title"] = "First title" }, Array.Empty<MarkdownBlock>());
        var renamed = new MarkdownDocument("Movie/Unsafe:Type", "same-id", new Dictionary<string, string?> { ["title"] = "Different title" }, Array.Empty<MarkdownBlock>());
        var otherId = new MarkdownDocument("Movie/Unsafe:Type", "other-id", new Dictionary<string, string?> { ["title"] = "First title" }, Array.Empty<MarkdownBlock>());

        var firstName = generator.Generate(first);
        Assert.Equal(firstName, generator.Generate(renamed));
        Assert.NotEqual(firstName, generator.Generate(otherId));
        Assert.DoesNotContain("/", firstName);
        Assert.DoesNotContain(":", firstName);
        Assert.EndsWith(".md", firstName);
    }

    [Fact]
    public void PathResolver_UsesStableIdBasedPathsForDuplicateTitles()
    {
        var resolver = new ExportPathResolver(new ExportFileNameGenerator());
        var first = new MarkdownDocument("Movie", "movie-a", new Dictionary<string, string?> { ["title"] = "Same title" }, Array.Empty<MarkdownBlock>());
        var second = new MarkdownDocument("Movie", "movie-b", new Dictionary<string, string?> { ["title"] = "Same title" }, Array.Empty<MarkdownBlock>());

        Assert.NotEqual(
            resolver.GetRelativePath(first, ExportFormat.Obsidian),
            resolver.GetRelativePath(second, ExportFormat.Obsidian));
    }


    [Fact]
    public void ObsidianRenderer_QuotesYamlStringsThatCouldChangeTypeAndEscapesBackslashes()
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var renderer = new ObsidianRenderer(paths, new ExportLinkResolver(paths));
        var document = new MarkdownDocument("Movie", "movie-yaml-scalars", new Dictionary<string, string?>
        {
            ["boolean"] = "true",
            ["nullLiteral"] = "null",
            ["number"] = "123",
            ["quoted"] = "say \"hi\"",
            ["path"] = @"C:\temp",
            ["plain"] = "simple"
        }, Array.Empty<MarkdownBlock>());

        var rendered = renderer.Render(document).Content.Replace("\r\n", "\n", StringComparison.Ordinal);

        Assert.Contains("boolean: \"true\"", rendered);
        Assert.Contains("nullLiteral: \"null\"", rendered);
        Assert.Contains("number: \"123\"", rendered);
        Assert.Contains("quoted: \"say \\\"hi\\\"\"", rendered);
        Assert.Contains("path: \"C:\\\\temp\"", rendered);
        Assert.Contains("plain: simple", rendered);
    }

    [Fact]
    public void ObsidianRenderer_SortsMetadataKeysDeterministically()
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var renderer = new ObsidianRenderer(paths, new ExportLinkResolver(paths));
        var document = new MarkdownDocument("Movie", "movie-yaml-order", new Dictionary<string, string?>
        {
            ["zeta"] = "last",
            ["alpha"] = "first",
            ["middle"] = "between"
        }, Array.Empty<MarkdownBlock>());

        var rendered = renderer.Render(document).Content.Replace("\r\n", "\n", StringComparison.Ordinal);
        var alpha = rendered.IndexOf("alpha: first", StringComparison.Ordinal);
        var middle = rendered.IndexOf("middle: between", StringComparison.Ordinal);
        var zeta = rendered.IndexOf("zeta: last", StringComparison.Ordinal);

        Assert.True(alpha >= 0 && alpha < middle && middle < zeta, rendered);
    }

    [Theory]
    [InlineData(ExportFormat.Obsidian)]
    [InlineData(ExportFormat.DokuWiki)]
    public void Renderer_EmptyDocumentStillReturnsStablePathAndFinalNewline(ExportFormat format)
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var links = new ExportLinkResolver(paths);
        var renderer = new MarkdownRendererResolver(new DokuWikiRenderer(paths, links), new ObsidianRenderer(paths, links)).Resolve(format);
        var document = new MarkdownDocument("Movie", "empty-movie", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());

        var rendered = renderer.Render(document);

        Assert.StartsWith("Movies/", rendered.RelativePath);
        Assert.EndsWith(".md", rendered.RelativePath);
        Assert.EndsWith("\n", rendered.Content);
        Assert.DoesNotContain("empty-movie", rendered.Content);
    }

    [Fact]
    public void RendererResolver_RejectsUnknownFormat()
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var dokuWiki = new DokuWikiRenderer(paths, new ExportLinkResolver(paths));
        var obsidian = new ObsidianRenderer(paths, new ExportLinkResolver(paths));
        var resolver = new MarkdownRendererResolver(dokuWiki, obsidian);

        Assert.Throws<ArgumentOutOfRangeException>(() => resolver.Resolve((ExportFormat)999));
    }


    [Fact]
    public void ObsidianRenderer_EscapesControlCharactersInYamlMetadata()
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var renderer = new ObsidianRenderer(paths, new ExportLinkResolver(paths));
        var document = new MarkdownDocument("Movie", "movie-yaml-control", new Dictionary<string, string?>
        {
            ["lineBreaks"] = "first\nsecond\rthird",
            ["tab"] = "left\tright",
            ["backslashAndNewline"] = "path\\segment\nnext"
        }, Array.Empty<MarkdownBlock>());

        var content = renderer.Render(document).Content.Replace("\r\n", "\n", StringComparison.Ordinal);

        Assert.Contains("lineBreaks: \"first\\nsecond\\rthird\"", content);
        Assert.Contains("tab: \"left\\tright\"", content);
        Assert.Contains("backslashAndNewline: \"path\\\\segment\\nnext\"", content);
        Assert.DoesNotContain("first\nsecond", content);
    }

    [Fact]
    public void ObsidianRenderer_QuotesYamlReservedAndAmbiguousScalars()
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var renderer = new ObsidianRenderer(paths, new ExportLinkResolver(paths));
        var document = new MarkdownDocument("Movie", "movie-yaml-reserved", new Dictionary<string, string?>
        {
            ["booleanLike"] = "yes",
            ["nullLike"] = "~",
            ["leadingDash"] = "-leading",
            ["colon"] = "key: value",
            ["withSpaces"] = " leading and trailing "
        }, Array.Empty<MarkdownBlock>());

        var content = renderer.Render(document).Content.Replace("\r\n", "\n", StringComparison.Ordinal);

        Assert.Contains("booleanLike: \"yes\"", content);
        Assert.Contains("nullLike: \"~\"", content);
        Assert.Contains("leadingDash: \"-leading\"", content);
        Assert.Contains("colon: \"key: value\"", content);
        Assert.Contains("withSpaces: \" leading and trailing \"", content);
    }

}
