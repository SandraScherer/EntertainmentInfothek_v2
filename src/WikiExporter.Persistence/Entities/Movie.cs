using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Movie</c>. The entity is persistence-only.</summary>
public sealed class Movie
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
    public Status? CastStatus { get; set; }

    /// <summary>Navigation for FK <c>ConnectionID</c> to <c>Connection</c>.</summary>
    public Connection? Connection { get; set; }

    /// <summary>Navigation for FK <c>CrewStatusID</c> to <c>Status</c>.</summary>
    public Status? CrewStatus { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation for FK <c>TypeID</c> to <c>Type</c>.</summary>
    public Type? Type { get; set; }

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieAspectRatio> MovieAspectRatios { get; set; } = new List<MovieAspectRatio>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieAward> MovieAwards { get; set; } = new List<MovieAward>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCamera> MovieCameras { get; set; } = new List<MovieCamera>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCertification> MovieCertifications { get; set; } = new List<MovieCertification>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCinematographicProcess> MovieCinematographicProcesss { get; set; } = new List<MovieCinematographicProcess>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieColor> MovieColors { get; set; } = new List<MovieColor>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCompanyCredits> MovieCompanyCreditss { get; set; } = new List<MovieCompanyCredits>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCountry> MovieCountrys { get; set; } = new List<MovieCountry>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieCrew> MovieCrews { get; set; } = new List<MovieCrew>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieFilmLength> MovieFilmLengths { get; set; } = new List<MovieFilmLength>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieFilmingDate> MovieFilmingDates { get; set; } = new List<MovieFilmingDate>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieFilmingLocation> MovieFilmingLocations { get; set; } = new List<MovieFilmingLocation>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieImage> MovieImages { get; set; } = new List<MovieImage>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieLaboratory> MovieLaboratorys { get; set; } = new List<MovieLaboratory>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieLanguage> MovieLanguages { get; set; } = new List<MovieLanguage>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieNegativeFormat> MovieNegativeFormats { get; set; } = new List<MovieNegativeFormat>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MoviePrintedFilmFormat> MoviePrintedFilmFormats { get; set; } = new List<MoviePrintedFilmFormat>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieProductionDate> MovieProductionDates { get; set; } = new List<MovieProductionDate>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieReleaseDate> MovieReleaseDates { get; set; } = new List<MovieReleaseDate>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieRuntime> MovieRuntimes { get; set; } = new List<MovieRuntime>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieScore> MovieScores { get; set; } = new List<MovieScore>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieSoundMix> MovieSoundMixs { get; set; } = new List<MovieSoundMix>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieText> MovieTexts { get; set; } = new List<MovieText>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieUser> MovieUsers { get; set; } = new List<MovieUser>();

    /// <summary>Dependent rows referencing this Movie.</summary>
    public ICollection<MovieWeblink> MovieWeblinks { get; set; } = new List<MovieWeblink>();
}
