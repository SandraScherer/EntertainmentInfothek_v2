using WikiExporter.Domain.Export;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WikiExporter.Persistence.Queries;

/// <summary>Defines the export graph mapper type.</summary>
internal static class ExportGraphMapper
{
/// <summary>Executes the rows operation.</summary>
    internal static IReadOnlyList<ExportRowData> Rows(ExportGraph graph, string rootTable, string rootId) =>
        graph.Entities.Where(x => x.Key.TypeEntity.GetTableName() != null && (x.Key.Id == rootId || IsRelevant(x.Key.TypeEntity.GetTableName()!, rootTable)))
            .Select(x => ExportGraphLoader.ToRow(x.Key.TypeEntity, x.Value))
            .OrderBy(x => x.Table, StringComparer.Ordinal).ThenBy(x => x.Order, StringComparer.Ordinal).ThenBy(x => x.Id, StringComparer.Ordinal)
            .ToArray();

/// <summary>Executes the is relevant operation.</summary>
    private static bool IsRelevant(string table, string root) => table == root || table.StartsWith(root + "_", StringComparison.Ordinal) || (root == "Book" && (table == "Publication" || table.StartsWith("Publication_", StringComparison.Ordinal))) || (root == "VideoGame" && (table == "TechnicalSpecification" || table.StartsWith("TechnicalSpecification_", StringComparison.Ordinal))) || table is "Text_Author" or "Text_Source" or "Image_Source";

/// <summary>Executes the title operation.</summary>
    internal static LocalizedValue Title(IEntityType type, object entity, string singular = "Title")
    {
        string? Get(string n) => type.FindProperty(n)?.PropertyInfo?.GetValue(entity) as string;
        return new LocalizedValue(Get("Original"+singular), Get("English"+singular), Get("German"+singular));
    }
/// <summary>Executes the name operation.</summary>
    internal static LocalizedValue Name(IEntityType type, object entity)
    {
        string? Get(string n) => type.FindProperty(n)?.PropertyInfo?.GetValue(entity) as string;
        return new LocalizedValue(Get("OriginalName"), Get("EnglishName"), Get("GermanName"));
    }
/// <summary>Executes the get operation.</summary>
    internal static string? Get(IEntityType type, object entity, string property) => type.FindProperty(property)?.PropertyInfo?.GetValue(entity) as string;
}
