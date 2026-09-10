using WikiExporter.Application.Models;

namespace WikiExporter.Application.Interfaces;

/// <summary>
/// Erzeugt Renderer abhängig vom Exportformat.
/// </summary>
public interface IMarkdownRendererFactory
{
    IMarkdownRenderer Create(
        ExportFormat format);
}
