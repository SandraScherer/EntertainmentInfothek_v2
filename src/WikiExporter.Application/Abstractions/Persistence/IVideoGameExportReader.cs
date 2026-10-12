using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Represents i video game export reader.</summary>
public interface IVideoGameExportReader { Task<VideoGameExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<VideoGameExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
