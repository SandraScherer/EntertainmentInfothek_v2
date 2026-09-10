namespace WikiExporter.Console.Configuration;

/// <summary>
/// Configuration that belongs to the console host rather than to the application layer.
/// The application itself receives concrete values through ExportRequest.
/// </summary>
public sealed class WikiExporterOptions
{
    public const string SectionName = "WikiExporter";

    public string DatabasePath { get; set; } = "EntertainmentInfothek.db";
    public string OutputDirectory { get; set; } = "Export";
    public string DefaultFormat { get; set; } = "Obsidian";
    public string DefaultLanguage { get; set; } = "German";
    public int DefaultBatchSize { get; set; } = 250;
}
