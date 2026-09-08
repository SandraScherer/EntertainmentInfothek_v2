using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Country</c>. The entity is persistence-only.</summary>
public sealed class Country
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
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<EpisodeCompanyCredits> EpisodeCompanyCreditss { get; set; } = new List<EpisodeCompanyCredits>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<Location> Locations { get; set; } = new List<Location>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<MovieCompanyCredits> MovieCompanyCreditss { get; set; } = new List<MovieCompanyCredits>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<MovieCountry> MovieCountrys { get; set; } = new List<MovieCountry>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<PublicationCompanyCredits> PublicationCompanyCreditss { get; set; } = new List<PublicationCompanyCredits>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<SeriesCompanyCredits> SeriesCompanyCreditss { get; set; } = new List<SeriesCompanyCredits>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<SeriesCountry> SeriesCountrys { get; set; } = new List<SeriesCountry>();

    /// <summary>Dependent rows referencing this Country.</summary>
    public ICollection<VideoGameCompanyCredits> VideoGameCompanyCreditss { get; set; } = new List<VideoGameCompanyCredits>();
}
