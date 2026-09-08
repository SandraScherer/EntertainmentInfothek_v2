using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>TechnicalSpecification_RequiredInputDevice</c>. The entity is persistence-only.</summary>
public sealed class TechnicalSpecificationRequiredInputDevice
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>TechnicalSpecificationID</c>.</summary>
    public string? TechnicalSpecificationId { get; set; }
    /// <summary>Maps to <c>InputDeviceID</c>.</summary>
    public string? InputDeviceId { get; set; }
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

    /// <summary>Navigation for FK <c>InputDeviceID</c> to <c>InputDevice</c>.</summary>
    public InputDevice? InputDevice { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation for FK <c>TechnicalSpecificationID</c> to <c>TechnicalSpecification</c>.</summary>
    public TechnicalSpecification? TechnicalSpecification { get; set; }
}
