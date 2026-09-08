using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Episode_Certification</c>. The entity is persistence-only.</summary>
public sealed class EpisodeCertification
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>EpisodeID</c>.</summary>
    public string? EpisodeId { get; set; }
    /// <summary>Maps to <c>CertificationID</c>.</summary>
    public string? CertificationId { get; set; }
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

    /// <summary>Navigation for FK <c>CertificationID</c> to <c>Certification</c>.</summary>
    public Certification? Certification { get; set; }

    /// <summary>Navigation for FK <c>EpisodeID</c> to <c>Episode</c>.</summary>
    public Episode? Episode { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }
}
