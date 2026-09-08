using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>VideoGame</c>. The entity is persistence-only.</summary>
public sealed class VideoGame
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

    /// <summary>Navigation for FK <c>CrewStatusID</c> to <c>Status</c>.</summary>
    public Status? CrewStatus { get; set; }

    /// <summary>Navigation for FK <c>ConnectionID</c> to <c>Connection</c>.</summary>
    public Connection? Connection { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation for FK <c>TypeID</c> to <c>Type</c>.</summary>
    public Type? Type { get; set; }

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<TechnicalSpecification> TechnicalSpecifications { get; set; } = new List<TechnicalSpecification>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameAward> VideoGameAwards { get; set; } = new List<VideoGameAward>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameCast> VideoGameCasts { get; set; } = new List<VideoGameCast>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameCertification> VideoGameCertifications { get; set; } = new List<VideoGameCertification>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameCompanyCredits> VideoGameCompanyCreditss { get; set; } = new List<VideoGameCompanyCredits>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameCompletion> VideoGameCompletions { get; set; } = new List<VideoGameCompletion>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameCrew> VideoGameCrews { get; set; } = new List<VideoGameCrew>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameDifficulty> VideoGameDifficultys { get; set; } = new List<VideoGameDifficulty>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameGenre> VideoGameGenres { get; set; } = new List<VideoGameGenre>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameImage> VideoGameImages { get; set; } = new List<VideoGameImage>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameLanguage> VideoGameLanguages { get; set; } = new List<VideoGameLanguage>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGamePerspective> VideoGamePerspectives { get; set; } = new List<VideoGamePerspective>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameReleaseDate> VideoGameReleaseDates { get; set; } = new List<VideoGameReleaseDate>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameScore> VideoGameScores { get; set; } = new List<VideoGameScore>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameSetting> VideoGameSettings { get; set; } = new List<VideoGameSetting>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameText> VideoGameTexts { get; set; } = new List<VideoGameText>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameUser> VideoGameUsers { get; set; } = new List<VideoGameUser>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameVersion> VideoGameVersions { get; set; } = new List<VideoGameVersion>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameWeblink> VideoGameWeblinks { get; set; } = new List<VideoGameWeblink>();
}
