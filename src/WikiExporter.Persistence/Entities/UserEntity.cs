using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>User</c>. The entity is persistence-only.</summary>
public sealed class UserEntity
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalName</c>.</summary>
    public string? OriginalName { get; set; }
    /// <summary>Maps to <c>EMail</c>.</summary>
    public string? EMail { get; set; }
    /// <summary>Maps to <c>PersonID</c>.</summary>
    public string? PersonId { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>PersonID</c> to <c>Person</c>.</summary>
    public PersonEntity? PersonEntity { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this User.</summary>
    public ICollection<BookUserEntity> BookUsers { get; set; } = new List<BookUserEntity>();

    /// <summary>Dependent rows referencing this User.</summary>
    public ICollection<MovieUserEntity> MovieUsers { get; set; } = new List<MovieUserEntity>();

    /// <summary>Dependent rows referencing this User.</summary>
    public ICollection<SeriesUserEntity> SeriesUsers { get; set; } = new List<SeriesUserEntity>();

    /// <summary>Dependent rows referencing this User.</summary>
    public ICollection<VideoGameUserEntity> VideoGameUsers { get; set; } = new List<VideoGameUserEntity>();
}
