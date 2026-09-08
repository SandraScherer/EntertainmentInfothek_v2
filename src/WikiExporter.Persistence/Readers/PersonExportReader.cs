using Microsoft.EntityFrameworkCore;
using WikiExporter.Application.Persistence;
using WikiExporter.Domain.Export;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.Queries;

namespace WikiExporter.Persistence.Readers;

/// <summary>Concrete Person reader. All associations are loaded in bounded set-based batches.</summary>
internal sealed class PersonExportReader : ExportReaderBase, IPersonExportReader
{
    public PersonExportReader(IDbContextFactory<EntertainmentInfothekDbContext> factory) : base(factory) { }

    public async Task<PersonExportData?> GetAsync(string id, CancellationToken ct = default)
    {
        await using var db = await Factory.CreateDbContextAsync(ct);
        var entity = await db.Person.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id, ct);
        if (entity is null) return null;
        return await LoadAndMapAsync(db, new[] { id }, ct).ContinueWith(t => t.Result.SingleOrDefault(), ct);
    }

    public async IAsyncEnumerable<PersonExportData> ReadAllAsync(BatchOptions options, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken ct = default)
    {
        await using var db = await Factory.CreateDbContextAsync(ct);
        string? after = null;
        while (true)
        {
            var ids = await db.Person.AsNoTracking().Where(x => after == null || string.Compare(x.Id, after) > 0).OrderBy(x => x.Id).Select(x => x.Id).Take(Size(options)).ToListAsync(ct);
            if (ids.Count == 0) yield break;
            foreach (var item in await LoadAndMapAsync(db, ids, ct)) yield return item;
            after = ids[^1];
        }
    }

    private static async Task<List<PersonExportData>> LoadAndMapAsync(EntertainmentInfothekDbContext db, IReadOnlyCollection<string> ids, CancellationToken ct)
    {
        var loader = new ExportGraphLoader(db);
        var rootType = db.Model.FindEntityType(typeof(Person))!;
        var graph = await loader.LoadAsync(rootType, ids, RootGraphPlans.Person, ct);
        var result = new List<PersonExportData>(ids.Count);
        foreach (var id in ids)
        {
            if (!graph.Entities.TryGetValue((rootType,id), out var obj)) continue;
            var t = rootType; var e = (Person)obj;
            var rows = ExportGraphMapper.Rows(graph, "Person", id);
            result.Add(new PersonExportData(e.Id, ExportGraphMapper.Name(t,e), ExportGraphMapper.Get(t,e,"BirthName"), ExportGraphMapper.Get(t,e,"DateOfBirth"), ExportGraphMapper.Get(t,e,"DateOfDeath"), ExportGraphMapper.Get(t,e,"EnglishCauseOfDeath"), ExportGraphMapper.Get(t,e,"GermanCauseOfDeath"), ExportGraphMapper.Get(t,e,"GenderId"), ExportGraphMapper.Get(t,e,"Height"), ExportGraphMapper.Get(t,e,"TypeId"), ExportGraphMapper.Get(t,e,"Details"), rows));
        }
        return result;
    }
}
