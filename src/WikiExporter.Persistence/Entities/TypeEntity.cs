using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Type</c>. The entity is persistence-only.</summary>
public sealed class TypeEntity
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

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<CompanyEntity> Companys { get; set; } = new List<CompanyEntity>();

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<MovieEntity> Movies { get; set; } = new List<MovieEntity>();

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<PersonEntity> Persons { get; set; } = new List<PersonEntity>();

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<SeriesEntity> Seriess { get; set; } = new List<SeriesEntity>();

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<VersionEntity> Versions { get; set; } = new List<VersionEntity>();

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<VideoGameEntity> VideoGames { get; set; } = new List<VideoGameEntity>();
}
