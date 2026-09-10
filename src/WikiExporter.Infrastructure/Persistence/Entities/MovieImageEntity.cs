namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Movie_Image
/// </summary>
public sealed class MovieImageEntity
{
    public string Id { get; set; } = string.Empty;

    public string? MovieId { get; set; }

    public string? ImageId { get; set; }

    public MovieEntity Movie { get; set; } = null!;

    public ImageEntity Image { get; set; } = null!;
}
