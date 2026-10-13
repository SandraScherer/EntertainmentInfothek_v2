using Microsoft.EntityFrameworkCore;
using WikiExporter.Application.Persistence;
using WikiExporter.Domain.Export;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.Queries;

namespace WikiExporter.Persistence.Readers;

/// <summary>Concrete Series reader. All associations are loaded in bounded set-based batches.</summary>
internal sealed class SeriesExportReader : ExportReaderBase, ISeriesExportReader
{
/// <summary>Initializes this series export reader instance.</summary>
    public SeriesExportReader(IDbContextFactory<EntertainmentInfothekDbContext> factory) : base(factory) { }

/// <summary>Performs the get async operation.</summary>
    public async Task<SeriesExportData?> GetAsync(string id, CancellationToken ct = default)
    {
        await using var db = await Factory.CreateDbContextAsync(ct);
        var entity = await db.SeriesEntity.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, ct);
        if (entity is null) return null;
        return await LoadAndMapAsync(db, new[] { id }, ct).ContinueWith(t => t.Result.SingleOrDefault(), ct);
    }

/// <summary>Performs the read all async operation.</summary>
    public async IAsyncEnumerable<SeriesExportData> ReadAllAsync(BatchOptions options, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    {
        await using var db = await Factory.CreateDbContextAsync(ct);
        string? after = null;
        while (true)
        {
            var ids = await db.SeriesEntity.AsNoTracking().Where(x => after == null || string.Compare(x.Id, after) > 0).OrderBy(x => x.Id).Select(x => x.Id).Take(Size(options)).ToListAsync(ct);
            if (ids.Count == 0) yield break;
            foreach (var item in await LoadAndMapAsync(db, ids, ct)) yield return item;
            after = ids[^1];
        }
    }

/// <summary>Performs the load and map async operation.</summary>
    private static async Task<List<SeriesExportData>> LoadAndMapAsync(EntertainmentInfothekDbContext db, IReadOnlyCollection<string> ids, CancellationToken ct)
    {
        var loader = new ExportGraphLoader(db);
        var rootType = db.Model.FindEntityType(typeof(SeriesEntity))!;
        var graph = await loader.LoadAsync(rootType, ids, RootGraphPlans.SeriesEntity, ct);
        var result = new List<SeriesExportData>(ids.Count);
        foreach (var id in ids)
        {
            if (!graph.Entities.TryGetValue((rootType,id), out var obj)) continue;
            var t = rootType; var e = (SeriesEntity)obj;
            var rows = ExportGraphMapper.Rows(graph, "Series", id);
            result.Add(new SeriesExportData(e.Id, ExportGraphMapper.Title(t,e), ExportGraphMapper.Get(t,e,"TypeId"), ExportGraphMapper.Get(t,e,"NoOfSeasons"), ExportGraphMapper.Get(t,e,"NoOfEpisodes"), ExportGraphMapper.Get(t,e,"ConnectionId"), ExportGraphMapper.Get(t,e,"Details"), Episodes(graph, id), rows));
        }
        return result;
    }

/// <summary>Performs the episodes operation.</summary>
    private static IReadOnlyList<EpisodeReference> Episodes(ExportGraph graph, string seriesId) =>
        graph.Entities
            .Where(x =>
                string.Equals(x.Key.TypeEntity.GetTableName() ?? x.Key.TypeEntity.Name, "Episode", StringComparison.Ordinal) &&
                string.Equals(ExportGraphMapper.Get(x.Key.TypeEntity, x.Value, "SeriesId"), seriesId, StringComparison.Ordinal))
            .Select(x =>
            {
                var type = x.Key.TypeEntity;
                var entity = x.Value;
                return new EpisodeReference(
                    x.Key.Id,
                    ExportGraphMapper.Title(type, entity),
                    ExportGraphMapper.Get(type, entity, "SeasonNo"),
                    ExportGraphMapper.Get(type, entity, "EpisodeNo"));
            })
            .OrderBy(x => x.SeasonNo, StringComparer.Ordinal)
            .ThenBy(x => x.EpisodeNo, StringComparer.Ordinal)
            .ThenBy(x => x.Id, StringComparer.Ordinal)
            .ToArray();
}
