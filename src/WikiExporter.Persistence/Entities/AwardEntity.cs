using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Award</c>. The entity is persistence-only.</summary>
public sealed class AwardEntity
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
    public CompanyEntity? Presenter { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this Award.</summary>
    public ICollection<BookAwardEntity> BookAwards { get; set; } = new List<BookAwardEntity>();

    /// <summary>Dependent rows referencing this Award.</summary>
    public ICollection<EpisodeAwardEntity> EpisodeAwards { get; set; } = new List<EpisodeAwardEntity>();

    /// <summary>Dependent rows referencing this Award.</summary>
    public ICollection<MovieAwardEntity> MovieAwards { get; set; } = new List<MovieAwardEntity>();

    /// <summary>Dependent rows referencing this Award.</summary>
    public ICollection<SeriesAwardEntity> SeriesAwards { get; set; } = new List<SeriesAwardEntity>();

    /// <summary>Dependent rows referencing this Award.</summary>
    public ICollection<VideoGameAwardEntity> VideoGameAwards { get; set; } = new List<VideoGameAwardEntity>();
}
