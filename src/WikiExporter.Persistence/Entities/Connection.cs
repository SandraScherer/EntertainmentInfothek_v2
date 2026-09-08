using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Connection</c>. The entity is persistence-only.</summary>
public sealed class Connection
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
    public Connection? Connection { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this Connection.</summary>
    public ICollection<Book> Books { get; set; } = new List<Book>();

    /// <summary>Dependent rows referencing this Connection.</summary>
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    /// <summary>Dependent rows referencing this Connection.</summary>
    public ICollection<Series> Seriess { get; set; } = new List<Series>();

    /// <summary>Dependent rows referencing this Connection.</summary>
    public ICollection<VideoGame> VideoGames { get; set; } = new List<VideoGame>();

    /// <summary>Dependent rows referencing this Connection.</summary>
    public ICollection<Connection> ChildConnections { get; set; } = new List<Connection>();
}
