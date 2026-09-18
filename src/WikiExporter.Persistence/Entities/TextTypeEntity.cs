using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>TextType</c>. The entity is persistence-only.</summary>
public sealed class TextTypeEntity
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
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<BookTextEntity> BookTexts { get; set; } = new List<BookTextEntity>();

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<EpisodeTextEntity> EpisodeTexts { get; set; } = new List<EpisodeTextEntity>();

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<MovieTextEntity> MovieTexts { get; set; } = new List<MovieTextEntity>();

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<PersonTextEntity> PersonTexts { get; set; } = new List<PersonTextEntity>();

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<PublicationTextEntity> PublicationTexts { get; set; } = new List<PublicationTextEntity>();

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<SeriesTextEntity> SeriesTexts { get; set; } = new List<SeriesTextEntity>();

    /// <summary>Dependent rows referencing this TextType.</summary>
    public ICollection<VideoGameTextEntity> VideoGameTexts { get; set; } = new List<VideoGameTextEntity>();
}
