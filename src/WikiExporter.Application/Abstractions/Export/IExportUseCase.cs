using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Defines the i export use case type.</summary>
public interface IExportUseCase
{
    Task<ExportResult> ExecuteAsync(ExportRequest request, CancellationToken ct = default);
}
