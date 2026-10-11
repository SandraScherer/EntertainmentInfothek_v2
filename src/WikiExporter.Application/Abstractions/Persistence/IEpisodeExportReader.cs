using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Defines the i episode export reader type.</summary>
public interface IEpisodeExportReader { Task<EpisodeExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<EpisodeExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
