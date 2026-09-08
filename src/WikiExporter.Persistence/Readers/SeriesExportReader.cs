using Microsoft.EntityFrameworkCore;
using WikiExporter.Application.Persistence;
using WikiExporter.Domain.Export;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.Queries;

namespace WikiExporter.Persistence.Readers;

/// <summary>Concrete Series reader. All associations are loaded in bounded set-based batches.</summary>
internal sealed class SeriesExportReader : ExportReaderBase, ISeriesExportReader
{
    public SeriesExportReader(IDbContextFactory<EntertainmentInfothekDbContext> factory) : base(factory) { }

    public async Task<SeriesExportData?> GetAsync(string id, CancellationToken ct = default)
    {
        await using var db = await Factory.CreateDbContextAsync(ct);
        var entity = await db.Series.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, ct);
        if (entity is null) return null;
        return await LoadAndMapAsync(db, new[] { id }, ct).ContinueWith(t => t.Result.SingleOrDefault(), ct);
    }

    public async IAsyncEnumerable<SeriesExportData> ReadAllAsync(BatchOptions options, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    {
        await using var db = await Factory.CreateDbContextAsync(ct);
        string? after = null;
        while (true)
        {
            var ids = await db.Series.AsNoTracking().Where(x => after == null || string.Compare(x.Id, after) > 0).OrderBy(x => x.Id).Select(x => x.Id).Take(Size(options)).ToListAsync(ct);
            if (ids.Count == 0) yield break;
            foreach (var item in await LoadAndMapAsync(db, ids, ct)) yield return item;
            after = ids[^1];
        }
    }

    private static async Task<List<SeriesExportData>> LoadAndMapAsync(EntertainmentInfothekDbContext db, IReadOnlyCollection<string> ids, CancellationToken ct)
    {
        var loader = new ExportGraphLoader(db);
        var rootType = db.Model.FindEntityType(typeof(Series))!;
        var graph = await loader.LoadAsync(rootType, ids, RootGraphPlans.Series, ct);
        var result = new List<SeriesExportData>(ids.Count);
        foreach (var id in ids)
        {
            if (!graph.Entities.TryGetValue((rootType,id), out var obj)) continue;
            var t = rootType; var e = (Series)obj;
            var rows = ExportGraphMapper.Rows(graph, "Series", id);
            result.Add(new SeriesExportData(e.Id, ExportGraphMapper.Title(t,e), ExportGraphMapper.Get(t,e,"TypeId"), ExportGraphMapper.Get(t,e,"NoOfSeasons"), ExportGraphMapper.Get(t,e,"NoOfEpisodes"), ExportGraphMapper.Get(t,e,"ConnectionId"), ExportGraphMapper.Get(t,e,"Details"), Episodes(g), rows));
        }
        return result;
    }

    private static IReadOnlyList<EpisodeReference> Episodes(ExportGraph g) => g.Entities.Where(x => (x.Key.Type.GetTableName() ?? x.Key.Type.Name) == "Episode").Select(x => { var t=x.Key.Type; var e=x.Value; return new EpisodeReference(x.Key.Id, ExportGraphMapper.Title(t,e), ExportGraphMapper.Get(t,e,"SeasonNo"), ExportGraphMapper.Get(t,e,"EpisodeNo")); }).OrderBy(x=>x.SeasonNo,StringComparer.Ordinal).ThenBy(x=>x.EpisodeNo,StringComparer.Ordinal).ThenBy(x=>x.Id,StringComparer.Ordinal).ToArray();
}
