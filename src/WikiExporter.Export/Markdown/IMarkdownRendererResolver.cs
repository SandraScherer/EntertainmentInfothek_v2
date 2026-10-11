using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Defines the i markdown renderer resolver type.</summary>
public interface IMarkdownRendererResolver
{
    IMarkdownRenderer Resolve(ExportFormat format);
}
