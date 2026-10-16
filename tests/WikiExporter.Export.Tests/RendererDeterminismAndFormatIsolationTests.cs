using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.FileNames;
using WikiExporter.Export.Links;
using WikiExporter.Export.Markdown.DokuWiki;
using WikiExporter.Export.Markdown.Obsidian;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Tests;

/// <summary>Checks renderer determinism and format-specific output boundaries.</summary>
public sealed class RendererDeterminismAndFormatIsolationTests
{
    private static (ObsidianRenderer Obsidian, DokuWikiRenderer DokuWiki) CreateRenderers()
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var links = new ExportLinkResolver(paths);
        return (new ObsidianRenderer(paths, links), new DokuWikiRenderer(paths, links));
    }

    [Theory]
    [InlineData(ExportFormat.Obsidian)]
    [InlineData(ExportFormat.DokuWiki)]
    public void Renderer_RenderingSameDocumentTwiceProducesIdenticalPathAndContent(ExportFormat format)
    {
        var (obsidian, dokuWiki) = CreateRenderers();
        var document = new MarkdownDocument("Movie", "stable-render-42",
            new Dictionary<string, string?> { ["title"] = "Stable title", ["year"] = "2026" },
            new MarkdownBlock[]
            {
                new HeadingBlock(1, "Stable title"),
                new ParagraphBlock("First line\r\nSecond line"),
                new ListBlock(new[] { "one", "two" })
            });
        var renderer = format == ExportFormat.Obsidian ? obsidian : dokuWiki;

        var first = renderer.Render(document);
        var second = renderer.Render(document);

        Assert.Equal(first.RelativePath, second.RelativePath);
        Assert.Equal(first.Content, second.Content);
        Assert.EndsWith("\n", first.Content.Replace("\r\n", "\n", StringComparison.Ordinal));
    }

    [Fact]
    public void DokuWikiRenderer_DoesNotEmitObsidianYamlFrontmatter()
    {
        var (_, renderer) = CreateRenderers();
        var document = new MarkdownDocument("Book", "metadata-is-format-specific",
            new Dictionary<string, string?> { ["title"] = "A Book", ["id"] = "book-42" },
            new MarkdownBlock[] { new HeadingBlock(1, "A Book") });

        var rendered = renderer.Render(document).Content;

        Assert.DoesNotContain("---", rendered);
        Assert.DoesNotContain("title:", rendered);
        Assert.Contains("A Book", rendered);
    }

    [Fact]
    public void ObsidianRenderer_EmitsMetadataWithoutChangingContentBlockOrder()
    {
        var (renderer, _) = CreateRenderers();
        var document = new MarkdownDocument("Book", "metadata-order",
            new Dictionary<string, string?> { ["zeta"] = "last", ["alpha"] = "first" },
            new MarkdownBlock[]
            {
                new ParagraphBlock("BLOCK-ONE"),
                new ParagraphBlock("BLOCK-TWO")
            });

        var rendered = renderer.Render(document).Content;

        Assert.True(rendered.IndexOf("alpha: first", StringComparison.Ordinal) < rendered.IndexOf("zeta: last", StringComparison.Ordinal));
        Assert.True(rendered.IndexOf("BLOCK-ONE", StringComparison.Ordinal) < rendered.IndexOf("BLOCK-TWO", StringComparison.Ordinal));
        Assert.True(rendered.IndexOf("---", StringComparison.Ordinal) < rendered.IndexOf("BLOCK-ONE", StringComparison.Ordinal));
    }

    [Fact]
    public void DokuWikiRenderer_EscapesPipesAndLineBreaksInTableHeadersAndRows()
    {
        var (_, renderer) = CreateRenderers();
        var document = new MarkdownDocument("Book", "table-cells",
            new Dictionary<string, string?>(),
            new MarkdownBlock[]
            {
                new TableBlock(new[] { "Name|Label", "Second\nHeader" },
                    new[] { (IReadOnlyList<string>)new[] { "left|right", "top\r\nbottom" } })
            });

        var rendered = renderer.Render(document).Content.Replace("\r\n", "\n", StringComparison.Ordinal);

        Assert.Contains("Name\\|Label", rendered);
        Assert.Contains("Second<br>Header", rendered);
        Assert.Contains("left\\|right", rendered);
        Assert.Contains("top<br>bottom", rendered);
    }
}
