using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Defines the i movie export reader type.</summary>
public interface IMovieExportReader { Task<MovieExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<MovieExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
