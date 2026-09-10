namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Image
/// </summary>
public sealed class ImageEntity
{
    public string Id { get; set; } = string.Empty;

    public string? FileName { get; set; }

    public string? GermanDescription { get; set; }

    public string? EnglishDescription { get; set; }
}
