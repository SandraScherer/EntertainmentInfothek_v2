using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Priority</c>. The entity is persistence-only.</summary>
public sealed class PriorityEntity
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>EnglishName</c>.</summary>
    public string? EnglishName { get; set; }
    /// <summary>Maps to <c>GermanName</c>.</summary>
    public string? GermanName { get; set; }
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

    /// <summary>Dependent rows referencing this Priority.</summary>
    public ICollection<BookUserEntity> BookUsers { get; set; } = new List<BookUserEntity>();

    /// <summary>Dependent rows referencing this Priority.</summary>
    public ICollection<MovieUserEntity> MovieUsers { get; set; } = new List<MovieUserEntity>();

    /// <summary>Dependent rows referencing this Priority.</summary>
    public ICollection<SeriesUserEntity> SeriesUsers { get; set; } = new List<SeriesUserEntity>();

    /// <summary>Dependent rows referencing this Priority.</summary>
    public ICollection<VideoGameUserEntity> VideoGameUsers { get; set; } = new List<VideoGameUserEntity>();
}
