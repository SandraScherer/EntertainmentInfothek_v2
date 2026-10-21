using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.FileNames;
using WikiExporter.Export.Links;
using WikiExporter.Export.Markdown;
using WikiExporter.Export.Markdown.DokuWiki;
using WikiExporter.Export.Markdown.Obsidian;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Tests;

/// <summary>Additional regression tests for renderer boundary conditions and format isolation.</summary>
public sealed class RendererAdditionalRegressionTests
{
    private static (ObsidianRenderer Obsidian, DokuWikiRenderer DokuWiki) CreateRenderers()
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var links = new ExportLinkResolver(paths);
        return (new ObsidianRenderer(paths, links), new DokuWikiRenderer(paths, links));
    }

    [Theory]
    [InlineData("first\r\nsecond", "first\nsecond")]
    [InlineData("first\rsecond", "first\nsecond")]
    [InlineData("first\nsecond", "first\nsecond")]
    public void BothRenderers_NormalizeAllTextLineEndingVariants(string input, string expected)
    {
        var (obsidian, dokuWiki) = CreateRenderers();
        var document = new MarkdownDocument("Movie", "line-ending-matrix", new Dictionary<string, string?>(), new MarkdownBlock[]
        {
            new ParagraphBlock(input)
        });

        foreach (var renderer in new IMarkdownRenderer[] { obsidian, dokuWiki })
        {
            var content = renderer.Render(document).Content;
            Assert.Contains(expected, content);
            Assert.DoesNotContain("\r", content);
            Assert.EndsWith("\n", content);
            Assert.False(content.EndsWith("\n\n", StringComparison.Ordinal));
        }
    }

    [Theory]
    [InlineData(ExportFormat.Obsidian)]
    [InlineData(ExportFormat.DokuWiki)]
    public void Renderer_EmptyMetadataAndBlocksStillProducesOnlyFrontmatterOrEmptyBody(ExportFormat format)
    {
        var (obsidian, dokuWiki) = CreateRenderers();
        var renderer = format == ExportFormat.Obsidian ? (IMarkdownRenderer)obsidian : dokuWiki;
        var document = new MarkdownDocument("Movie", "empty-boundary", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());

        var result = renderer.Render(document);

        Assert.EndsWith("\n", result.Content);
        Assert.DoesNotContain("\\n", result.Content);
        Assert.DoesNotContain("\r", result.Content);
        if (format == ExportFormat.Obsidian)
        {
            Assert.Equal("---\n---\n", result.Content);
        }
        else
        {
            Assert.Equal(string.Empty, result.Content.Trim());
        }
    }

    [Fact]
    public void ObsidianRenderer_SortsMetadataKeysWithoutReorderingBodyBlocks()
    {
        var (renderer, _) = CreateRenderers();
        var document = new MarkdownDocument("Movie", "metadata-order", new Dictionary<string, string?>
        {
            ["zeta"] = "last",
            ["alpha"] = "first",
            ["middle"] = "between"
        }, new MarkdownBlock[]
        {
            new ParagraphBlock("body-one"),
            new ParagraphBlock("body-two")
        });

        var content = renderer.Render(document).Content;

        Assert.True(content.IndexOf("alpha: first", StringComparison.Ordinal) < content.IndexOf("middle: between", StringComparison.Ordinal));
        Assert.True(content.IndexOf("middle: between", StringComparison.Ordinal) < content.IndexOf("zeta: last", StringComparison.Ordinal));
        Assert.True(content.IndexOf("body-one", StringComparison.Ordinal) < content.IndexOf("body-two", StringComparison.Ordinal));
    }

    [Theory]
    [InlineData("")]
    [InlineData("../unsafe:type")]
    [InlineData("🎬 Film")]
    public void FileNameGenerator_ProducesMdSuffixForUnusualEntityIds(string entityId)
    {
        var generator = new ExportFileNameGenerator();
        var document = new MarkdownDocument("Movie", entityId, new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());

        var fileName = generator.Generate(document);

        Assert.StartsWith("Movie-", fileName);
        Assert.EndsWith(".md", fileName);
        Assert.DoesNotContain('/', fileName);
        Assert.DoesNotContain('\\', fileName);
    }

    [Theory]
    [InlineData("Movie", "Movie")]
    [InlineData("Person", "Person")]
    [InlineData("UnknownType", "UnknownType")]
    public void LinkResolver_UsesStableTargetHashIndependentOfSourceId(string sourceType, string targetType)
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        var resolver = new ExportLinkResolver(paths);
        var sourceA = new MarkdownDocument(sourceType, "source-A", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());
        var sourceB = new MarkdownDocument(sourceType, "source-B", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());

        var linkA = resolver.Resolve(sourceA, targetType, "target-id", ExportFormat.Obsidian);
        var linkB = resolver.Resolve(sourceB, targetType, "target-id", ExportFormat.Obsidian);

        Assert.Equal(linkA, linkB);
    }
}
