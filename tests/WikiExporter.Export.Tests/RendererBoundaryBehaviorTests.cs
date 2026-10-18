using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.FileNames;
using WikiExporter.Export.Links;
using WikiExporter.Export.Markdown;
using WikiExporter.Export.Markdown.DokuWiki;
using WikiExporter.Export.Markdown.Obsidian;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Tests;

/// <summary>Checks renderer behavior for boundary values in otherwise valid document blocks.</summary>
public sealed class RendererBoundaryBehaviorTests
{
    private static (ObsidianRenderer Obsidian, DokuWikiRenderer DokuWiki) CreateRenderers()
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var links = new ExportLinkResolver(paths);
        return (new ObsidianRenderer(paths, links), new DokuWikiRenderer(paths, links));
    }

    [Theory]
    [InlineData(0, "# Low heading")]
    [InlineData(99, "###### High heading")]
    public void ObsidianRenderer_ClampsHeadingLevelsToMarkdownRange(int level, string expected)
    {
        var (obsidian, _) = CreateRenderers();
        var document = CreateDocument("Movie", "heading-boundary", new MarkdownBlock[] { new HeadingBlock(level, level == 0 ? "Low heading" : "High heading") });

        var content = obsidian.Render(document).Content;

        Assert.Contains(expected, content);
    }

    [Theory]
    [InlineData(0, "====== Low heading ======")]
    [InlineData(99, "= High heading =")]
    public void DokuWikiRenderer_ClampsHeadingLevelsToSupportedRange(int level, string expected)
    {
        var (_, dokuWiki) = CreateRenderers();
        var document = CreateDocument("Movie", "dokuwiki-heading-boundary", new MarkdownBlock[] { new HeadingBlock(level, level == 0 ? "Low heading" : "High heading") });

        var content = dokuWiki.Render(document).Content;

        Assert.Contains(expected, content);
    }

    [Theory]
    [InlineData(ExportFormat.Obsidian)]
    [InlineData(ExportFormat.DokuWiki)]
    public void Renderer_OmitsImageBlockWhenFileNameIsNullOrWhitespace(ExportFormat format)
    {
        var (obsidian, dokuWiki) = CreateRenderers();
        IMarkdownRenderer renderer = format == ExportFormat.Obsidian ? obsidian : dokuWiki;
        var document = CreateDocument("Movie", "empty-image", new MarkdownBlock[]
        {
            new ImageBlock(null!, "description"),
            new ImageBlock("  ", "description")
        });

        var content = renderer.Render(document).Content;

        Assert.DoesNotContain("![", content);
        Assert.DoesNotContain("{{", content);
        Assert.DoesNotContain("description", content);
    }

    [Theory]
    [InlineData(ExportFormat.Obsidian)]
    [InlineData(ExportFormat.DokuWiki)]
    public void Renderer_PreservesCodeContentWhenLanguageIsNull(ExportFormat format)
    {
        var (obsidian, dokuWiki) = CreateRenderers();
        IMarkdownRenderer renderer = format == ExportFormat.Obsidian ? obsidian : dokuWiki;
        const string code = "line one\nline two";
        var document = CreateDocument("Book", "code-no-language", new MarkdownBlock[] { new CodeBlock(code, null) });

        var content = renderer.Render(document).Content;

        Assert.Contains(code, content);
        Assert.Contains("line one", content);
        Assert.Contains("line two", content);
    }

    private static MarkdownDocument CreateDocument(string type, string id, IReadOnlyList<MarkdownBlock> blocks) =>
        new(type, id, new Dictionary<string, string?>(), blocks);
}
