using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Represents i export file writer.</summary>
public interface IExportFileWriter
{
    Task WriteAsync(RenderedDocument document, string outputDirectory, CancellationToken ct = default);
}
