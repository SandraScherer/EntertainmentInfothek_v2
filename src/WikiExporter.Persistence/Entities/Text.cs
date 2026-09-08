using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Text</c>. The entity is persistence-only.</summary>
public sealed class Text
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>Content</c>.</summary>
    public string? Content { get; set; }
    /// <summary>Maps to <c>LanguageID</c>.</summary>
    public string? LanguageId { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>LanguageID</c> to <c>Language</c>.</summary>
    public Language? Language { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<BookText> BookTexts { get; set; } = new List<BookText>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<EpisodeText> EpisodeTexts { get; set; } = new List<EpisodeText>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<MovieText> MovieTexts { get; set; } = new List<MovieText>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<PersonText> PersonTexts { get; set; } = new List<PersonText>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<PublicationText> PublicationTexts { get; set; } = new List<PublicationText>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<SeriesText> SeriesTexts { get; set; } = new List<SeriesText>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<TextAuthor> TextAuthors { get; set; } = new List<TextAuthor>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<TextSource> TextSources { get; set; } = new List<TextSource>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<VideoGameText> VideoGameTexts { get; set; } = new List<VideoGameText>();
}
