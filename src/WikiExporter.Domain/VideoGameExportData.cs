namespace WikiExporter.Domain.Export;

/// <summary>Represents video game export data.</summary>
public sealed record VideoGameExportData(string Id, LocalizedValue Title, string? TypeId, string? Budget, string? WorldwideGross, string? WorldwideGrossDate, string? ConnectionId, string? Details, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Title, Details, RelatedData);
