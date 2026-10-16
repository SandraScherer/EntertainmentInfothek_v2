using WikiExporter.Application.Documents.Models;
using WikiExporter.Export.FileNames;
using WikiExporter.Export.Links;
using WikiExporter.Export.Markdown.Obsidian;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Tests;

/// <summary>Checks YAML scalar quoting for metadata values that can be misread by YAML parsers.</summary>
public sealed class ObsidianYamlScalarRegressionTests
{
    private static ObsidianRenderer CreateRenderer()
    {
        var paths = new ExportPathResolver(new ExportFileNameGenerator());
        return new ObsidianRenderer(paths, new ExportLinkResolver(paths));
    }

    [Theory]
    [InlineData(null, "null")]
    [InlineData("simple-123", "simple-123")]
    [InlineData("_private", "_private")]
    [InlineData("true", "\"true\"")]
    [InlineData("YES", "\"YES\"")]
    [InlineData("off", "\"off\"")]
    [InlineData("~", "\"~\"")]
    [InlineData("2026", "\"2026\"")]
    [InlineData("has spaces", "\"has spaces\"")]
    [InlineData("say \"hi\"", "\"say \\\"hi\\\"\"")]
    [InlineData("back\\slash", "\"back\\\\slash\"")]
    [InlineData("line\nbreak", "\"line\\nbreak\"")]
    public void ObsidianRenderer_QuotesYamlScalarsThatAreNotSafePlainStrings(string? value, string expectedScalar)
    {
        var renderer = CreateRenderer();
        var document = new MarkdownDocument("Movie", "yaml-scalar", new Dictionary<string, string?>
        {
            ["value"] = value
        }, Array.Empty<MarkdownBlock>());

        var rendered = renderer.Render(document).Content;

        Assert.Contains($"value: {expectedScalar}", rendered);
    }

    [Fact]
    public void ObsidianRenderer_UsesOneFinalNewlineForEmptyAndPopulatedDocuments()
    {
        var renderer = CreateRenderer();
        var empty = new MarkdownDocument("Movie", "yaml-empty", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());
        var populated = new MarkdownDocument("Movie", "yaml-populated", new Dictionary<string, string?>(), new MarkdownBlock[]
        {
            new HeadingBlock(1, "Title"),
            new ParagraphBlock("Body")
        });

        foreach (var document in new[] { empty, populated })
        {
            var content = renderer.Render(document).Content;
            Assert.EndsWith(Environment.NewLine, content);
            Assert.False(content.EndsWith(Environment.NewLine + Environment.NewLine, StringComparison.Ordinal));
        }
    }
}
