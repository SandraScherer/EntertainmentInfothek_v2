using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Text</c>. The entity is persistence-only.</summary>
public sealed class TextEntity
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
    public LanguageEntity? LanguageEntity { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<BookTextEntity> BookTexts { get; set; } = new List<BookTextEntity>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<EpisodeTextEntity> EpisodeTexts { get; set; } = new List<EpisodeTextEntity>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<MovieTextEntity> MovieTexts { get; set; } = new List<MovieTextEntity>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<PersonTextEntity> PersonTexts { get; set; } = new List<PersonTextEntity>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<PublicationTextEntity> PublicationTexts { get; set; } = new List<PublicationTextEntity>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<SeriesTextEntity> SeriesTexts { get; set; } = new List<SeriesTextEntity>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<TextAuthorEntity> TextAuthors { get; set; } = new List<TextAuthorEntity>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<TextSourceEntity> TextSources { get; set; } = new List<TextSourceEntity>();

    /// <summary>Dependent rows referencing this Text.</summary>
    public ICollection<VideoGameTextEntity> VideoGameTexts { get; set; } = new List<VideoGameTextEntity>();
}
