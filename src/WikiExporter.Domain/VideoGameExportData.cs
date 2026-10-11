namespace WikiExporter.Domain.Export;

/// <summary>Defines the video game export data type.</summary>
public sealed record VideoGameExportData(string Id, LocalizedValue Title, string? TypeId, string? Budget, string? WorldwideGross, string? WorldwideGrossDate, string? ConnectionId, string? Details, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Title, Details, RelatedData);
