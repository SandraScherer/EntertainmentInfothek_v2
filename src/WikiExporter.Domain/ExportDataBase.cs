namespace WikiExporter.Domain.Export;

/// <summary>Represents export data base.</summary>
public abstract record ExportDataBase(string Id, LocalizedValue Title, string? Details, IReadOnlyList<ExportRowData> RelatedData);
