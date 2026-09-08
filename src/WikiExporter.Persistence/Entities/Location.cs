using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Location</c>. The entity is persistence-only.</summary>
public sealed class Location
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>EnglishName</c>.</summary>
    public string? EnglishName { get; set; }
    /// <summary>Maps to <c>GermanName</c>.</summary>
    public string? GermanName { get; set; }
    /// <summary>Maps to <c>LocationID</c>.</summary>
    public string? LocationId { get; set; }
    /// <summary>Maps to <c>CountryID</c>.</summary>
    public string? CountryId { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>CountryID</c> to <c>Country</c>.</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation for FK <c>LocationID</c> to <c>Location</c>.</summary>
    public Location? Location { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<EpisodeFilmingLocation> EpisodeFilmingLocations { get; set; } = new List<EpisodeFilmingLocation>();

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<Laboratory> Laboratorys { get; set; } = new List<Laboratory>();

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<Location> Locations { get; set; } = new List<Location>();

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<MovieFilmingLocation> MovieFilmingLocations { get; set; } = new List<MovieFilmingLocation>();

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<Person> PersonLocationOfBirths { get; set; } = new List<Person>();

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<Person> PersonLocationOfDeaths { get; set; } = new List<Person>();

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<SeriesFilmingLocation> SeriesFilmingLocations { get; set; } = new List<SeriesFilmingLocation>();
}
