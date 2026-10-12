using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Represents i markdown renderer resolver.</summary>
public interface IMarkdownRendererResolver
{
    IMarkdownRenderer Resolve(ExportFormat format);
}
