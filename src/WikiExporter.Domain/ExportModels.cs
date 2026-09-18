namespace WikiExporter.Domain.Export;

/// <summary>Localized source value. Persistence keeps all three source-language variants.</summary>
public sealed record LocalizedValue(string? Original, string? English, string? German);

/// <summary>Stable reference to another exported entity.</summary>
public sealed record EntityReference(string Id, string? DisplayName = null);
public sealed record EpisodeReference(string Id, LocalizedValue Title, string? SeasonNo, string? EpisodeNo);
public sealed record WorkReference(string Type, string Id, LocalizedValue Title);

/// <summary>One persisted row retained by the export read model. This prevents data loss for schema areas not yet given a specialized domain type.</summary>
public sealed record ExportRowData(
    string Table,
    string Id,
    IReadOnlyDictionary<string,string?> Fields,
    IReadOnlyDictionary<string,string?> ForeignKeys,
    string? Order = null);

public abstract record ExportDataBase(string Id, LocalizedValue Title, string? Details, IReadOnlyList<ExportRowData> RelatedData);

public sealed record MovieExportData(string Id, LocalizedValue Title, string? TypeId, string? Budget, string? WorldwideGross, string? WorldwideGrossDate, string? ConnectionId, string? Details, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Title, Details, RelatedData);
public sealed record SeriesExportData(string Id, LocalizedValue Title, string? TypeId, string? NoOfSeasons, string? NoOfEpisodes, string? ConnectionId, string? Details, IReadOnlyList<EpisodeReference> Episodes, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Title, Details, RelatedData);
public sealed record EpisodeExportData(string Id, LocalizedValue Title, string? SeriesId, string? SeasonNo, string? EpisodeNo, string? Details, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Title, Details, RelatedData);
public sealed record BookExportData(string Id, LocalizedValue Title, string? TypeId, string? ConnectionId, string? Details, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Title, Details, RelatedData);
public sealed record VideoGameExportData(string Id, LocalizedValue Title, string? TypeId, string? Budget, string? WorldwideGross, string? WorldwideGrossDate, string? ConnectionId, string? Details, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Title, Details, RelatedData);
public sealed record PersonExportData(string Id, LocalizedValue Name, string? BirthName, string? DateOfBirth, string? DateOfDeath, string? EnglishCauseOfDeath, string? GermanCauseOfDeath, string? GenderId, string? Height, string? TypeId, string? Details, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Name, Details, RelatedData);
public sealed record ConnectionExportData(string Id, LocalizedValue Name, string? ParentConnectionId, string? Details, IReadOnlyList<EntityReference> Children, IReadOnlyList<WorkReference> Works, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Name, Details, RelatedData);
