using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Defines the i series export reader type.</summary>
public interface ISeriesExportReader { Task<SeriesExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<SeriesExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
