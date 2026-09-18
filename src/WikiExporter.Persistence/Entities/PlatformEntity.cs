using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Platform</c>. The entity is persistence-only.</summary>
public sealed class PlatformEntity
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalName</c>.</summary>
    public string? OriginalName { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<TechnicalSpecificationEntity> TechnicalSpecifications { get; set; } = new List<TechnicalSpecificationEntity>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VersionEntity> Versions { get; set; } = new List<VersionEntity>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VideoGameCompanyCreditsEntity> VideoGameCompanyCreditss { get; set; } = new List<VideoGameCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VideoGameCompletionEntity> VideoGameCompletions { get; set; } = new List<VideoGameCompletionEntity>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VideoGameDifficultyEntity> VideoGameDifficultys { get; set; } = new List<VideoGameDifficultyEntity>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VideoGamePerspectiveEntity> VideoGamePerspectives { get; set; } = new List<VideoGamePerspectiveEntity>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VideoGameReleaseDateEntity> VideoGameReleaseDates { get; set; } = new List<VideoGameReleaseDateEntity>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VideoGameScoreEntity> VideoGameScores { get; set; } = new List<VideoGameScoreEntity>();
}
