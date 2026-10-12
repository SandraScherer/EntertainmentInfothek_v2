using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Application.Documents.Builders;

/// <summary>Represents document builder resolver.</summary>
public sealed class DocumentBuilderResolver : IDocumentBuilderResolver
{
/// <summary>Stores builders for use by this component.</summary>
    private readonly IReadOnlyDictionary<ExportEntityType,IDocumentBuilder> _builders;
    /// <summary>Registers one document builder for each supported export entity type.</summary>
    /// <param name="movie">Builds movie documents.</param>
    /// <param name="series">Builds series documents.</param>
    /// <param name="episode">Builds episode documents.</param>
    /// <param name="book">Builds book documents.</param>
    /// <param name="game">Builds video-game documents.</param>
    /// <param name="person">Builds person documents.</param>
    /// <param name="connection">Builds connection/universe documents.</param>
    public DocumentBuilderResolver(MovieDocumentBuilder movie, SeriesDocumentBuilder series, EpisodeDocumentBuilder episode, BookDocumentBuilder book, VideoGameDocumentBuilder game, PersonDocumentBuilder person, ConnectionDocumentBuilder connection) => _builders = new Dictionary<ExportEntityType,IDocumentBuilder>{{ExportEntityType.Movie,movie},{ExportEntityType.Series,series},{ExportEntityType.Episode,episode},{ExportEntityType.Book,book},{ExportEntityType.VideoGame,game},{ExportEntityType.Person,person},{ExportEntityType.Connection,connection}};
/// <summary>Performs the resolve operation.</summary>
    public IDocumentBuilder Resolve(ExportEntityType type)=>_builders.TryGetValue(type,out var b)?b:throw new ArgumentOutOfRangeException(nameof(type),type,"No document builder registered.");
}
