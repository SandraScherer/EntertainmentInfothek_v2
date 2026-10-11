using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Defines the i video game export reader type.</summary>
public interface IVideoGameExportReader { Task<VideoGameExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<VideoGameExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
