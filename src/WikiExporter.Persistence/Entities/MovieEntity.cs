using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Movie</c>. The entity is persistence-only.</summary>
public sealed class MovieEntity
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

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieAspectRatioEntity> MovieAspectRatios { get; set; } = new List<MovieAspectRatioEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieAwardEntity> MovieAwards { get; set; } = new List<MovieAwardEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCameraEntity> MovieCameras { get; set; } = new List<MovieCameraEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCastEntity> MovieCasts { get; set; } = new List<MovieCastEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCertificationEntity> MovieCertifications { get; set; } = new List<MovieCertificationEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCinematographicProcessEntity> MovieCinematographicProcesss { get; set; } = new List<MovieCinematographicProcessEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieColorEntity> MovieColors { get; set; } = new List<MovieColorEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCompanyCreditsEntity> MovieCompanyCreditss { get; set; } = new List<MovieCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCountryEntity> MovieCountrys { get; set; } = new List<MovieCountryEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCrewEntity> MovieCrews { get; set; } = new List<MovieCrewEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieFilmLengthEntity> MovieFilmLengths { get; set; } = new List<MovieFilmLengthEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieFilmingDateEntity> MovieFilmingDates { get; set; } = new List<MovieFilmingDateEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieFilmingLocationEntity> MovieFilmingLocations { get; set; } = new List<MovieFilmingLocationEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieGenreEntity> MovieGenres { get; set; } = new List<MovieGenreEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieImageEntity> MovieImages { get; set; } = new List<MovieImageEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieLaboratoryEntity> MovieLaboratorys { get; set; } = new List<MovieLaboratoryEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieLanguageEntity> MovieLanguages { get; set; } = new List<MovieLanguageEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieNegativeFormatEntity> MovieNegativeFormats { get; set; } = new List<MovieNegativeFormatEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MoviePrintedFilmFormatEntity> MoviePrintedFilmFormats { get; set; } = new List<MoviePrintedFilmFormatEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieProductionDateEntity> MovieProductionDates { get; set; } = new List<MovieProductionDateEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieReleaseDateEntity> MovieReleaseDates { get; set; } = new List<MovieReleaseDateEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieRuntimeEntity> MovieRuntimes { get; set; } = new List<MovieRuntimeEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieScoreEntity> MovieScores { get; set; } = new List<MovieScoreEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieSoundMixEntity> MovieSoundMixs { get; set; } = new List<MovieSoundMixEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieTextEntity> MovieTexts { get; set; } = new List<MovieTextEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieUserEntity> MovieUsers { get; set; } = new List<MovieUserEntity>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieWeblinkEntity> MovieWeblinks { get; set; } = new List<MovieWeblinkEntity>();
}
