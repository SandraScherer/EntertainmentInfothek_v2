using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Persistence;

/// <summary>Bounded batch size used by all export readers.</summary>
public sealed record BatchOptions(int Size = 250)
{
/// <summary>Stores the normalized size value.</summary>
    public int NormalizedSize => Math.Clamp(Size, 1, 10_000);
}

/// <summary>Defines the i movie export reader type.</summary>
public interface IMovieExportReader { Task<MovieExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<MovieExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
/// <summary>Defines the i series export reader type.</summary>
public interface ISeriesExportReader { Task<SeriesExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<SeriesExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
/// <summary>Defines the i episode export reader type.</summary>
public interface IEpisodeExportReader { Task<EpisodeExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<EpisodeExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
/// <summary>Defines the i book export reader type.</summary>
public interface IBookExportReader { Task<BookExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<BookExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
/// <summary>Defines the i video game export reader type.</summary>
public interface IVideoGameExportReader { Task<VideoGameExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<VideoGameExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
/// <summary>Defines the i person export reader type.</summary>
public interface IPersonExportReader { Task<PersonExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<PersonExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
/// <summary>Defines the i connection export reader type.</summary>
public interface IConnectionExportReader { Task<ConnectionExportData?> GetAsync(string id, CancellationToken ct = default); IAsyncEnumerable<ConnectionExportData> ReadAllAsync(BatchOptions options, CancellationToken ct = default); }
