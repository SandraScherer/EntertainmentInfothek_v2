namespace WikiExporter.Domain.Export;

/// <summary>Defines the book export data type.</summary>
public sealed record BookExportData(string Id, LocalizedValue Title, string? TypeId, string? ConnectionId, string? Details, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Title, Details, RelatedData);
