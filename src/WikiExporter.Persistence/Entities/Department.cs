using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Department</c>. The entity is persistence-only.</summary>
public sealed class Department
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

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<BookCrew> BookCrews { get; set; } = new List<BookCrew>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<EpisodeCompanyCredits> EpisodeCompanyCreditss { get; set; } = new List<EpisodeCompanyCredits>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<EpisodeCrew> EpisodeCrews { get; set; } = new List<EpisodeCrew>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<MovieCompanyCredits> MovieCompanyCreditss { get; set; } = new List<MovieCompanyCredits>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<MovieCrew> MovieCrews { get; set; } = new List<MovieCrew>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<PublicationCompanyCredits> PublicationCompanyCreditss { get; set; } = new List<PublicationCompanyCredits>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<SeriesCompanyCredits> SeriesCompanyCreditss { get; set; } = new List<SeriesCompanyCredits>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<SeriesCrew> SeriesCrews { get; set; } = new List<SeriesCrew>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<VideoGameCompanyCredits> VideoGameCompanyCreditss { get; set; } = new List<VideoGameCompanyCredits>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<VideoGameCrew> VideoGameCrews { get; set; } = new List<VideoGameCrew>();
}
