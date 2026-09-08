using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Laboratory</c>. The entity is persistence-only.</summary>
public sealed class Laboratory
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalName</c>.</summary>
    public string? OriginalName { get; set; }
    /// <summary>Maps to <c>LocationID</c>.</summary>
    public string? LocationId { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>LocationID</c> to <c>Location</c>.</summary>
    public Location? Location { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this Laboratory.</summary>
    public ICollection<MovieLaboratory> MovieLaboratorys { get; set; } = new List<MovieLaboratory>();

    /// <summary>Dependent rows referencing this Laboratory.</summary>
    public ICollection<SeriesLaboratory> SeriesLaboratorys { get; set; } = new List<SeriesLaboratory>();
}
