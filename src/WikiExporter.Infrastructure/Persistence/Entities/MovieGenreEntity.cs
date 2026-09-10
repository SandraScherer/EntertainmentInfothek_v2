namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Movie_Genre
/// </summary>
public sealed class MovieGenreEntity
{
    public string Id { get; set; } = string.Empty;

    public string? MovieId { get; set; }

    public string? GenreId { get; set; }

    public MovieEntity Movie { get; set; } = null!;

    public GenreEntity Genre { get; set; } = null!;
}
