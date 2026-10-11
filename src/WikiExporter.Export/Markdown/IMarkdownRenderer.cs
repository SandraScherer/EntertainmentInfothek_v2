using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Serializes the neutral Markdown document tree into one concrete wiki dialect.</summary>
public interface IMarkdownRenderer
{
    ExportFormat Format { get; }
    RenderedDocument Render(MarkdownDocument document);
}
