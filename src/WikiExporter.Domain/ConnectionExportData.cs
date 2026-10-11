namespace WikiExporter.Domain.Export;

/// <summary>Defines the connection export data type.</summary>
public sealed record ConnectionExportData(string Id, LocalizedValue Name, string? ParentConnectionId, string? Details, IReadOnlyList<EntityReference> Children, IReadOnlyList<WorkReference> Works, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Name, Details, RelatedData);
