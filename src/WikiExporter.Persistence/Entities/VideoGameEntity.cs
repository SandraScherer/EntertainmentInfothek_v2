using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>VideoGame</c>. The entity is persistence-only.</summary>
public sealed class VideoGameEntity
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

    /// <summary>Navigation for FK <c>CrewStatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? CrewStatus { get; set; }

    /// <summary>Navigation for FK <c>ConnectionID</c> to <c>Connection</c>.</summary>
    public ConnectionEntity? ConnectionEntity { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Navigation for FK <c>TypeID</c> to <c>Type</c>.</summary>
    public TypeEntity? TypeEntity { get; set; }

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<TechnicalSpecificationEntity> TechnicalSpecifications { get; set; } = new List<TechnicalSpecificationEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameAwardEntity> VideoGameAwards { get; set; } = new List<VideoGameAwardEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameCastEntity> VideoGameCasts { get; set; } = new List<VideoGameCastEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameCertificationEntity> VideoGameCertifications { get; set; } = new List<VideoGameCertificationEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameCompanyCreditsEntity> VideoGameCompanyCreditss { get; set; } = new List<VideoGameCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameCompletionEntity> VideoGameCompletions { get; set; } = new List<VideoGameCompletionEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameCrewEntity> VideoGameCrews { get; set; } = new List<VideoGameCrewEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameDifficultyEntity> VideoGameDifficultys { get; set; } = new List<VideoGameDifficultyEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameGenreEntity> VideoGameGenres { get; set; } = new List<VideoGameGenreEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameImageEntity> VideoGameImages { get; set; } = new List<VideoGameImageEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameLanguageEntity> VideoGameLanguages { get; set; } = new List<VideoGameLanguageEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGamePerspectiveEntity> VideoGamePerspectives { get; set; } = new List<VideoGamePerspectiveEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameReleaseDateEntity> VideoGameReleaseDates { get; set; } = new List<VideoGameReleaseDateEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameScoreEntity> VideoGameScores { get; set; } = new List<VideoGameScoreEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameSettingEntity> VideoGameSettings { get; set; } = new List<VideoGameSettingEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameTextEntity> VideoGameTexts { get; set; } = new List<VideoGameTextEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameUserEntity> VideoGameUsers { get; set; } = new List<VideoGameUserEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameVersionEntity> VideoGameVersions { get; set; } = new List<VideoGameVersionEntity>();

    /// <summary>Dependent rows referencing this VideoGame.</summary>
    public ICollection<VideoGameWeblinkEntity> VideoGameWeblinks { get; set; } = new List<VideoGameWeblinkEntity>();
}
