using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Location</c>. The entity is persistence-only.</summary>
public sealed class LocationEntity
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
    public CountryEntity? CountryEntity { get; set; }

    /// <summary>Navigation for FK <c>LocationID</c> to <c>Location</c>.</summary>
    public LocationEntity? LocationEntity { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<EpisodeFilmingLocationEntity> EpisodeFilmingLocations { get; set; } = new List<EpisodeFilmingLocationEntity>();

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<LaboratoryEntity> Laboratorys { get; set; } = new List<LaboratoryEntity>();

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<LocationEntity> Locations { get; set; } = new List<LocationEntity>();

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<MovieFilmingLocationEntity> MovieFilmingLocations { get; set; } = new List<MovieFilmingLocationEntity>();

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<PersonEntity> PersonLocationOfBirths { get; set; } = new List<PersonEntity>();

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<PersonEntity> PersonLocationOfDeaths { get; set; } = new List<PersonEntity>();

    /// <summary>Dependent rows referencing this Location.</summary>
    public ICollection<SeriesFilmingLocationEntity> SeriesFilmingLocations { get; set; } = new List<SeriesFilmingLocationEntity>();
}
