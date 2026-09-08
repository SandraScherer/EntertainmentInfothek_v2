using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Certification</c>. The entity is persistence-only.</summary>
public sealed class Certification
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalName</c>.</summary>
    public string? OriginalName { get; set; }
    /// <summary>Maps to <c>ImageID</c>.</summary>
    public string? ImageId { get; set; }
    /// <summary>Maps to <c>CountryID</c>.</summary>
    public string? CountryId { get; set; }
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

    /// <summary>Navigation for FK <c>ImageID</c> to <c>Image</c>.</summary>
    public Image? Image { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this Certification.</summary>
    public ICollection<EpisodeCertification> EpisodeCertifications { get; set; } = new List<EpisodeCertification>();

    /// <summary>Dependent rows referencing this Certification.</summary>
    public ICollection<MovieCertification> MovieCertifications { get; set; } = new List<MovieCertification>();

    /// <summary>Dependent rows referencing this Certification.</summary>
    public ICollection<PublicationCertification> PublicationCertifications { get; set; } = new List<PublicationCertification>();

    /// <summary>Dependent rows referencing this Certification.</summary>
    public ICollection<SeriesCertification> SeriesCertifications { get; set; } = new List<SeriesCertification>();

    /// <summary>Dependent rows referencing this Certification.</summary>
    public ICollection<VideoGameCertification> VideoGameCertifications { get; set; } = new List<VideoGameCertification>();
}
