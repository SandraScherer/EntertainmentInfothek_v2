namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Movie_Weblink
/// </summary>
public sealed class MovieWeblinkEntity
{
    public string Id { get; set; } = string.Empty;

    public string? MovieId { get; set; }

    public string? WeblinkId { get; set; }

    public MovieEntity Movie { get; set; } = null!;

    public WeblinkEntity Weblink { get; set; } = null!;
}
