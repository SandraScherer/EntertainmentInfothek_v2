using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Department</c>. The entity is persistence-only.</summary>
public sealed class DepartmentEntity
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

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<BookCrewEntity> BookCrews { get; set; } = new List<BookCrewEntity>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<EpisodeCompanyCreditsEntity> EpisodeCompanyCreditss { get; set; } = new List<EpisodeCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<EpisodeCrewEntity> EpisodeCrews { get; set; } = new List<EpisodeCrewEntity>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<MovieCompanyCreditsEntity> MovieCompanyCreditss { get; set; } = new List<MovieCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<MovieCrewEntity> MovieCrews { get; set; } = new List<MovieCrewEntity>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<PublicationCompanyCreditsEntity> PublicationCompanyCreditss { get; set; } = new List<PublicationCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<SeriesCompanyCreditsEntity> SeriesCompanyCreditss { get; set; } = new List<SeriesCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<SeriesCrewEntity> SeriesCrews { get; set; } = new List<SeriesCrewEntity>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<VideoGameCompanyCreditsEntity> VideoGameCompanyCreditss { get; set; } = new List<VideoGameCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Department.</summary>
    public ICollection<VideoGameCrewEntity> VideoGameCrews { get; set; } = new List<VideoGameCrewEntity>();
}
