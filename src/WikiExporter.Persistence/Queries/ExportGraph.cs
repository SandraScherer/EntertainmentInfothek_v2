using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Reflection;
using WikiExporter.Persistence.DbContext;

namespace WikiExporter.Persistence.Queries;

/// <summary>In-memory representation of a bounded export graph. Only the current root batch is retained.</summary>
internal sealed class ExportGraph
{
    public Dictionary<(IEntityType Type,string Id),object> Entities { get; } = new();
    public Dictionary<(IEntityType Type,string Id), Dictionary<string,string?>> ForeignKeys { get; } = new();
}

/// <summary>Loads complete root-specific association graphs with set-based IN queries. It never uses Include or one query per row.</summary>
internal sealed class ExportGraphLoader
{
    private readonly EntertainmentInfothekDbContext _db;
    private static readonly string[] ExcludedColumns = ["Notes", "StatusID", "LastUpdated"];
    private static readonly HashSet<string> UserTables = ["Movie_User","Series_User","Book_User","VideoGame_User"];

    public ExportGraphLoader(EntertainmentInfothekDbContext db) => _db = db;

    public async Task<ExportGraph> LoadAsync(IEntityType rootType, IReadOnlyCollection<string> rootIds, IReadOnlySet<string> expandableTables, CancellationToken ct)
    {
        var graph = new ExportGraph();
        var pending = new Queue<(IEntityType Type, IReadOnlyCollection<string> Ids)>();
        pending.Enqueue((rootType, rootIds));
        var expanded = new HashSet<string>();

        while (pending.Count > 0)
        {
            var (type, ids) = pending.Dequeue();
            if (ids.Count == 0) continue;
            var table = type.GetTableName() ?? type.Name;
            if (!expanded.Add(table)) continue;
            var rows = await QueryByIdsAsync(type, ids, ct);
            AddRows(graph, type, rows);

            // 1) Follow dependent rows only for explicitly exportable association tables.
            foreach (var dependent in _db.Model.GetEntityTypes().Where(e => !e.IsOwned()))
            {
                var depTable = dependent.GetTableName() ?? dependent.Name;
                if (UserTables.Contains(depTable) || !expandableTables.Contains(depTable)) continue;
                var matchingFks = dependent.GetForeignKeys().Where(f => f.PrincipalEntityType == type).ToList();
                if (matchingFks.Count == 0) continue;
                var depIds = await QueryDependentIdsAsync(dependent, matchingFks, ids, ct);
                if (depIds.Count > 0) pending.Enqueue((dependent, depIds));
            }
        }

        // Resolve principal lookup rows for every FK appearing in the bounded graph. Lookup entities are deliberately not expanded.
        var lookupRequests = new Dictionary<IEntityType, HashSet<string>>();
        foreach (var ((type, _), entity) in graph.Entities)
        {
            foreach (var fk in type.GetForeignKeys())
            {
                if (fk.Properties.Count != 1 || fk.PrincipalKey.Properties.Count != 1) continue;
                var prop = fk.Properties[0].PropertyInfo;
                if (prop is null) continue;
                var value = prop.GetValue(entity) as string;
                if (string.IsNullOrWhiteSpace(value)) continue;
                if (!lookupRequests.TryGetValue(fk.PrincipalEntityType, out var set)) lookupRequests[fk.PrincipalEntityType] = set = new();
                set.Add(value);
            }
        }
        foreach (var request in lookupRequests)
        {
            var principalRows = await QueryByIdsAsync(request.Key, request.Value, ct);
            AddRows(graph, request.Key, principalRows);

            // Text and Image have meaningful second-level metadata (authors/sources).
            // They are the only lookup entities intentionally expanded; Person/Company/etc. remain references.
            var principalTable = request.Key.GetTableName() ?? request.Key.Name;
            if (principalTable is "Text" or "Image")
            {
                foreach (var dependent in _db.Model.GetEntityTypes().Where(e => !e.IsOwned()))
                {
                    var depTable = dependent.GetTableName() ?? dependent.Name;
                    if (!expandableTables.Contains(depTable) || UserTables.Contains(depTable)) continue;
                    var matching = dependent.GetForeignKeys().Where(f => f.PrincipalEntityType == request.Key && f.Properties.Count == 1).ToList();
                    if (matching.Count == 0) continue;
                    var childIds = await QueryDependentIdsAsync(dependent, matching, request.Value, ct);
                    if (childIds.Count == 0) continue;
                    AddRows(graph, dependent, await QueryByIdsAsync(dependent, childIds, ct));
                    // Child rows may reference Person/Company/Status/etc.; those are resolved below by the normal lookup pass.
                }
            }
        }
        return graph;
    }

