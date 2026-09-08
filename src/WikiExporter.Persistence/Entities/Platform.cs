using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Platform</c>. The entity is persistence-only.</summary>
public sealed class Platform
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
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<TechnicalSpecification> TechnicalSpecifications { get; set; } = new List<TechnicalSpecification>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<Version> Versions { get; set; } = new List<Version>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VideoGameCompanyCredits> VideoGameCompanyCreditss { get; set; } = new List<VideoGameCompanyCredits>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VideoGameCompletion> VideoGameCompletions { get; set; } = new List<VideoGameCompletion>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VideoGameDifficulty> VideoGameDifficultys { get; set; } = new List<VideoGameDifficulty>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VideoGamePerspective> VideoGamePerspectives { get; set; } = new List<VideoGamePerspective>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VideoGameReleaseDate> VideoGameReleaseDates { get; set; } = new List<VideoGameReleaseDate>();

    /// <summary>Dependent rows referencing this Platform.</summary>
    public ICollection<VideoGameScore> VideoGameScores { get; set; } = new List<VideoGameScore>();
}
