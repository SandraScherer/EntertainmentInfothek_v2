using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>TextType</c>. The entity is persistence-only.</summary>
public sealed class TextType
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>EnglishName</c>.</summary>
    public string? EnglishName { get; set; }
    /// <summary>Maps to <c>GermanName</c>.</summary>
    public string? GermanName { get; set; }
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

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<BookText> BookTexts { get; set; } = new List<BookText>();

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<EpisodeText> EpisodeTexts { get; set; } = new List<EpisodeText>();

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<MovieText> MovieTexts { get; set; } = new List<MovieText>();

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<PersonText> PersonTexts { get; set; } = new List<PersonText>();

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<PublicationText> PublicationTexts { get; set; } = new List<PublicationText>();

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<SeriesText> SeriesTexts { get; set; } = new List<SeriesText>();

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<VideoGameText> VideoGameTexts { get; set; } = new List<VideoGameText>();
}
