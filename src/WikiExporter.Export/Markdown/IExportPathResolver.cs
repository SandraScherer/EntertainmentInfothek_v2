using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Resolves stable export paths independently of the Markdown syntax.</summary>
public interface IExportPathResolver
{
    string GetRelativePath(MarkdownDocument document, ExportFormat format);
    string GetDirectory(MarkdownDocument document, ExportFormat format);
}
