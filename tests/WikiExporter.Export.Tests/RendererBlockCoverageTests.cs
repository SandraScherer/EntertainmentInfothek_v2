using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.FileNames;
using WikiExporter.Export.Links;
using WikiExporter.Export.Markdown;
using WikiExporter.Export.Markdown.DokuWiki;
using WikiExporter.Export.Markdown.Obsidian;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Tests;

/// <summary>Tests rendering of individual Markdown block types and export-service boundaries.</summary>
public sealed class RendererBlockCoverageTests
{
    private static (ObsidianRenderer Obsidian, DokuWikiRenderer DokuWiki) CreateRenderers()
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var links = new ExportLinkResolver(paths);
        return (new ObsidianRenderer(paths, links), new DokuWikiRenderer(paths, links));
    }

    [Fact]
    public void ObsidianRenderer_RendersListsImagesCodeAndHorizontalRules()
    {
        var (renderer, _) = CreateRenderers();
        var document = new MarkdownDocument("Movie", "blocks-1", new Dictionary<string, string?>(), new MarkdownBlock[]
        {
            new ListBlock(new[] { "first", "second" }),
            new ListBlock(new[] { "alpha", "beta" }, Ordered: true),
            new ImageBlock("images/poster.png", "Poster"),
            new ImageBlock(" ", "No image"),
            new CodeBlock("line 1\nline 2", "text"),
            new HorizontalRuleBlock()
        });

        var rendered = renderer.Render(document).Content;

        Assert.Contains("- first", rendered);
        Assert.Contains("- second", rendered);
        Assert.Contains("1. alpha", rendered);
        Assert.Contains("2. beta", rendered);
        Assert.Contains("![Poster](images/poster.png)", rendered);
        Assert.DoesNotContain("No image", rendered);
        Assert.Contains("```text\nline 1\nline 2\n```", rendered);
        Assert.Contains("---", rendered);
    }

    [Fact]
    public void DokuWikiRenderer_RendersImagesCodeListsAndHorizontalRules()
    {
        var (_, renderer) = CreateRenderers();
        var document = new MarkdownDocument("Movie", "blocks-2", new Dictionary<string, string?>(), new MarkdownBlock[]
        {
            new ListBlock(new[] { "unordered" }),
            new ListBlock(new[] { "ordered" }, Ordered: true),
            new ImageBlock("images/poster.png", "Poster"),
            new CodeBlock("print(1)\nprint(2)", "python"),
            new HorizontalRuleBlock()
        });

        var rendered = renderer.Render(document).Content;

        Assert.Contains("  * unordered", rendered);
        Assert.Contains("  - ordered", rendered);
        Assert.Contains("{{images/poster.png|Poster}}", rendered);
        Assert.Contains("<code python>\nprint(1)\nprint(2)\n</code>", rendered);
        Assert.Contains("----", rendered);
    }

    [Theory]
    [InlineData(0, "# Heading")]
    [InlineData(1, "# Heading")]
    [InlineData(6, "###### Heading")]
    [InlineData(99, "###### Heading")]
    public void ObsidianRenderer_ClampsHeadingLevels(int level, string expected)
    {
        var (renderer, _) = CreateRenderers();
        var document = new MarkdownDocument("Movie", "heading", new Dictionary<string, string?>(), new MarkdownBlock[] { new HeadingBlock(level, "Heading") });

        Assert.Contains(expected, renderer.Render(document).Content);
    }

    [Theory]
    [InlineData(0, "====== Heading ======")]
    [InlineData(1, "====== Heading ======")]
    [InlineData(6, "= Heading =")]
    [InlineData(99, "= Heading =")]
    public void DokuWikiRenderer_ClampsHeadingLevels(int level, string expected)
    {
        var (_, renderer) = CreateRenderers();
        var document = new MarkdownDocument("Movie", "heading", new Dictionary<string, string?>(), new MarkdownBlock[] { new HeadingBlock(level, "Heading") });

        Assert.Contains(expected, renderer.Render(document).Content);
    }

    [Fact]
    public void BothRenderers_NormalizeNewlinesAndEscapeMultilineTableCells()
    {
        var (obsidian, dokuWiki) = CreateRenderers();
        var document = new MarkdownDocument("Movie", "table-newline", new Dictionary<string, string?>(), new MarkdownBlock[]
        {
            new ParagraphBlock("first\r\nsecond\rthird"),
            new TableBlock(new[] { "Field", "Value" }, new[] { (IReadOnlyList<string>)new[] { "Plot", "one|two\r\nthree" } })
        });

        var obsidianContent = obsidian.Render(document).Content;
        var dokuWikiContent = dokuWiki.Render(document).Content;

        Assert.Contains("first\nsecond\nthird", obsidianContent);
        Assert.Contains("one\\|two<br>three", obsidianContent);
        Assert.Contains("first\nsecond\nthird", dokuWikiContent);
        Assert.Contains("one\\|two<br>three", dokuWikiContent);
    }

    [Fact]
    public async Task MarkdownExportService_RendersThenWritesAndReturnsRenderedDocument()
    {
        var (obsidian, dokuWiki) = CreateRenderers();
        var writer = new RecordingWriter();
        var service = new MarkdownExportService(new MarkdownRendererResolver(dokuWiki, obsidian), writer);
        var document = new MarkdownDocument("Movie", "service-1", new Dictionary<string, string?>(), new MarkdownBlock[] { new ParagraphBlock("content") });

        var result = await service.ExportAsync(document, ExportFormat.Obsidian, "/exports");

        Assert.Same(result, writer.Document);
        Assert.Equal("/exports", writer.OutputDirectory);
        Assert.Contains("content", result.Content);
        Assert.StartsWith("Movies/Movie-", result.RelativePath);
        Assert.EndsWith(".md", result.RelativePath);
    }

    [Fact]
    public async Task MarkdownExportService_RejectsNullDocumentAndBlankOutputDirectory()
    {
        var (obsidian, dokuWiki) = CreateRenderers();
        var writer = new RecordingWriter();
        var service = new MarkdownExportService(new MarkdownRendererResolver(dokuWiki, obsidian), writer);

        await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExportAsync(null!, ExportFormat.Obsidian, "/exports"));
        await Assert.ThrowsAsync<ArgumentException>(() => service.ExportAsync(
            new MarkdownDocument("Movie", "service-2", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>()),
            ExportFormat.Obsidian,
            " "));
        Assert.Null(writer.Document);
    }

    [Fact]
    public async Task MarkdownExportService_PropagatesCancellationAndWriterFailures()
    {
        var (obsidian, dokuWiki) = CreateRenderers();
        var document = new MarkdownDocument("Movie", "service-3", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();
        var cancelledWriter = new RecordingWriter { ExceptionToThrow = new OperationCanceledException(cancellation.Token) };
        var cancelledService = new MarkdownExportService(new MarkdownRendererResolver(dokuWiki, obsidian), cancelledWriter);

        var exception = await Assert.ThrowsAnyAsync<OperationCanceledException>(() => cancelledService.ExportAsync(document, ExportFormat.Obsidian, "/exports", cancellation.Token));
        Assert.Equal(cancellation.Token, exception.CancellationToken);
        Assert.Equal(cancellation.Token, cancelledWriter.CancellationToken);

        var failureWriter = new RecordingWriter { ExceptionToThrow = new IOException("disk full") };
        var failureService = new MarkdownExportService(new MarkdownRendererResolver(dokuWiki, obsidian), failureWriter);
        var failure = await Assert.ThrowsAsync<IOException>(() => failureService.ExportAsync(document, ExportFormat.Obsidian, "/exports"));
        Assert.Equal("disk full", failure.Message);
    }

    private sealed class RecordingWriter : IExportFileWriter
    {
        public RenderedDocument? Document { get; private set; }
        public string? OutputDirectory { get; private set; }
        public CancellationToken CancellationToken { get; private set; }
        public Exception? ExceptionToThrow { get; init; }

        public Task WriteAsync(RenderedDocument document, string outputDirectory, CancellationToken ct = default)
        {
            Document = document;
            OutputDirectory = outputDirectory;
            CancellationToken = ct;
            if (ExceptionToThrow is not null) return Task.FromException(ExceptionToThrow);
            return Task.CompletedTask;
        }
    }
}
