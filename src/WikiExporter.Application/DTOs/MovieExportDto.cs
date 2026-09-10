namespace WikiExporter.Application.DTOs;

public sealed class MovieExportDto
{
    public required string Id { get; init; }

    public string OriginalTitle { get; init; } = string.Empty;

    public string EnglishTitle { get; init; } = string.Empty;

    public string GermanTitle { get; init; } = string.Empty;

    public string Status { get; init; } = string.Empty;

    public string LastUpdated { get; init; } = string.Empty;

    public IList<MovieGenreDto> Genres { get; init; } = new List<MovieGenreDto>();

    public IList<MovieCastDto> Cast { get; init; } = new List<MovieCastDto>();

    public IList<MovieCrewDto> Crew { get; init; } = new List<MovieCrewDto>();

    public IList<MovieTextDto> Texts { get; init; } = new List<MovieTextDto>();

    public IList<MovieImageDto> Images { get; init; } = new List<MovieImageDto>();

    public IList<MovieWeblinkDto> Weblinks { get; init; } = new List<MovieWeblinkDto>();
}
