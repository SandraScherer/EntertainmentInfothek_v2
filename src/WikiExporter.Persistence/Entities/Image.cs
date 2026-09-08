using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Image</c>. The entity is persistence-only.</summary>
public sealed class Image
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
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<BookImage> BookImages { get; set; } = new List<BookImage>();

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<EpisodeImage> EpisodeImages { get; set; } = new List<EpisodeImage>();

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<ImageSource> ImageSources { get; set; } = new List<ImageSource>();

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<MovieImage> MovieImages { get; set; } = new List<MovieImage>();

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<SeriesImage> SeriesImages { get; set; } = new List<SeriesImage>();

    /// <summary>Dependent rows referencing this Image.</summary>
    public ICollection<VideoGameImage> VideoGameImages { get; set; } = new List<VideoGameImage>();
}
