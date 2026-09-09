using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Persistence;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export.Services;

/// <summary>Adapts the seven strongly typed persistence readers to one application-level resolver.</summary>
public sealed class ExportReaderResolver : IExportReaderResolver
{
    private readonly IReadOnlyDictionary<ExportEntityType,IExportReaderAdapter> _readers;
    public ExportReaderResolver(IMovieExportReader movie, ISeriesExportReader series, IEpisodeExportReader episode, IBookExportReader book, IVideoGameExportReader game, IPersonExportReader person, IConnectionExportReader connection)
    {
        _readers = new Dictionary<ExportEntityType,IExportReaderAdapter>
        {
            [ExportEntityType.Movie] = new MovieReaderAdapter(movie), [ExportEntityType.Series] = new SeriesReaderAdapter(series),
            [ExportEntityType.Episode] = new EpisodeReaderAdapter(episode), [ExportEntityType.Book] = new BookReaderAdapter(book),
            [ExportEntityType.VideoGame] = new VideoGameReaderAdapter(game), [ExportEntityType.Person] = new PersonReaderAdapter(person),
            [ExportEntityType.Connection] = new ConnectionReaderAdapter(connection)
        };
    }
    public IExportReaderAdapter Resolve(ExportEntityType type) => _readers.TryGetValue(type, out var reader) ? reader : throw new ArgumentOutOfRangeException(nameof(type), type, "No export reader registered.");

    private abstract class Adapter<T> : IExportReaderAdapter where T : ExportDataBase
    {
        private readonly Func<string,CancellationToken,Task<T?>> _get;
        private readonly Func<BatchOptions,CancellationToken,IAsyncEnumerable<T>> _all;
        protected Adapter(Func<string,CancellationToken,Task<T?>> get, Func<BatchOptions,CancellationToken,IAsyncEnumerable<T>> all) { _get=get; _all=all; }
        public async Task<ExportDataBase?> GetAsync(string id, CancellationToken ct) => await _get(id,ct);
        public async IAsyncEnumerable<ExportDataBase> ReadAllAsync(BatchOptions options, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct) { await foreach(var x in _all(options,ct)) yield return x; }
    }
    private sealed class MovieReaderAdapter(IMovieExportReader r) : Adapter<MovieExportData>(r.GetAsync,r.ReadAllAsync) { }
    private sealed class SeriesReaderAdapter(ISeriesExportReader r) : Adapter<SeriesExportData>(r.GetAsync,r.ReadAllAsync) { }
    private sealed class EpisodeReaderAdapter(IEpisodeExportReader r) : Adapter<EpisodeExportData>(r.GetAsync,r.ReadAllAsync) { }
    private sealed class BookReaderAdapter(IBookExportReader r) : Adapter<BookExportData>(r.GetAsync,r.ReadAllAsync) { }
    private sealed class VideoGameReaderAdapter(IVideoGameExportReader r) : Adapter<VideoGameExportData>(r.GetAsync,r.ReadAllAsync) { }
    private sealed class PersonReaderAdapter(IPersonExportReader r) : Adapter<PersonExportData>(r.GetAsync,r.ReadAllAsync) { }
    private sealed class ConnectionReaderAdapter(IConnectionExportReader r) : Adapter<ConnectionExportData>(r.GetAsync,r.ReadAllAsync) { }
}
