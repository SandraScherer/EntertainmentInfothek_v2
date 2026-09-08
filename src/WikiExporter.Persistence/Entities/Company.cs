using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Company</c>. The entity is persistence-only.</summary>
public sealed class Company
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalName</c>.</summary>
    public string? OriginalName { get; set; }
    /// <summary>Maps to <c>NameAddOn</c>.</summary>
    public string? NameAddOn { get; set; }
    /// <summary>Maps to <c>TypeID</c>.</summary>
    public string? TypeId { get; set; }
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

    /// <summary>Navigation for FK <c>TypeID</c> to <c>Type</c>.</summary>
    public Type? Type { get; set; }

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<Award> Awards { get; set; } = new List<Award>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<BookScore> BookScores { get; set; } = new List<BookScore>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<Employer> Employers { get; set; } = new List<Employer>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<EpisodeCompanyCredits> EpisodeCompanyCreditss { get; set; } = new List<EpisodeCompanyCredits>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<ImageSource> ImageSources { get; set; } = new List<ImageSource>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<MovieCompanyCredits> MovieCompanyCreditss { get; set; } = new List<MovieCompanyCredits>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<MovieScore> MovieScores { get; set; } = new List<MovieScore>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<PublicationCompanyCredits> PublicationCompanyCreditss { get; set; } = new List<PublicationCompanyCredits>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<SeriesCompanyCredits> SeriesCompanyCreditss { get; set; } = new List<SeriesCompanyCredits>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<SeriesScore> SeriesScores { get; set; } = new List<SeriesScore>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<TextSource> TextSources { get; set; } = new List<TextSource>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<VideoGameCompanyCredits> VideoGameCompanyCreditss { get; set; } = new List<VideoGameCompanyCredits>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<VideoGameScore> VideoGameScores { get; set; } = new List<VideoGameScore>();
}
