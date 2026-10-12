namespace WikiExporter.Domain.Export;

/// <summary>Represents book export data.</summary>
public sealed record BookExportData(string Id, LocalizedValue Title, string? TypeId, string? ConnectionId, string? Details, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Title, Details, RelatedData);
