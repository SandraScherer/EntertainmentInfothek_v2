namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Movie
/// </summary>
public sealed class MovieEntity
{
    public string Id { get; set; } = string.Empty;

    public string? OriginalTitle { get; set; }

    public string? EnglishTitle { get; set; }

    public string? GermanTitle { get; set; }

    public string? StatusId { get; set; }

    public StatusEntity? Status { get; set; }

    public string? LastUpdated { get; set; }

    public ICollection<MovieGenreEntity> Genres { get; set; }
        = new List<MovieGenreEntity>();

    public ICollection<MovieCastEntity> Cast { get; set; }
        = new List<MovieCastEntity>();

    public ICollection<MovieCrewEntity> Crew { get; set; }
        = new List<MovieCrewEntity>();

    public ICollection<MovieTextEntity> Texts { get; set; }
        = new List<MovieTextEntity>();

    public ICollection<MovieImageEntity> Images { get; set; }
        = new List<MovieImageEntity>();

    public ICollection<MovieWeblinkEntity> Weblinks { get; set; }
        = new List<MovieWeblinkEntity>();
}
