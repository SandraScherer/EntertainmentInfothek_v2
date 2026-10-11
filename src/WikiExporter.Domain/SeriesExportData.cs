namespace WikiExporter.Domain.Export;

/// <summary>Defines the series export data type.</summary>
public sealed record SeriesExportData(string Id, LocalizedValue Title, string? TypeId, string? NoOfSeasons, string? NoOfEpisodes, string? ConnectionId, string? Details, IReadOnlyList<EpisodeReference> Episodes, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Title, Details, RelatedData);
