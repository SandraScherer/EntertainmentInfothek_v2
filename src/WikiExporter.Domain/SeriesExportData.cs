namespace WikiExporter.Domain.Export;

/// <summary>Represents series export data.</summary>
public sealed record SeriesExportData(string Id, LocalizedValue Title, string? TypeId, string? NoOfSeasons, string? NoOfEpisodes, string? ConnectionId, string? Details, IReadOnlyList<EpisodeReference> Episodes, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Title, Details, RelatedData);
