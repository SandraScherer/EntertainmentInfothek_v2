using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Represents i book export reader.</summary>
public interface IBookExportReader { Task<BookExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<BookExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
