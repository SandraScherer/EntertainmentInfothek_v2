using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Episode_Runtime</c>. The entity is persistence-only.</summary>
public sealed class EpisodeRuntime
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>EpisodeID</c>.</summary>
    public string? EpisodeId { get; set; }
    /// <summary>Maps to <c>Runtime</c>.</summary>
    public string? Runtime { get; set; }
    /// <summary>Maps to <c>EditionID</c>.</summary>
    public string? EditionId { get; set; }
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

    /// <summary>Navigation for FK <c>EditionID</c> to <c>Edition</c>.</summary>
    public Edition? Edition { get; set; }

    /// <summary>Navigation for FK <c>EpisodeID</c> to <c>Episode</c>.</summary>
    public Episode? Episode { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }
}
