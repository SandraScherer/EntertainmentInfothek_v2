using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Represents i series export reader.</summary>
public interface ISeriesExportReader { Task<SeriesExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<SeriesExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
