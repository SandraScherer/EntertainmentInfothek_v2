using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Language</c>. The entity is persistence-only.</summary>
public sealed class Language
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalName</c>.</summary>
    public string? OriginalName { get; set; }
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

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<BookLanguage> BookLanguages { get; set; } = new List<BookLanguage>();

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<MovieLanguage> MovieLanguages { get; set; } = new List<MovieLanguage>();

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<PublicationLanguage> PublicationLanguages { get; set; } = new List<PublicationLanguage>();

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<SeriesLanguage> SeriesLanguages { get; set; } = new List<SeriesLanguage>();

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<Text> Texts { get; set; } = new List<Text>();

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<VideoGameLanguage> VideoGameLanguages { get; set; } = new List<VideoGameLanguage>();

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<Weblink> Weblinks { get; set; } = new List<Weblink>();
}
