using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Represents i export reader adapter.</summary>
public interface IExportReaderAdapter
{
    Task<ExportDataBase?> GetAsync(string id, CancellationToken ct);
    IAsyncEnumerable<ExportDataBase> ReadAllAsync(Persistence.BatchOptions options, CancellationToken ct);
}
