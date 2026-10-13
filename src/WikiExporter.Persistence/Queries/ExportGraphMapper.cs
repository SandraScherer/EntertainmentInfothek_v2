using WikiExporter.Domain.Export;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WikiExporter.Persistence.Queries;

/// <summary>Represents export graph mapper.</summary>
internal static class ExportGraphMapper
{
/// <summary>Performs the rows operation.</summary>
    internal static IReadOnlyList<ExportRowData> Rows(ExportGraph graph, string rootTable, string rootId)
    {
        // A batch graph contains associations for every root in that batch. Select the
        // transitive dependent rows for this root rather than every row whose table name
        // happens to match the root's allow-list; otherwise one root leaks another root's
        // relationship rows into its export.
        var root = graph.Entities.Keys.FirstOrDefault(x =>
            string.Equals(x.TypeEntity.GetTableName(), rootTable, StringComparison.Ordinal) &&
            string.Equals(x.Id, rootId, StringComparison.Ordinal));
        if (root.TypeEntity is null)
            return Array.Empty<ExportRowData>();

        var included = new HashSet<(IEntityType TypeEntity, string Id)> { root };
        var visited = new HashSet<(IEntityType TypeEntity, string Id)> { root };
        var pending = new Queue<(IEntityType TypeEntity, string Id)>();
        pending.Enqueue(root);

        while (pending.Count > 0)
        {
            var parent = pending.Dequeue();

            // Text/Image are lookup principals referenced by root-specific rows. They are
            // not emitted as related rows, but their author/source associations are.
            if ((parent.TypeEntity.GetTableName() is "Text" or "Image") == false)
            {
                foreach (var fk in parent.TypeEntity.GetForeignKeys())
                {
                    if (fk.Properties.Count != 1 || fk.Properties[0].PropertyInfo is null)
                        continue;
                    var principalType = fk.PrincipalEntityType;
                    if (principalType.GetTableName() is not ("Text" or "Image"))
                        continue;
                    var principalId = fk.Properties[0].PropertyInfo!.GetValue(graph.Entities[parent]) as string;
                    if (string.IsNullOrWhiteSpace(principalId))
                        continue;
                    var principal = graph.Entities.Keys.FirstOrDefault(key =>
                        key.TypeEntity == principalType && string.Equals(key.Id, principalId, StringComparison.Ordinal));
                    if (principal.TypeEntity is not null && visited.Add(principal))
                        pending.Enqueue(principal);
                }
            }

            foreach (var candidate in graph.Entities)
            {
                var candidateKey = candidate.Key;
                var table = candidateKey.TypeEntity.GetTableName();
                if (table is null || included.Contains(candidateKey) || !IsRelevant(table, rootTable))
                    continue;

                var referencesParent = candidateKey.TypeEntity.GetForeignKeys().Any(fk =>
                {
                    if (fk.PrincipalEntityType != parent.TypeEntity || fk.Properties.Count != 1 ||
                        fk.Properties[0].PropertyInfo is null)
                        return false;

                    var foreignKeyValue = fk.Properties[0].PropertyInfo!.GetValue(candidate.Value) as string;
                    var principalKey = fk.PrincipalKey.Properties.SingleOrDefault();
                    var principalValue = principalKey?.PropertyInfo?.GetValue(graph.Entities[parent]) as string;
                    return string.Equals(foreignKeyValue, principalValue, StringComparison.Ordinal) &&
                           string.Equals(principalValue, parent.Id, StringComparison.Ordinal);
                });

                if (!referencesParent)
                    continue;

                included.Add(candidateKey);
                if (visited.Add(candidateKey))
                    pending.Enqueue(candidateKey);
            }
        }

        return included.Select(key => ExportGraphMapper.ToRow(key.TypeEntity, graph.Entities[key]))
            .OrderBy(x => x.Table, StringComparer.Ordinal).ThenBy(x => x.Order, StringComparer.Ordinal).ThenBy(x => x.Id, StringComparer.Ordinal)
            .ToArray();
    }

    /// <summary>Checks whether a table is an exportable descendant of the requested root type.</summary>
    private static bool IsRelevant(string table, string root) =>
        table.StartsWith(root + "_", StringComparison.Ordinal) ||
        (root == "Book" && (table == "Publication" || table.StartsWith("Publication_", StringComparison.Ordinal))) ||
        (root == "VideoGame" && (table == "TechnicalSpecification" || table.StartsWith("TechnicalSpecification_", StringComparison.Ordinal))) ||
        table is "Text_Author" or "Text_Source" or "Image_Source";

/// <summary>Performs the title operation.</summary>
    internal static LocalizedValue Title(IEntityType type, object entity, string singular = "Title")
    {
        string? Get(string n) => type.FindProperty(n)?.PropertyInfo?.GetValue(entity) as string;
        return new LocalizedValue(Get("Original"+singular), Get("English"+singular), Get("German"+singular));
    }
/// <summary>Performs the name operation.</summary>
    internal static LocalizedValue Name(IEntityType type, object entity)
    {
        string? Get(string n) => type.FindProperty(n)?.PropertyInfo?.GetValue(entity) as string;
        return new LocalizedValue(Get("OriginalName"), Get("EnglishName"), Get("GermanName"));
    }
/// <summary>Performs the get operation.</summary>
    internal static string? Get(IEntityType type, object entity, string property) => type.FindProperty(property)?.PropertyInfo?.GetValue(entity) as string;
}
