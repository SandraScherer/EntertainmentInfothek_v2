using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.Markdown.DokuWiki;
using WikiExporter.Export.Markdown.Obsidian;

namespace WikiExporter.Export.Markdown;

public sealed class MarkdownRendererResolver(DokuWikiRenderer dokuWiki, ObsidianRenderer obsidian) : IMarkdownRendererResolver
{
    public IMarkdownRenderer Resolve(ExportFormat format) => format switch
    {
        ExportFormat.DokuWiki => dokuWiki,
        ExportFormat.Obsidian => obsidian,
        _ => throw new ArgumentOutOfRangeException(nameof(format), format, "Unsupported export format.")
    };
}
