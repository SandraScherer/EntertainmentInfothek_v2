using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Defines the i export file writer type.</summary>
public interface IExportFileWriter
{
    Task WriteAsync(RenderedDocument document, string outputDirectory, CancellationToken ct = default);
}
