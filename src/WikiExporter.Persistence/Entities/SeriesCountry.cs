using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Series_Country</c>. The entity is persistence-only.</summary>
public sealed class SeriesCountry
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>SeriesID</c>.</summary>
    public string? SeriesId { get; set; }
    /// <summary>Maps to <c>CountryID</c>.</summary>
    public string? CountryId { get; set; }
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

    /// <summary>Navigation for FK <c>CountryID</c> to <c>Country</c>.</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation for FK <c>SeriesID</c> to <c>Series</c>.</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }
}
