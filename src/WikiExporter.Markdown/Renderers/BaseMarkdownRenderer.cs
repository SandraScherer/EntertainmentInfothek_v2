using System.Text;
using WikiExporter.Application.Documents;

namespace WikiExporter.Markdown.Renderers;

/// <summary>
/// Gemeinsame Basis für Markdown Renderer.
/// </summary>
public abstract class BaseMarkdownRenderer
{
    protected readonly Rendering.IBlockRenderer BlockRenderer;

    protected BaseMarkdownRenderer(
        Rendering.IBlockRenderer blockRenderer)
    {
        BlockRenderer = blockRenderer;
    }

    public string Render(
        ExportDocument document)
    {
        var markdown = new StringBuilder();

        RenderDocumentHeader(
            document,
            markdown);

        foreach (var section
                in document.Sections
                    .OrderBy(x => x.Order))
        {
            RenderSection(
                section,
                markdown);
        }

        return markdown.ToString();
    }

    protected abstract void RenderDocumentHeader(
        ExportDocument document,
        StringBuilder markdown);

    protected abstract void RenderSection(
        ExportSection section,
        StringBuilder markdown);
}
