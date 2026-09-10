namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Weblink
/// </summary>
public sealed class WeblinkEntity
{
    public string Id { get; set; } = string.Empty;

    public string? Url { get; set; }

    public string? GermanName { get; set; }

    public string? EnglishName { get; set; }
}
