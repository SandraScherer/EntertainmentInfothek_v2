namespace WikiExporter.Application.Export.Requests;

/// <summary>Complete application-level export command, independent of persistence and rendering implementations.</summary>
/// <param name="EntityType">The kind of entity to export.</param>
/// <param name="Scope">Whether to export one entity or all entities in batches.</param>
/// <param name="Language">The requested content language.</param>
/// <param name="Format">The target wiki format.</param>
/// <param name="OutputDirectory">Optional destination directory.</param>
public sealed record ExportRequest(
    ExportEntityType EntityType,
    ExportScope Scope,
    ExportLanguage Language,
    ExportFormat Format = ExportFormat.Obsidian,
    string? OutputDirectory = null);
