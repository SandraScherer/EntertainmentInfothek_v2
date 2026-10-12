using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Represents i episode export reader.</summary>
public interface IEpisodeExportReader { Task<EpisodeExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<EpisodeExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
