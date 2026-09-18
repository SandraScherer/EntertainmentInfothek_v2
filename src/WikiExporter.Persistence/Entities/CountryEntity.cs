using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Country</c>. The entity is persistence-only.</summary>
public sealed class CountryEntity
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalShortName</c>.</summary>
    public string? OriginalShortName { get; set; }
    /// <summary>Maps to <c>OriginalName</c>.</summary>
    public string? OriginalName { get; set; }
    /// <summary>Maps to <c>EnglishShortName</c>.</summary>
    public string? EnglishShortName { get; set; }
    /// <summary>Maps to <c>EnglishName</c>.</summary>
    public string? EnglishName { get; set; }
    /// <summary>Maps to <c>GermanShortName</c>.</summary>
    public string? GermanShortName { get; set; }
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

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<CertificationEntity> Certifications { get; set; } = new List<CertificationEntity>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<EpisodeCompanyCreditsEntity> EpisodeCompanyCreditss { get; set; } = new List<EpisodeCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<LocationEntity> Locations { get; set; } = new List<LocationEntity>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<MovieCompanyCreditsEntity> MovieCompanyCreditss { get; set; } = new List<MovieCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<MovieCountryEntity> MovieCountrys { get; set; } = new List<MovieCountryEntity>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<PublicationCompanyCreditsEntity> PublicationCompanyCreditss { get; set; } = new List<PublicationCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<SeriesCompanyCreditsEntity> SeriesCompanyCreditss { get; set; } = new List<SeriesCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<SeriesCountryEntity> SeriesCountrys { get; set; } = new List<SeriesCountryEntity>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<VideoGameCompanyCreditsEntity> VideoGameCompanyCreditss { get; set; } = new List<VideoGameCompanyCreditsEntity>();
}
