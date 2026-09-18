using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Weblink</c>. The entity is persistence-only.</summary>
public sealed class WeblinkEntity
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>URL</c>.</summary>
    public string? URL { get; set; }
    /// <summary>Maps to <c>EnglishName</c>.</summary>
    public string? EnglishName { get; set; }
    /// <summary>Maps to <c>GermanName</c>.</summary>
    public string? GermanName { get; set; }
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

    /// <summary>Dependent rows referencing this Weblink.</summary>
    public ICollection<BookWeblinkEntity> BookWeblinks { get; set; } = new List<BookWeblinkEntity>();

    /// <summary>Dependent rows referencing this Weblink.</summary>
    public ICollection<MovieWeblinkEntity> MovieWeblinks { get; set; } = new List<MovieWeblinkEntity>();

    /// <summary>Dependent rows referencing this Weblink.</summary>
    public ICollection<PersonWeblinkEntity> PersonWeblinks { get; set; } = new List<PersonWeblinkEntity>();

    /// <summary>Dependent rows referencing this Weblink.</summary>
    public ICollection<SeriesWeblinkEntity> SeriesWeblinks { get; set; } = new List<SeriesWeblinkEntity>();

    /// <summary>Dependent rows referencing this Weblink.</summary>
    public ICollection<VideoGameWeblinkEntity> VideoGameWeblinks { get; set; } = new List<VideoGameWeblinkEntity>();
}
