using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Application.Documents.Builders;

public sealed class DocumentBuilderResolver : IDocumentBuilderResolver
{
    private readonly IReadOnlyDictionary<ExportEntityType,IDocumentBuilder> _builders;
    public DocumentBuilderResolver(MovieDocumentBuilder movie, SeriesDocumentBuilder series, EpisodeDocumentBuilder episode, BookDocumentBuilder book, VideoGameDocumentBuilder game, PersonDocumentBuilder person, ConnectionDocumentBuilder connection) => _builders = new Dictionary<ExportEntityType,IDocumentBuilder>{{ExportEntityType.MovieEntity,movie},{ExportEntityType.SeriesEntity,series},{ExportEntityType.EpisodeEntity,episode},{ExportEntityType.BookEntity,book},{ExportEntityType.VideoGameEntity,game},{ExportEntityType.PersonEntity,person},{ExportEntityType.ConnectionEntity,connection}};
    public IDocumentBuilder Resolve(ExportEntityType type)=>_builders.TryGetValue(type,out var b)?b:throw new ArgumentOutOfRangeException(nameof(type),type,"No document builder registered.");
}
