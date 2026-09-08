using Microsoft.EntityFrameworkCore;
using WikiExporter.Application.Persistence;
using WikiExporter.Domain.Export;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.Queries;

namespace WikiExporter.Persistence.Readers;

internal sealed class ConnectionExportReader : ExportReaderBase, IConnectionExportReader
{
    public ConnectionExportReader(IDbContextFactory<EntertainmentInfothekDbContext> factory) : base(factory) { }

    public async Task<ConnectionExportData?> GetAsync(string id, CancellationToken ct = default)
    {
        await using var db = await Factory.CreateDbContextAsync(ct);
        var ids = await db.Connection.AsNoTracking().Where(x=>x.Id==id).Select(x=>x.Id).ToListAsync(ct);
        return (await LoadAsync(db, ids, ct)).SingleOrDefault();
    }

    public async IAsyncEnumerable<ConnectionExportData> ReadAllAsync(BatchOptions options, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    {
        await using var db = await Factory.CreateDbContextAsync(ct); string? after=null;
        while(true) { var ids=await db.Connection.AsNoTracking().Where(x=>after==null||string.Compare(x.Id,after)>0).OrderBy(x=>x.Id).Select(x=>x.Id).Take(Size(options)).ToListAsync(ct); if(ids.Count==0)yield break; foreach(var x in await LoadAsync(db,ids,ct))yield return x; after=ids[^1]; }
    }

    private static async Task<List<ConnectionExportData>> LoadAsync(EntertainmentInfothekDbContext db, IReadOnlyCollection<string> ids, CancellationToken ct)
    {
        var loader=new ExportGraphLoader(db); var root=db.Model.FindEntityType(typeof(Connection))!; var graph=await loader.LoadAsync(root,ids,RootGraphPlans.Connection,ct);
        // Work references are deliberately queried in one set per work type. They remain references, never nested documents.
        var movies=await db.Movie.AsNoTracking().Where(x=>x.ConnectionId!=null && ids.Contains(x.ConnectionId!)).Select(x=>new WorkReference("Movie",x.Id,new LocalizedValue(x.OriginalTitle,x.EnglishTitle,x.GermanTitle))).ToListAsync(ct);
        var series=await db.Series.AsNoTracking().Where(x=>x.ConnectionId!=null && ids.Contains(x.ConnectionId!)).Select(x=>new WorkReference("Series",x.Id,new LocalizedValue(x.OriginalTitle,x.EnglishTitle,x.GermanTitle))).ToListAsync(ct);
        var books=await db.Book.AsNoTracking().Where(x=>x.ConnectionId!=null && ids.Contains(x.ConnectionId!)).Select(x=>new WorkReference("Book",x.Id,new LocalizedValue(x.OriginalTitle,x.EnglishTitle,x.GermanTitle))).ToListAsync(ct);
        var games=await db.VideoGame.AsNoTracking().Where(x=>x.ConnectionId!=null && ids.Contains(x.ConnectionId!)).Select(x=>new WorkReference("VideoGame",x.Id,new LocalizedValue(x.OriginalTitle,x.EnglishTitle,x.GermanTitle))).ToListAsync(ct);
        var children=await db.Connection.AsNoTracking().Where(x=>x.ConnectionId!=null && ids.Contains(x.ConnectionId!)).Select(x=>new {x.Id,x.OriginalName,x.EnglishName,x.GermanName,x.ConnectionId}).ToListAsync(ct);
        var result=new List<ConnectionExportData>();
        foreach(var id in ids){ if(!graph.Entities.TryGetValue((root,id),out var obj))continue; var t=root; var e=(Connection)obj; var child=children.Where(x=>x.ConnectionId==id).Select(x=>new EntityReference(x.Id,x.GermanName??x.EnglishName??x.OriginalName)).OrderBy(x=>x.DisplayName,StringComparer.Ordinal).ThenBy(x=>x.Id,StringComparer.Ordinal).ToArray(); var works=movies.Concat(series).Concat(books).Concat(games).OrderBy(x=>x.Type,StringComparer.Ordinal).ThenBy(x=>x.Title.Original,StringComparer.Ordinal).ThenBy(x=>x.Id,StringComparer.Ordinal).ToArray(); var rows=ExportGraphMapper.Rows(graph,"Connection",id); result.Add(new ConnectionExportData(id,ExportGraphMapper.Name(t,e),e.ConnectionId,e.Details,child,works,rows)); }
        return result;
    }
}
