namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Status
/// </summary>
public sealed class StatusEntity
{
    public string Id { get; set; } = string.Empty;

    public string? EnglishName { get; set; }

    public string? GermanName { get; set; }
}
