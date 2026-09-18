using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Certification</c>. The entity is persistence-only.</summary>
public sealed class CertificationEntity
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
    public CountryEntity? CountryEntity { get; set; }

    /// <summary>Navigation for FK <c>ImageID</c> to <c>Image</c>.</summary>
    public ImageEntity? ImageEntity { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this Certification.</summary>
    public ICollection<EpisodeCertificationEntity> EpisodeCertifications { get; set; } = new List<EpisodeCertificationEntity>();

    /// <summary>Dependent rows referencing this Certification.</summary>
    public ICollection<MovieCertificationEntity> MovieCertifications { get; set; } = new List<MovieCertificationEntity>();

    /// <summary>Dependent rows referencing this Certification.</summary>
    public ICollection<PublicationCertificationEntity> PublicationCertifications { get; set; } = new List<PublicationCertificationEntity>();

    /// <summary>Dependent rows referencing this Certification.</summary>
    public ICollection<SeriesCertificationEntity> SeriesCertifications { get; set; } = new List<SeriesCertificationEntity>();

    /// <summary>Dependent rows referencing this Certification.</summary>
    public ICollection<VideoGameCertificationEntity> VideoGameCertifications { get; set; } = new List<VideoGameCertificationEntity>();
}
