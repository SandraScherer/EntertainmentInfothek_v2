using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Represents i connection export reader.</summary>
public interface IConnectionExportReader { Task<ConnectionExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<ConnectionExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
