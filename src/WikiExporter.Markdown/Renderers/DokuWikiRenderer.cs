using System.Text;
using WikiExporter.Application.Documents;
using WikiExporter.Application.Interfaces;
using WikiExporter.Markdown.Rendering;

namespace WikiExporter.Markdown.Renderers;

/// <summary>
/// Rendert DokuWiki Markup.
/// </summary>
public sealed class DokuWikiRenderer
    : BaseMarkdownRenderer,
      IMarkdownRenderer
{
    public DokuWikiRenderer(
        DokuWikiBlockRenderer blockRenderer)
        : base(blockRenderer)
    {
    }

    protected override void RenderDocumentHeader(
        ExportDocument document,
        StringBuilder markdown)
    {
        markdown.AppendLine(
            $"====== {document.Title} ======");

        markdown.AppendLine();
    }

    protected override void RenderSection(
        ExportSection section,
        StringBuilder markdown)
    {
        markdown.AppendLine(
            $"===== {section.Title} =====");

        markdown.AppendLine();

        foreach (var block in section.Blocks)
        {
            markdown.AppendLine(
                BlockRenderer.Render(block));

            markdown.AppendLine();
        }
    }
}
