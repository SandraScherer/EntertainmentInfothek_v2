using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.FileNames;
using WikiExporter.Export.Links;
using WikiExporter.Export.Markdown;
using WikiExporter.Export.Markdown.DokuWiki;
using WikiExporter.Export.Markdown.Obsidian;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Tests;

public sealed class ExportLayerTests
{
    private static MarkdownDocument Document(string type = "Movie", string id = "42") => new(
        type, id,
        new Dictionary<string,string?> { ["type"] = type, ["id"] = id, ["title"] = "Test & Movie" },
        new MarkdownBlock[] {
            new HeadingBlock(1, "Test & Movie"),
            new ParagraphBlock("A | B"),
            new TableBlock(new[]{"A","B"}, new[]{(IReadOnlyList<string>)new[]{"1","2"}}),
            new LinkBlock("A person", "Person", "person-1")
        });

    [Fact]
    public void FileName_IsDeterministic_AndSafe()
    {
        var generator = new ExportFileNameGenerator();
        var a = generator.Generate(Document());
        var b = generator.Generate(Document());
        Assert.Equal(a, b);
        Assert.EndsWith(".md", a);
        Assert.DoesNotContain("&", a);
    }

    [Fact]
    public void LinkResolver_UsesRelativeObsidianPath()
    {
        IExportFileNameGenerator names = new ExportFileNameGenerator();
        IExportPathResolver paths = new ExportPathResolver(names);
        var resolver = new ExportLinkResolver(paths);
        var link = resolver.Resolve(Document("Movie"), "Person", "person-1", ExportFormat.Obsidian);
        Assert.StartsWith("../Persons/Person-", link);
        Assert.EndsWith("", link);
    }

    [Fact]
    public void ObsidianRenderer_EmitsFrontmatterAndTable()
    {
        IExportFileNameGenerator names = new ExportFileNameGenerator();
        IExportPathResolver paths = new ExportPathResolver(names);
        IExportLinkResolver links = new ExportLinkResolver(paths);
        var output = new ObsidianRenderer(paths, links).Render(Document());
        Assert.StartsWith("---", output.Content);
        Assert.Contains("type: Movie", output.Content);
        Assert.Contains("| A | B |", output.Content);
        Assert.Contains("[[../Persons/Person-", output.Content);
    }

    [Fact]
    public void DokuWikiRenderer_EmitsDokuWikiHeadingsAndLinks()
    {
        IExportFileNameGenerator names = new ExportFileNameGenerator();
        IExportPathResolver paths = new ExportPathResolver(names);
        IExportLinkResolver links = new ExportLinkResolver(paths);
        var output = new DokuWikiRenderer(paths, links).Render(Document());
        Assert.Contains("====== Test & Movie ======", output.Content);
        Assert.Contains("^ A ^ B ^", output.Content);
        Assert.Contains("[[", output.Content);
        Assert.DoesNotContain("---\n", output.Content);
    }
}
