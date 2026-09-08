using Microsoft.EntityFrameworkCore;
using WikiExporter.Application.Persistence;
using WikiExporter.Domain.Export;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.Queries;

namespace WikiExporter.Persistence.Readers;

/// <summary>Concrete Episode reader. All associations are loaded in bounded set-based batches.</summary>
internal sealed class EpisodeExportReader : ExportReaderBase, IEpisodeExportReader
{
    public EpisodeExportReader(IDbContextFactory<EntertainmentInfothekDbContext> factory) : base(factory) { }

    public async Task<EpisodeExportData?> GetAsync(string id, CancellationToken ct = default)
    {
        await using var db = await Factory.CreateDbContextAsync(ct);
        var entity = await db.Episode.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, ct);
        if (entity is null) return null;
        return await LoadAndMapAsync(db, new[] { id }, ct).ContinueWith(t => t.Result.SingleOrDefault(), ct);
    }

    public async IAsyncEnumerable<EpisodeExportData> ReadAllAsync(BatchOptions options, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    {
        await using var db = await Factory.CreateDbContextAsync(ct);
        string? after = null;
        while (true)
        {
            var ids = await db.Episode.AsNoTracking().Where(x => after == null || string.Compare(x.Id, after) > 0).OrderBy(x => x.Id).Select(x => x.Id).Take(Size(options)).ToListAsync(ct);
            if (ids.Count == 0) yield break;
            foreach (var item in await LoadAndMapAsync(db, ids, ct)) yield return item;
            after = ids[^1];
        }
    }

    private static async Task<List<EpisodeExportData>> LoadAndMapAsync(EntertainmentInfothekDbContext db, IReadOnlyCollection<string> ids, CancellationToken ct)
    {
        var loader = new ExportGraphLoader(db);
        var rootType = db.Model.FindEntityType(typeof(Episode))!;
        var graph = await loader.LoadAsync(rootType, ids, RootGraphPlans.Episode, ct);
        var result = new List<EpisodeExportData>(ids.Count);
        foreach (var id in ids)
        {
            if (!graph.Entities.TryGetValue((rootType,id), out var obj)) continue;
            var t = rootType; var e = (Episode)obj;
            var rows = ExportGraphMapper.Rows(graph, "Episode", id);
            result.Add(new EpisodeExportData(e.Id, ExportGraphMapper.Title(t,e), ExportGraphMapper.Get(t,e,"SeriesId"), ExportGraphMapper.Get(t,e,"SeasonNo"), ExportGraphMapper.Get(t,e,"EpisodeNo"), ExportGraphMapper.Get(t,e,"Details"), rows));
        }
        return result;
    }
}
