namespace WikiExporter.Console.Configuration;

/// <summary>
/// Einstellungen aus appsettings.json
/// </summary>
public sealed class ApplicationSettings
{
    public string DefaultFolder { get; set; }
        = "Exports";
}
