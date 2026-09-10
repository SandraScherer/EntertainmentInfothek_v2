namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Genre
/// </summary>
public sealed class GenreEntity
{
    public string Id { get; set; } = string.Empty;

     public string? EnglishName { get; set; }

     public string? GermanName { get; set; }
}
