using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Application.Documents.Builders;

public sealed class DocumentBuilderResolver : IDocumentBuilderResolver
{
    private readonly IReadOnlyDictionary<ExportEntityType,IDocumentBuilder> _builders;
    public DocumentBuilderResolver(MovieDocumentBuilder movie, SeriesDocumentBuilder series, EpisodeDocumentBuilder episode, BookDocumentBuilder book, VideoGameDocumentBuilder game, PersonDocumentBuilder person, ConnectionDocumentBuilder connection) => _builders = new Dictionary<ExportEntityType,IDocumentBuilder>{{ExportEntityType.Movie,movie},{ExportEntityType.Series,series},{ExportEntityType.Episode,episode},{ExportEntityType.Book,book},{ExportEntityType.VideoGame,game},{ExportEntityType.Person,person},{ExportEntityType.Connection,connection}};
    public IDocumentBuilder Resolve(ExportEntityType type)=>_builders.TryGetValue(type,out var b)?b:throw new ArgumentOutOfRangeException(nameof(type),type,"No document builder registered.");
}
