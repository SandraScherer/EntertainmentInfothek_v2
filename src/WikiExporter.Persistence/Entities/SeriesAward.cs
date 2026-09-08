using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Series_Award</c>. The entity is persistence-only.</summary>
public sealed class SeriesAward
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>SeriesID</c>.</summary>
    public string? SeriesId { get; set; }
    /// <summary>Maps to <c>AwardID</c>.</summary>
    public string? AwardId { get; set; }
    /// <summary>Maps to <c>Category</c>.</summary>
    public string? Category { get; set; }
    /// <summary>Maps to <c>Date</c>.</summary>
    public string? Date { get; set; }
    /// <summary>Maps to <c>Winner</c>.</summary>
    public string? Winner { get; set; }
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

    /// <summary>Navigation for FK <c>AwardID</c> to <c>Award</c>.</summary>
    public Award? Award { get; set; }

    /// <summary>Navigation for FK <c>SeriesID</c> to <c>Series</c>.</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this SeriesAward.</summary>
    public ICollection<SeriesAwardPerson> SeriesAwardPersons { get; set; } = new List<SeriesAwardPerson>();
}
