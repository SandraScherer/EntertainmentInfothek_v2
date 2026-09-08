using WikiExporter.Domain.Export;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WikiExporter.Persistence.Queries;

internal static class ExportGraphMapper
{
    internal static IReadOnlyList<ExportRowData> Rows(ExportGraph graph, string rootTable, string rootId) =>
        graph.Entities.Where(x => x.Key.Type.GetTableName() != null && (x.Key.Id == rootId || IsRelevant(x.Key.Type.GetTableName()!, rootTable)))
            .Select(x => ExportGraphLoader.ToRow(x.Key.Type, x.Value))
            .OrderBy(x => x.Table, StringComparer.Ordinal).ThenBy(x => x.Order, StringComparer.Ordinal).ThenBy(x => x.Id, StringComparer.Ordinal)
            .ToArray();

    private static bool IsRelevant(string table, string root) => table == root || table.StartsWith(root + "_", StringComparison.Ordinal) || (root == "Book" && (table == "Publication" || table.StartsWith("Publication_", StringComparison.Ordinal))) || (root == "VideoGame" && (table == "TechnicalSpecification" || table.StartsWith("TechnicalSpecification_", StringComparison.Ordinal))) || table is "Text_Author" or "Text_Source" or "Image_Source";

    internal static LocalizedValue Title(IEntityType type, object entity, string singular = "Title")
    {
        string? Get(string n) => type.FindProperty(n)?.PropertyInfo?.GetValue(entity) as string;
        return new LocalizedValue(Get("Original"+singular), Get("English"+singular), Get("German"+singular));
    }
    internal static LocalizedValue Name(IEntityType type, object entity)
    {
        string? Get(string n) => type.FindProperty(n)?.PropertyInfo?.GetValue(entity) as string;
        return new LocalizedValue(Get("OriginalName"), Get("EnglishName"), Get("GermanName"));
    }
    internal static string? Get(IEntityType type, object entity, string property) => type.FindProperty(property)?.PropertyInfo?.GetValue(entity) as string;
}
