using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Defines the i book export reader type.</summary>
public interface IBookExportReader { Task<BookExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<BookExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
