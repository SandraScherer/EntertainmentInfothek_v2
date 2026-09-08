using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Type</c>. The entity is persistence-only.</summary>
public sealed class Type
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

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<Book> Books { get; set; } = new List<Book>();

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<Company> Companys { get; set; } = new List<Company>();

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<Person> Persons { get; set; } = new List<Person>();

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<Series> Seriess { get; set; } = new List<Series>();

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<Version> Versions { get; set; } = new List<Version>();

    /// <summary>Dependent rows referencing this Type.</summary>
    public ICollection<VideoGame> VideoGames { get; set; } = new List<VideoGame>();
}
