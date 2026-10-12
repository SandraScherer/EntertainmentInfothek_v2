namespace WikiExporter.Domain.Export;

/// <summary>Represents person export data.</summary>
public sealed record PersonExportData(string Id, LocalizedValue Name, string? BirthName, string? DateOfBirth, string? DateOfDeath, string? EnglishCauseOfDeath, string? GermanCauseOfDeath, string? GenderId, string? Height, string? TypeId, string? Details, IReadOnlyList<ExportRowData> RelatedData) : ExportDataBase(Id, Name, Details, RelatedData);
