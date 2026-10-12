namespace WikiExporter.Domain.Export;

/// <summary>Represents connection export data.</summary>
public sealed record ConnectionExportData(string Id, LocalizedValue Name, string? ParentConnectionId, string? Details, IReadOnlyList<EntityReference> Children, IReadOnlyList<WorkReference> Works, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Name, Details, RelatedData);
