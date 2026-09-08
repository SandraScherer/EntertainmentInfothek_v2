using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Award</c>. The entity is persistence-only.</summary>
public sealed class Award
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalName</c>.</summary>
    public string? OriginalName { get; set; }
    /// <summary>Maps to <c>PresenterID</c>.</summary>
    public string? PresenterId { get; set; }
    /// <summary>Maps to <c>EnglishRole</c>.</summary>
    public string? EnglishRole { get; set; }
    /// <summary>Maps to <c>GermanRole</c>.</summary>
    public string? GermanRole { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>PresenterID</c> to <c>Company</c>.</summary>
    public Company? Presenter { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this Award.</summary>
    public ICollection<BookAward> BookAwards { get; set; } = new List<BookAward>();

    /// <summary>Dependent rows referencing this Award.</summary>
    public ICollection<EpisodeAward> EpisodeAwards { get; set; } = new List<EpisodeAward>();

    /// <summary>Dependent rows referencing this Award.</summary>
    public ICollection<MovieAward> MovieAwards { get; set; } = new List<MovieAward>();

    /// <summary>Dependent rows referencing this Award.</summary>
    public ICollection<SeriesAward> SeriesAwards { get; set; } = new List<SeriesAward>();

    /// <summary>Dependent rows referencing this Award.</summary>
    public ICollection<VideoGameAward> VideoGameAwards { get; set; } = new List<VideoGameAward>();
}
