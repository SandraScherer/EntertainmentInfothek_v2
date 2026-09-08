using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>TechnicalSpecification_SupportedDriver</c>. The entity is persistence-only.</summary>
public sealed class TechnicalSpecificationSupportedDriver
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>TechnicalSpecificationID</c>.</summary>
    public string? TechnicalSpecificationId { get; set; }
    /// <summary>Maps to <c>DriverID</c>.</summary>
    public string? DriverId { get; set; }
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

    /// <summary>Navigation for FK <c>DriverID</c> to <c>Driver</c>.</summary>
    public Driver? Driver { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation for FK <c>TechnicalSpecificationID</c> to <c>TechnicalSpecification</c>.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }
}
