using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Series</c>. The entity is persistence-only.</summary>
public sealed class Series
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalTitle</c>.</summary>
    public string? OriginalTitle { get; set; }
    /// <summary>Maps to <c>EnglishTitle</c>.</summary>
    public string? EnglishTitle { get; set; }
    /// <summary>Maps to <c>GermanTitle</c>.</summary>
    public string? GermanTitle { get; set; }
    /// <summary>Maps to <c>TypeID</c>.</summary>
    public string? TypeId { get; set; }
    /// <summary>Maps to <c>NoOfSeasons</c>.</summary>
    public string? NoOfSeasons { get; set; }
    /// <summary>Maps to <c>NoOfEpisodes</c>.</summary>
    public string? NoOfEpisodes { get; set; }
    /// <summary>Maps to <c>Budget</c>.</summary>
    public string? Budget { get; set; }
    /// <summary>Maps to <c>WorldwideGross</c>.</summary>
    public string? WorldwideGross { get; set; }
    /// <summary>Maps to <c>WorldwideGrossDate</c>.</summary>
    public string? WorldwideGrossDate { get; set; }
    /// <summary>Maps to <c>CastStatusID</c>.</summary>
    public string? CastStatusId { get; set; }
    /// <summary>Maps to <c>CrewStatusID</c>.</summary>
    public string? CrewStatusId { get; set; }
    /// <summary>Maps to <c>ConnectionID</c>.</summary>
    public string? ConnectionId { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>CastStatusID</c> to <c>Status</c>.</summary>
    public Status? CastStatus { get; set; }

    /// <summary>Navigation for FK <c>ConnectionID</c> to <c>Connection</c>.</summary>
    public Connection? Connection { get; set; }

    /// <summary>Navigation for FK <c>CrewStatusID</c> to <c>Status</c>.</summary>
    public Status? CrewStatus { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation for FK <c>TypeID</c> to <c>Type</c>.</summary>
    public Type? Type { get; set; }

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<Episode> Episodes { get; set; } = new List<Episode>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesAspectRatio> SeriesAspectRatios { get; set; } = new List<SeriesAspectRatio>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesAward> SeriesAwards { get; set; } = new List<SeriesAward>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCamera> SeriesCameras { get; set; } = new List<SeriesCamera>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCast> SeriesCasts { get; set; } = new List<SeriesCast>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCertification> SeriesCertifications { get; set; } = new List<SeriesCertification>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCinematographicProcess> SeriesCinematographicProcesss { get; set; } = new List<SeriesCinematographicProcess>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesColor> SeriesColors { get; set; } = new List<SeriesColor>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCompanyCredits> SeriesCompanyCreditss { get; set; } = new List<SeriesCompanyCredits>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCountry> SeriesCountrys { get; set; } = new List<SeriesCountry>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCrew> SeriesCrews { get; set; } = new List<SeriesCrew>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesFilmLength> SeriesFilmLengths { get; set; } = new List<SeriesFilmLength>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesFilmingDate> SeriesFilmingDates { get; set; } = new List<SeriesFilmingDate>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesFilmingLocation> SeriesFilmingLocations { get; set; } = new List<SeriesFilmingLocation>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesGenre> SeriesGenres { get; set; } = new List<SeriesGenre>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesImage> SeriesImages { get; set; } = new List<SeriesImage>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesLaboratory> SeriesLaboratorys { get; set; } = new List<SeriesLaboratory>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesLanguage> SeriesLanguages { get; set; } = new List<SeriesLanguage>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesNegativeFormat> SeriesNegativeFormats { get; set; } = new List<SeriesNegativeFormat>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesPrintedFilmFormat> SeriesPrintedFilmFormats { get; set; } = new List<SeriesPrintedFilmFormat>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesProductionDate> SeriesProductionDates { get; set; } = new List<SeriesProductionDate>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesReleaseDateFirstEpisode> SeriesReleaseDateFirstEpisodes { get; set; } = new List<SeriesReleaseDateFirstEpisode>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesReleaseDateLastEpisode> SeriesReleaseDateLastEpisodes { get; set; } = new List<SeriesReleaseDateLastEpisode>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesRuntime> SeriesRuntimes { get; set; } = new List<SeriesRuntime>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesScore> SeriesScores { get; set; } = new List<SeriesScore>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesSoundMix> SeriesSoundMixs { get; set; } = new List<SeriesSoundMix>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesText> SeriesTexts { get; set; } = new List<SeriesText>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesUser> SeriesUsers { get; set; } = new List<SeriesUser>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesWeblink> SeriesWeblinks { get; set; } = new List<SeriesWeblink>();
}
