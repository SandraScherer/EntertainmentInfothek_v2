using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Language</c>. The entity is persistence-only.</summary>
public sealed class LanguageEntity
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
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<BookLanguageEntity> BookLanguages { get; set; } = new List<BookLanguageEntity>();

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<MovieLanguageEntity> MovieLanguages { get; set; } = new List<MovieLanguageEntity>();

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<PublicationLanguageEntity> PublicationLanguages { get; set; } = new List<PublicationLanguageEntity>();

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<SeriesLanguageEntity> SeriesLanguages { get; set; } = new List<SeriesLanguageEntity>();

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<TextEntity> Texts { get; set; } = new List<TextEntity>();

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<VideoGameLanguageEntity> VideoGameLanguages { get; set; } = new List<VideoGameLanguageEntity>();

    /// <summary>Dependent rows referencing this Language.</summary>
    public ICollection<WeblinkEntity> Weblinks { get; set; } = new List<WeblinkEntity>();
}
