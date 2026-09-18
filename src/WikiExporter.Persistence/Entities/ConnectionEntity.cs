using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Connection</c>. The entity is persistence-only.</summary>
public sealed class ConnectionEntity
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalName</c>.</summary>
    public string? OriginalName { get; set; }
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

    /// <summary>Navigation for FK <c>ConnectionID</c> to <c>Connection</c>.</summary>
    public ConnectionEntity? ParentConnection { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this Connection.</summary>
    public ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();

    /// <summary>Dependent rows referencing this Connection.</summary>
    public ICollection<MovieEntity> Movies { get; set; } = new List<MovieEntity>();

    /// <summary>Dependent rows referencing this Connection.</summary>
    public ICollection<SeriesEntity> Seriess { get; set; } = new List<SeriesEntity>();

    /// <summary>Dependent rows referencing this Connection.</summary>
    public ICollection<VideoGameEntity> VideoGames { get; set; } = new List<VideoGameEntity>();

    /// <summary>Dependent rows referencing this Connection.</summary>
    public ICollection<ConnectionEntity> ChildConnections { get; set; } = new List<ConnectionEntity>();
}
