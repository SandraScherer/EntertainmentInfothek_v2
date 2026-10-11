using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Application.Documents.Builders;

/// <summary>Defines the document builder resolver type.</summary>
public sealed class DocumentBuilderResolver : IDocumentBuilderResolver
{
/// <summary>Stores the  builders value.</summary>
    private readonly IReadOnlyDictionary<ExportEntityType,IDocumentBuilder> _builders;
    public DocumentBuilderResolver(MovieDocumentBuilder movie, SeriesDocumentBuilder series, EpisodeDocumentBuilder episode, BookDocumentBuilder book, VideoGameDocumentBuilder game, PersonDocumentBuilder person, ConnectionDocumentBuilder connection) => _builders = new Dictionary<ExportEntityType,IDocumentBuilder>{{ExportEntityType.Movie,movie},{ExportEntityType.Series,series},{ExportEntityType.Episode,episode},{ExportEntityType.Book,book},{ExportEntityType.VideoGame,game},{ExportEntityType.Person,person},{ExportEntityType.Connection,connection}};
/// <summary>Executes the resolve operation.</summary>
    public IDocumentBuilder Resolve(ExportEntityType type)=>_builders.TryGetValue(type,out var b)?b:throw new ArgumentOutOfRangeException(nameof(type),type,"No document builder registered.");
}
