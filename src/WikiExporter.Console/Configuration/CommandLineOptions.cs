using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Console.Configuration;

/// <summary>Contains the values parsed from the command line.</summary>
/// <param name="DatabasePath">Optional path to the SQLite database.</param>
/// <param name="OutputDirectory">Optional directory for exported files.</param>
/// <param name="EntityType">Optional type of entertainment entity to export.</param>
/// <param name="EntityId">Optional identifier when exporting a single entity.</param>
/// <param name="All">Indicates whether all entities of the selected type should be exported.</param>
/// <param name="Language">Optional language to use for exported text.</param>
/// <param name="Format">Optional output format.</param>
/// <param name="BatchSize">Optional batch size for an all-entities export.</param>
/// <param name="Help">Indicates whether help was requested.</param>
public sealed record CommandLineOptions(
    string? DatabasePath,
    string? OutputDirectory,
    ExportEntityType? EntityType,
    string? EntityId,
    bool All,
    ExportLanguage? Language,
    ExportFormat? Format,
    int? BatchSize,
    bool Help);
