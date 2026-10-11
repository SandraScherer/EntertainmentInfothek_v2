using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Resolves links between exported documents. Renderers only ask for the final target string.</summary>
public interface IExportLinkResolver
{
    string Resolve(MarkdownDocument source, string targetType, string targetId, ExportFormat format);
}
