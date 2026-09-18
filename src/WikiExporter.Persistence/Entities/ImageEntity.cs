using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Image</c>. The entity is persistence-only.</summary>
public sealed class ImageEntity
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>FileName</c>.</summary>
    public string? FileName { get; set; }
    /// <summary>Maps to <c>EnglishDescription</c>.</summary>
    public string? EnglishDescription { get; set; }
    /// <summary>Maps to <c>GermanDescription</c>.</summary>
    public string? GermanDescription { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<BookImageEntity> BookImages { get; set; } = new List<BookImageEntity>();

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<CertificationEntity> Certifications { get; set; } = new List<CertificationEntity>();

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<EpisodeImageEntity> EpisodeImages { get; set; } = new List<EpisodeImageEntity>();

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<ImageSourceEntity> ImageSources { get; set; } = new List<ImageSourceEntity>();

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<MovieImageEntity> MovieImages { get; set; } = new List<MovieImageEntity>();

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<SeriesImageEntity> SeriesImages { get; set; } = new List<SeriesImageEntity>();

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<VideoGameImageEntity> VideoGameImages { get; set; } = new List<VideoGameImageEntity>();
}
