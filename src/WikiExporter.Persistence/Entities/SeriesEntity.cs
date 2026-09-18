using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Series</c>. The entity is persistence-only.</summary>
public sealed class SeriesEntity
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
    public StatusEntity? CastStatus { get; set; }

    /// <summary>Navigation for FK <c>ConnectionID</c> to <c>Connection</c>.</summary>
    public ConnectionEntity? ConnectionEntity { get; set; }

    /// <summary>Navigation for FK <c>CrewStatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? CrewStatus { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Navigation for FK <c>TypeID</c> to <c>Type</c>.</summary>
    public TypeEntity? TypeEntity { get; set; }

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<EpisodeEntity> Episodes { get; set; } = new List<EpisodeEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesAspectRatioEntity> SeriesAspectRatios { get; set; } = new List<SeriesAspectRatioEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesAwardEntity> SeriesAwards { get; set; } = new List<SeriesAwardEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCameraEntity> SeriesCameras { get; set; } = new List<SeriesCameraEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCastEntity> SeriesCasts { get; set; } = new List<SeriesCastEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCertificationEntity> SeriesCertifications { get; set; } = new List<SeriesCertificationEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCinematographicProcessEntity> SeriesCinematographicProcesss { get; set; } = new List<SeriesCinematographicProcessEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesColorEntity> SeriesColors { get; set; } = new List<SeriesColorEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCompanyCreditsEntity> SeriesCompanyCreditss { get; set; } = new List<SeriesCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCountryEntity> SeriesCountrys { get; set; } = new List<SeriesCountryEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesCrewEntity> SeriesCrews { get; set; } = new List<SeriesCrewEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesFilmLengthEntity> SeriesFilmLengths { get; set; } = new List<SeriesFilmLengthEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesFilmingDateEntity> SeriesFilmingDates { get; set; } = new List<SeriesFilmingDateEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesFilmingLocationEntity> SeriesFilmingLocations { get; set; } = new List<SeriesFilmingLocationEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesGenreEntity> SeriesGenres { get; set; } = new List<SeriesGenreEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesImageEntity> SeriesImages { get; set; } = new List<SeriesImageEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesLaboratoryEntity> SeriesLaboratorys { get; set; } = new List<SeriesLaboratoryEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesLanguageEntity> SeriesLanguages { get; set; } = new List<SeriesLanguageEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesNegativeFormatEntity> SeriesNegativeFormats { get; set; } = new List<SeriesNegativeFormatEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesPrintedFilmFormatEntity> SeriesPrintedFilmFormats { get; set; } = new List<SeriesPrintedFilmFormatEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesProductionDateEntity> SeriesProductionDates { get; set; } = new List<SeriesProductionDateEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesReleaseDateFirstEpisodeEntity> SeriesReleaseDateFirstEpisodes { get; set; } = new List<SeriesReleaseDateFirstEpisodeEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesReleaseDateLastEpisodeEntity> SeriesReleaseDateLastEpisodes { get; set; } = new List<SeriesReleaseDateLastEpisodeEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesRuntimeEntity> SeriesRuntimes { get; set; } = new List<SeriesRuntimeEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesScoreEntity> SeriesScores { get; set; } = new List<SeriesScoreEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesSoundMixEntity> SeriesSoundMixs { get; set; } = new List<SeriesSoundMixEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesTextEntity> SeriesTexts { get; set; } = new List<SeriesTextEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesUserEntity> SeriesUsers { get; set; } = new List<SeriesUserEntity>();

    /// <summary>Dependent rows referencing this Series.</summary>
    public ICollection<SeriesWeblinkEntity> SeriesWeblinks { get; set; } = new List<SeriesWeblinkEntity>();
}
