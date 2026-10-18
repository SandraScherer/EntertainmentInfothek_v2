using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.FileNames;
using WikiExporter.Export.Links;
using WikiExporter.Export.Markdown;
using WikiExporter.Export.Markdown.DokuWiki;
using WikiExporter.Export.Markdown.Obsidian;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Tests;

/// <summary>Regression coverage for newline normalization and table-cell serialization.</summary>
public sealed class RendererTextAndTableRegressionTests
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
    public void Renderer_NormalizesCrLfAndCrAcrossTextualBlocks(ExportFormat format)
    {
        var (obsidian, dokuWiki) = CreateRenderers();
        IMarkdownRenderer renderer = format == ExportFormat.Obsidian ? obsidian : dokuWiki;
        var document = new MarkdownDocument("Movie", "newline-normalization", new Dictionary<string, string?>(), new MarkdownBlock[]
        {
            new HeadingBlock(1, "Heading\r\ncontinued\rthird"),
            new ParagraphBlock("Paragraph\r\ncontinued\rthird"),
            new ListBlock(new[] { "List\r\ncontinued\rthird" }),
            new LinkBlock("Link\r\ncontinued", "Person", "person-1"),
            new CodeBlock("Code\r\ncontinued\rthird", "text")
        });

        var content = renderer.Render(document).Content;

        Assert.DoesNotContain("\r", content);
        Assert.Contains("Heading\ncontinued\nthird", content);
        Assert.Contains("Paragraph\ncontinued\nthird", content);
        Assert.Contains("List\ncontinued\nthird", content);
        Assert.Contains("Link\ncontinued", content);
        Assert.Contains("Code\ncontinued\nthird", content);
    }

    [Theory]
    [InlineData(ExportFormat.Obsidian)]
    [InlineData(ExportFormat.DokuWiki)]
    public void Renderer_EscapesPipesAndConvertsEmbeddedLineBreaksInTableCells(ExportFormat format)
    {
        var (obsidian, dokuWiki) = CreateRenderers();
        IMarkdownRenderer renderer = format == ExportFormat.Obsidian ? obsidian : dokuWiki;
        var document = new MarkdownDocument("Book", "table-escaping", new Dictionary<string, string?>(), new MarkdownBlock[]
        {
            new TableBlock(
                new[] { "Title|Name", "Line\r\nBreak" },
                new[] { (IReadOnlyList<string>)new[] { "A|B", "Top\nBottom" } })
        });

        var content = renderer.Render(document).Content.Replace("\r\n", "\n", StringComparison.Ordinal);

        Assert.Contains("Title\\|Name", content);
        Assert.Contains("Line<br>Break", content);
        Assert.Contains("A\\|B", content);
        Assert.Contains("Top<br>Bottom", content);
    }

    [Theory]
    [InlineData(ExportFormat.Obsidian)]
    [InlineData(ExportFormat.DokuWiki)]
    public void Renderer_KeepsTableRowsInInputOrder(ExportFormat format)
    {
        var (obsidian, dokuWiki) = CreateRenderers();
        IMarkdownRenderer renderer = format == ExportFormat.Obsidian ? obsidian : dokuWiki;
        var document = new MarkdownDocument("Book", "table-order", new Dictionary<string, string?>(), new MarkdownBlock[]
        {
            new TableBlock(new[] { "Name" }, new IReadOnlyList<string>[]
            {
                new[] { "ROW-FIRST" },
                new[] { "ROW-SECOND" },
                new[] { "ROW-THIRD" }
            })
        });

        var content = renderer.Render(document).Content;

        Assert.True(content.IndexOf("ROW-FIRST", StringComparison.Ordinal) < content.IndexOf("ROW-SECOND", StringComparison.Ordinal));
        Assert.True(content.IndexOf("ROW-SECOND", StringComparison.Ordinal) < content.IndexOf("ROW-THIRD", StringComparison.Ordinal));
    }
}
