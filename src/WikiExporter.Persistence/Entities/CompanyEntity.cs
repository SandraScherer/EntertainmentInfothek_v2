using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Company</c>. The entity is persistence-only.</summary>
public sealed class CompanyEntity
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
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Navigation for FK <c>TypeID</c> to <c>Type</c>.</summary>
    public TypeEntity? TypeEntity { get; set; }

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<AwardEntity> Awards { get; set; } = new List<AwardEntity>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<BookScoreEntity> BookScores { get; set; } = new List<BookScoreEntity>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<EmployerEntity> Employers { get; set; } = new List<EmployerEntity>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<EpisodeCompanyCreditsEntity> EpisodeCompanyCreditss { get; set; } = new List<EpisodeCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<ImageSourceEntity> ImageSources { get; set; } = new List<ImageSourceEntity>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<MovieCompanyCreditsEntity> MovieCompanyCreditss { get; set; } = new List<MovieCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<MovieScoreEntity> MovieScores { get; set; } = new List<MovieScoreEntity>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<PublicationCompanyCreditsEntity> PublicationCompanyCreditss { get; set; } = new List<PublicationCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<SeriesCompanyCreditsEntity> SeriesCompanyCreditss { get; set; } = new List<SeriesCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<SeriesScoreEntity> SeriesScores { get; set; } = new List<SeriesScoreEntity>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<TextSourceEntity> TextSources { get; set; } = new List<TextSourceEntity>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<VideoGameCompanyCreditsEntity> VideoGameCompanyCreditss { get; set; } = new List<VideoGameCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Company.</summary>
    public ICollection<VideoGameScoreEntity> VideoGameScores { get; set; } = new List<VideoGameScoreEntity>();
}
