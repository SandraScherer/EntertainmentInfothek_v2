using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.Markdown.DokuWiki;
using WikiExporter.Export.Markdown.Obsidian;

namespace WikiExporter.Export.Markdown;

/// <summary>Defines the markdown renderer resolver type.</summary>
public sealed class MarkdownRendererResolver(DokuWikiRenderer dokuWiki, ObsidianRenderer obsidian) : IMarkdownRendererResolver
{
/// <summary>Executes the resolve operation.</summary>
    public IMarkdownRenderer Resolve(ExportFormat format) => format switch
    {
        ExportFormat.DokuWiki => dokuWiki,
        ExportFormat.Obsidian => obsidian,
        _ => throw new ArgumentOutOfRangeException(nameof(format), format, "Unsupported export format.")
    };
}
