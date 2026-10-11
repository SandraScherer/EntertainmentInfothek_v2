namespace WikiExporter.Domain.Export;

/// <summary>One persisted row retained by the export read model. This prevents data loss for schema areas not yet given a specialized domain type.</summary>
public sealed record ExportRowData(
    string Table,
    string Id,
    IReadOnlyDictionary<string,string?> Fields,
    IReadOnlyDictionary<string,string?> ForeignKeys,
    string? Order = null);
