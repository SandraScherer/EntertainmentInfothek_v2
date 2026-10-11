using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Creates a deterministic, file-system-safe base file name.</summary>
public interface IExportFileNameGenerator
{
    string Generate(MarkdownDocument document);
}
