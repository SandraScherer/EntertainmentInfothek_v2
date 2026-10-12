namespace WikiExporter.Domain.Export;

/// <summary>Represents episode export data.</summary>
public sealed record EpisodeExportData(string Id, LocalizedValue Title, string? SeriesId, string? SeasonNo, string? EpisodeNo, string? Details, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Title, Details, RelatedData);
