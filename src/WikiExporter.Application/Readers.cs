using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

public sealed record BatchOptions(int Size = 250) { public int NormalizedSize => Math.Clamp(Size, 1, 10_000); }

public interface IMovieExportReader { Task<MovieExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<MovieExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
public interface ISeriesExportReader { Task<SeriesExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<SeriesExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
public interface IEpisodeExportReader { Task<EpisodeExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<EpisodeExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
public interface IBookExportReader { Task<BookExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<BookExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
public interface IVideoGameExportReader { Task<VideoGameExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<VideoGameExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
public interface IPersonExportReader { Task<PersonExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<PersonExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
public interface IConnectionExportReader { Task<ConnectionExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<ConnectionExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
