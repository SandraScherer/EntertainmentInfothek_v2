using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>AspectRatio</c>. The entity is persistence-only.</summary>
public sealed class AspectRatio
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalName</c>.</summary>
    public string? OriginalName { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this AspectRatio.</summary>
    public ICollection<MovieAspectRatio> MovieAspectRatios { get; set; } = new List<MovieAspectRatio>();

    /// <summary>Dependent rows referencing this AspectRatio.</summary>
    public ICollection<SeriesAspectRatio> SeriesAspectRatios { get; set; } = new List<SeriesAspectRatio>();
}