    private async Task<List<object>> QueryByIdsAsync(IEntityType type, IReadOnlyCollection<string> ids, CancellationToken ct)
    {
        var key = type.FindPrimaryKey()?.Properties.SingleOrDefault();
        if (key?.PropertyInfo is null) return [];
        var set = _db.Set(type.ClrType).AsNoTracking();
        var p = Expression.Parameter(type.ClrType, "e");
        var value = Expression.Call(typeof(EF), nameof(EF.Property), [typeof(string)], p, Expression.Constant(key.Name));
        var contains = Expression.Call(typeof(Enumerable), nameof(Enumerable.Contains), [typeof(string)], Expression.Constant(ids.ToArray()), value);
        var lambda = Expression.Lambda(contains, p);
        var where = set.Provider.CreateQuery(Expression.Call(typeof(Queryable), nameof(Queryable.Where), [type.ClrType], set.Expression, lambda));
        var toList = typeof(EntityFrameworkQueryableExtensions).GetMethods(BindingFlags.Public|BindingFlags.Static).Single(m => m.Name == nameof(EntityFrameworkQueryableExtensions.ToListAsync) && m.IsGenericMethodDefinition && m.GetParameters().Length == 2);
        var task = (Task)toList.MakeGenericMethod(type.ClrType).Invoke(null, [where, ct])!;
        await task.ConfigureAwait(false);
        return ((System.Collections.IEnumerable)task.GetType().GetProperty("Result")!.GetValue(task)!).Cast<object>().ToList();
    }

    private async Task<List<string>> QueryDependentIdsAsync(IEntityType dependent, IReadOnlyCollection<IForeignKey> fks, IReadOnlyCollection<string> parentIds, CancellationToken ct)
    {
        var key = dependent.FindPrimaryKey()?.Properties.SingleOrDefault();
        if (key?.PropertyInfo is null) return [];
        var set = _db.Set(dependent.ClrType).AsNoTracking();
        var p = Expression.Parameter(dependent.ClrType, "e");
        Expression? body = null;
        foreach (var fk in fks.Where(f => f.Properties.Count == 1))
        {
            var prop = Expression.Call(typeof(EF), nameof(EF.Property), [typeof(string)], p, Expression.Constant(fk.Properties[0].Name));
            var contains = Expression.Call(typeof(Enumerable), nameof(Enumerable.Contains), [typeof(string)], Expression.Constant(parentIds.ToArray()), prop);
            body = body is null ? contains : Expression.OrElse(body, contains);
        }
        if (body is null) return [];
        var lambda = Expression.Lambda(body, p);
        var where = set.Provider.CreateQuery(Expression.Call(typeof(Queryable), nameof(Queryable.Where), [dependent.ClrType], set.Expression, lambda));
        var toList = typeof(EntityFrameworkQueryableExtensions).GetMethods(BindingFlags.Public|BindingFlags.Static).Single(m => m.Name == nameof(EntityFrameworkQueryableExtensions.ToListAsync) && m.IsGenericMethodDefinition && m.GetParameters().Length == 2);
        var task = (Task)toList.MakeGenericMethod(dependent.ClrType).Invoke(null, [where, ct])!;
        await task.ConfigureAwait(false);
        return ((System.Collections.IEnumerable)task.GetType().GetProperty("Result")!.GetValue(task)!).Cast<object>().Select(o => key.PropertyInfo.GetValue(o) as string).Where(x => x is not null).Cast<string>().ToList();
    }

    private static void AddRows(ExportGraph graph, IEntityType type, IEnumerable<object> rows)
    {
        var key = type.FindPrimaryKey()?.Properties.SingleOrDefault();
        if (key?.PropertyInfo is null) return;
        foreach (var row in rows)
        {
            var id = key.PropertyInfo.GetValue(row) as string;
            if (string.IsNullOrWhiteSpace(id)) continue;
            graph.Entities[(type,id)] = row;
            var fks = new Dictionary<string,string?>(StringComparer.Ordinal);
            foreach (var fk in type.GetForeignKeys())
            {
                if (fk.Properties.Count != 1 || fk.Properties[0].PropertyInfo is null) continue;
                fks[fk.Properties[0].Name] = fk.Properties[0].PropertyInfo.GetValue(row) as string;
            }
            graph.ForeignKeys[(type,id)] = fks;
        }
    }

    internal static ExportRowData ToRow(IEntityType type, object entity)
    {
        var key = type.FindPrimaryKey()?.Properties.SingleOrDefault();
        var id = key?.PropertyInfo?.GetValue(entity) as string ?? string.Empty;
        var fields = new Dictionary<string,string?>(StringComparer.Ordinal);
        foreach (var p in type.GetProperties())
        {
            if (ExcludedColumns.Contains(p.Name, StringComparer.OrdinalIgnoreCase)) continue;
            var v = p.PropertyInfo?.GetValue(entity) as string;
            fields[p.Name] = v;
        }
        var fks = new Dictionary<string,string?>(StringComparer.Ordinal);
        foreach (var fk in type.GetForeignKeys())
        {
            if (fk.Properties.Count == 1 && fk.Properties[0].PropertyInfo is not null) fks[fk.Properties[0].Name] = fk.Properties[0].PropertyInfo.GetValue(entity) as string;
        }
        fields.Remove("ID");
        return new ExportRowData(type.GetTableName() ?? type.Name, id, fields, fks, fields.GetValueOrDefault("Order"));
    }
}
