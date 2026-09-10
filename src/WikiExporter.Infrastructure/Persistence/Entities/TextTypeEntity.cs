namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle TextType
/// </summary>
public sealed class TextTypeEntity
{
    public string Id { get; set; } = string.Empty;

    public string? EnglishName { get; set; }

    public string? GermanName { get; set; }
}
