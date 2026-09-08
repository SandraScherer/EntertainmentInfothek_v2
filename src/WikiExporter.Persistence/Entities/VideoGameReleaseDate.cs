using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>VideoGame_ReleaseDate</c>. The entity is persistence-only.</summary>
public sealed class VideoGameReleaseDate
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>VideoGameID</c>.</summary>
    public string? VideoGameId { get; set; }
    /// <summary>Maps to <c>ReleaseDate</c>.</summary>
    public string? ReleaseDate { get; set; }
    /// <summary>Maps to <c>PlatformID</c>.</summary>
    public string? PlatformId { get; set; }
    /// <summary>Maps to <c>EnglishDescription</c>.</summary>
    public string? EnglishDescription { get; set; }
    /// <summary>Maps to <c>GermanDescription</c>.</summary>
    public string? GermanDescription { get; set; }
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

    /// <summary>Navigation for FK <c>PlatformID</c> to <c>Platform</c>.</summary>
    public Platform? Platform { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation for FK <c>VideoGameID</c> to <c>VideoGame</c>.</summary>
    public VideoGame? VideoGame { get; set; }
}
