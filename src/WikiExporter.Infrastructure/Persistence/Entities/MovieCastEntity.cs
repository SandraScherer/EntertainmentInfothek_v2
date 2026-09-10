namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Movie_Cast
/// </summary>
public sealed class MovieCastEntity
{
    public string Id { get; set; } = string.Empty;

    public string? MovieId { get; set; }

    public MovieEntity Movie { get; set; } = null!;

    public string? ActorId { get; set; }

    public PersonEntity Actor { get; set; } = null!;

    public string? EnglishRole { get; set; }

    public string? GermanRole { get; set; }

    public string? Order { get; set; }
}
