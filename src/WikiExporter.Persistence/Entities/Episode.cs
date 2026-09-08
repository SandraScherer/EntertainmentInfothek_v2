using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Episode</c>. The entity is persistence-only.</summary>
public sealed class Episode
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
    public Status? CastStatus { get; set; }

    /// <summary>Navigation for FK <c>CrewStatusID</c> to <c>Status</c>.</summary>
    public Status? CrewStatus { get; set; }

    /// <summary>Navigation for FK <c>SeriesID</c> to <c>Series</c>.</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeAward> EpisodeAwards { get; set; } = new List<EpisodeAward>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeCast> EpisodeCasts { get; set; } = new List<EpisodeCast>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeCertification> EpisodeCertifications { get; set; } = new List<EpisodeCertification>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeCompanyCredits> EpisodeCompanyCreditss { get; set; } = new List<EpisodeCompanyCredits>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeCrew> EpisodeCrews { get; set; } = new List<EpisodeCrew>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeFilmLength> EpisodeFilmLengths { get; set; } = new List<EpisodeFilmLength>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeFilmingDate> EpisodeFilmingDates { get; set; } = new List<EpisodeFilmingDate>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeFilmingLocation> EpisodeFilmingLocations { get; set; } = new List<EpisodeFilmingLocation>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeImage> EpisodeImages { get; set; } = new List<EpisodeImage>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeProductionDate> EpisodeProductionDates { get; set; } = new List<EpisodeProductionDate>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeReleaseDate> EpisodeReleaseDates { get; set; } = new List<EpisodeReleaseDate>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeRuntime> EpisodeRuntimes { get; set; } = new List<EpisodeRuntime>();

    /// <summary>Dependent rows referencing this Episode.</summary>
    public ICollection<EpisodeText> EpisodeTexts { get; set; } = new List<EpisodeText>();
}
