namespace WikiExporter.Domain.Export;

/// <summary>Defines the export data base type.</summary>
public abstract record ExportDataBase(string Id, LocalizedValue Title, string? Details, IReadOnlyList<ExportRowData> RelatedData);
