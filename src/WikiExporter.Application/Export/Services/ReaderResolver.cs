using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Persistence;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export.Services;

/// <summary>Adapts the seven strongly typed persistence readers to one application-level resolver.</summary>
public sealed class ExportReaderResolver : IExportReaderResolver
{
/// <summary>Stores readers for use by this component.</summary>
    private readonly IReadOnlyDictionary<ExportEntityType,IExportReaderAdapter> _readers;
/// <summary>Initializes this export reader resolver instance.</summary>
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
/// <summary>Performs the resolve operation.</summary>
    public IExportReaderAdapter Resolve(ExportEntityType type) => _readers.TryGetValue(type, out var reader) ? reader : throw new ArgumentOutOfRangeException(nameof(type), type, "No export reader registered.");


}
