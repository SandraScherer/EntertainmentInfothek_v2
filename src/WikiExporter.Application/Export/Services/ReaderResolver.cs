using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Persistence;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export.Services;

/// <summary>Adapts the seven strongly typed persistence readers to one application-level resolver.</summary>
public sealed class ExportReaderResolver : IExportReaderResolver
{
/// <summary>Stores the  readers value.</summary>
    private readonly IReadOnlyDictionary<ExportEntityType,IExportReaderAdapter> _readers;
/// <summary>Initializes a new instance of the export reader resolver type.</summary>
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
/// <summary>Executes the resolve operation.</summary>
    public IExportReaderAdapter Resolve(ExportEntityType type) => _readers.TryGetValue(type, out var reader) ? reader : throw new ArgumentOutOfRangeException(nameof(type), type, "No export reader registered.");

/// <summary>Defines the adapter type.</summary>
    private abstract class Adapter<T> : IExportReaderAdapter where T : ExportDataBase
    {
/// <summary>Stores the  get value.</summary>
        private readonly Func<string,CancellationToken,Task<T?>> _get;
/// <summary>Stores the  all value.</summary>
        private readonly Func<BatchOptions,CancellationToken,IAsyncEnumerable<T>> _all;
/// <summary>Initializes a new instance of the adapter type.</summary>
        protected Adapter(Func<string,CancellationToken,Task<T?>> get, Func<BatchOptions,CancellationToken,IAsyncEnumerable<T>> all) { _get=get; _all=all; }
/// <summary>Executes the get async operation.</summary>
        public async Task<ExportDataBase?> GetAsync(string id, CancellationToken ct) => await _get(id,ct);
/// <summary>Executes the read all async operation.</summary>
        public async IAsyncEnumerable<ExportDataBase> ReadAllAsync(BatchOptions options, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct) { await foreach(var x in _all(options,ct)) yield return x; }
    }
/// <summary>Defines the movie reader adapter type.</summary>
    private sealed class MovieReaderAdapter(IMovieExportReader r) : Adapter<MovieExportData>(r.GetAsync,r.ReadAllAsync) { }
/// <summary>Defines the series reader adapter type.</summary>
    private sealed class SeriesReaderAdapter(ISeriesExportReader r) : Adapter<SeriesExportData>(r.GetAsync,r.ReadAllAsync) { }
/// <summary>Defines the episode reader adapter type.</summary>
    private sealed class EpisodeReaderAdapter(IEpisodeExportReader r) : Adapter<EpisodeExportData>(r.GetAsync,r.ReadAllAsync) { }
/// <summary>Defines the book reader adapter type.</summary>
    private sealed class BookReaderAdapter(IBookExportReader r) : Adapter<BookExportData>(r.GetAsync,r.ReadAllAsync) { }
/// <summary>Defines the video game reader adapter type.</summary>
    private sealed class VideoGameReaderAdapter(IVideoGameExportReader r) : Adapter<VideoGameExportData>(r.GetAsync,r.ReadAllAsync) { }
/// <summary>Defines the person reader adapter type.</summary>
    private sealed class PersonReaderAdapter(IPersonExportReader r) : Adapter<PersonExportData>(r.GetAsync,r.ReadAllAsync) { }
/// <summary>Defines the connection reader adapter type.</summary>
    private sealed class ConnectionReaderAdapter(IConnectionExportReader r) : Adapter<ConnectionExportData>(r.GetAsync,r.ReadAllAsync) { }
}
