using WikiExporter.Application.Documents;

namespace WikiExporter.Markdown.Rendering;

/// <summary>
/// Rendert einzelne ExportBlocks.
/// </summary>
public interface IBlockRenderer
{
    string Render(ExportBlock block);
}
