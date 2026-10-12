using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Represents i export use case.</summary>
public interface IExportUseCase
{
    Task<ExportResult> ExecuteAsync(ExportRequest request, CancellationToken ct = default);
}
