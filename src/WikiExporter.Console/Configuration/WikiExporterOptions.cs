namespace WikiExporter.Console.Configuration;

/// <summary>
/// Configuration that belongs to the console host rather than to the application layer.
/// The application itself receives concrete values through ExportRequest.
/// </summary>
public sealed class WikiExporterOptions
{
/// <summary>Stores section name for use by this component.</summary>
    public const string SectionName = "WikiExporter";

/// <summary>Gets or sets the database path.</summary>
    public string DatabasePath { get; set; } = "EntertainmentInfothek.db";
/// <summary>Gets or sets the output directory.</summary>
    public string OutputDirectory { get; set; } = "Export";
/// <summary>Gets or sets the default format.</summary>
    public string DefaultFormat { get; set; } = "Obsidian";
/// <summary>Gets or sets the default language.</summary>
    public string DefaultLanguage { get; set; } = "German";
/// <summary>Gets or sets the default batch size.</summary>
    public int DefaultBatchSize { get; set; } = 250;
}
