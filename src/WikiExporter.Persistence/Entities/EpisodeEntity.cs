using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Episode</c>. The entity is persistence-only.</summary>
public sealed class EpisodeEntity
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalTitle</c>.</summary>
    public string? OriginalTitle { get; set; }
    /// <summary>Maps to <c>EnglishTitle</c>.</summary>
    public string? EnglishTitle { get; set; }
    /// <summary>Maps to <c>GermanTitle</c>.</summary>
    public string? GermanTitle { get; set; }
    /// <summary>Maps to <c>SeriesID</c>.</summary>
    public string? SeriesId { get; set; }
    /// <summary>Maps to <c>SeasonNo</c>.</summary>
    public string? SeasonNo { get; set; }
    /// <summary>Maps to <c>EpisodeNo</c>.</summary>
    public string? EpisodeNo { get; set; }
    /// <summary>Maps to <c>CastStatusID</c>.</summary>
    public string? CastStatusId { get; set; }
    /// <summary>Maps to <c>CrewStatusID</c>.</summary>
    public string? CrewStatusId { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>CastStatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? CastStatus { get; set; }

    /// <summary>Navigation for FK <c>CrewStatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? CrewStatus { get; set; }

    /// <summary>Navigation for FK <c>SeriesID</c> to <c>Series</c>.</summary>
    public SeriesEntity? SeriesEntity { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeAwardEntity> EpisodeAwards { get; set; } = new List<EpisodeAwardEntity>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeCastEntity> EpisodeCasts { get; set; } = new List<EpisodeCastEntity>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeCertificationEntity> EpisodeCertifications { get; set; } = new List<EpisodeCertificationEntity>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeCompanyCreditsEntity> EpisodeCompanyCreditss { get; set; } = new List<EpisodeCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeCrewEntity> EpisodeCrews { get; set; } = new List<EpisodeCrewEntity>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeFilmLengthEntity> EpisodeFilmLengths { get; set; } = new List<EpisodeFilmLengthEntity>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeFilmingDateEntity> EpisodeFilmingDates { get; set; } = new List<EpisodeFilmingDateEntity>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeFilmingLocationEntity> EpisodeFilmingLocations { get; set; } = new List<EpisodeFilmingLocationEntity>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeImageEntity> EpisodeImages { get; set; } = new List<EpisodeImageEntity>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeProductionDateEntity> EpisodeProductionDates { get; set; } = new List<EpisodeProductionDateEntity>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeReleaseDateEntity> EpisodeReleaseDates { get; set; } = new List<EpisodeReleaseDateEntity>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeRuntimeEntity> EpisodeRuntimes { get; set; } = new List<EpisodeRuntimeEntity>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeTextEntity> EpisodeTexts { get; set; } = new List<EpisodeTextEntity>();
}
