namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Movie_Text
/// </summary>
public sealed class MovieTextEntity
{
    public string Id { get; set; } = string.Empty;

    public string? MovieId { get; set; }

    public string? TextId { get; set; }

    public string? TypeId { get; set; }

    public MovieEntity Movie { get; set; } = null!;

    public TextEntity Text { get; set; } = null!;

    public TextTypeEntity TextType { get; set; } = null!;
}

