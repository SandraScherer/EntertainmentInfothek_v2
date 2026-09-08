using Microsoft.EntityFrameworkCore;
using WikiExporter.Application.Persistence;
using WikiExporter.Domain.Export;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.Queries;

namespace WikiExporter.Persistence.Readers;

/// <summary>Concrete Movie reader. All associations are loaded in bounded set-based batches.</summary>
internal sealed class MovieExportReader : ExportReaderBase, IMovieExportReader
{
    public MovieExportReader(IDbContextFactory<EntertainmentInfothekDbContext> factory) : base(factory) { }

    public async Task<MovieExportData?> GetAsync(string id, CancellationToken ct = default)
    {
        await using var db = await Factory.CreateDbContextAsync(ct);
        var entity = await db.Movie.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, ct);
        if (entity is null) return null;
        return await LoadAndMapAsync(db, new[] { id }, ct).ContinueWith(t => t.Result.SingleOrDefault(), ct);
    }

    public async IAsyncEnumerable<MovieExportData> ReadAllAsync(BatchOptions options, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    {
        await using var db = await Factory.CreateDbContextAsync(ct);
        string? after = null;
        while (true)
        {
            var ids = await db.Movie.AsNoTracking().Where(x => after == null || string.Compare(x.Id, after) > 0).OrderBy(x => x.Id).Select(x => x.Id).Take(Size(options)).ToListAsync(ct);
            if (ids.Count == 0) yield break;
            foreach (var item in await LoadAndMapAsync(db, ids, ct)) yield return item;
            after = ids[^1];
        }
    }

    private static async Task<List<MovieExportData>> LoadAndMapAsync(EntertainmentInfothekDbContext db, IReadOnlyCollection<string> ids, CancellationToken ct)
    {
        var loader = new ExportGraphLoader(db);
        var rootType = db.Model.FindEntityType(typeof(Movie))!;
        var graph = await loader.LoadAsync(rootType, ids, RootGraphPlans.Movie, ct);
        var result = new List<MovieExportData>(ids.Count);
        foreach (var id in ids)
        {
            if (!graph.Entities.TryGetValue((rootType,id), out var obj)) continue;
            var t = rootType; var e = (Movie)obj;
            var rows = ExportGraphMapper.Rows(graph, "Movie", id);
            result.Add(new MovieExportData(e.Id, ExportGraphMapper.Title(t,e), ExportGraphMapper.Get(t,e,"TypeId"), ExportGraphMapper.Get(t,e,"Budget"), ExportGraphMapper.Get(t,e,"WorldwideGross"), ExportGraphMapper.Get(t,e,"WorldwideGrossDate"), ExportGraphMapper.Get(t,e,"ConnectionId"), ExportGraphMapper.Get(t,e,"Details"), rows));
        }
        return result;
    }
}
