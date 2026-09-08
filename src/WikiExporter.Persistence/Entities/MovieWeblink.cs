using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Movie_Weblink</c>. The entity is persistence-only.</summary>
public sealed class MovieWeblink
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>MovieID</c>.</summary>
    public string? MovieId { get; set; }
    /// <summary>Maps to <c>WeblinkID</c>.</summary>
    public string? WeblinkId { get; set; }
    /// <summary>Maps to <c>Order</c>.</summary>
    public string? Order { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>MovieID</c> to <c>Movie</c>.</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation for FK <c>WeblinkID</c> to <c>Weblink</c>.</summary>
    public Weblink? Weblink { get; set; }
}
