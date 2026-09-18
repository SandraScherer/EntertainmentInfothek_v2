using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Book</c>. The entity is persistence-only.</summary>
public sealed class BookEntity
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalTitle</c>.</summary>
    public string? OriginalTitle { get; set; }
    /// <summary>Maps to <c>EnglishTitle</c>.</summary>
    public string? EnglishTitle { get; set; }
    /// <summary>Maps to <c>GermanTitle</c>.</summary>
    public string? GermanTitle { get; set; }
    /// <summary>Maps to <c>TypeID</c>.</summary>
    public string? TypeId { get; set; }
    /// <summary>Maps to <c>CastStatusID</c>.</summary>
    public string? CastStatusId { get; set; }
    /// <summary>Maps to <c>CrewStatusID</c>.</summary>
    public string? CrewStatusId { get; set; }
    /// <summary>Maps to <c>ConnectionID</c>.</summary>
    public string? ConnectionId { get; set; }
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

    /// <summary>Navigation for FK <c>ConnectionID</c> to <c>Connection</c>.</summary>
    public ConnectionEntity? ConnectionEntity { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Navigation for FK <c>TypeID</c> to <c>Type</c>.</summary>
    public TypeEntity? TypeEntity { get; set; }

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookAwardEntity> BookAwards { get; set; } = new List<BookAwardEntity>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookCastEntity> BookCasts { get; set; } = new List<BookCastEntity>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookCrewEntity> BookCrews { get; set; } = new List<BookCrewEntity>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookGenreEntity> BookGenres { get; set; } = new List<BookGenreEntity>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookImageEntity> BookImages { get; set; } = new List<BookImageEntity>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookLanguageEntity> BookLanguages { get; set; } = new List<BookLanguageEntity>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookScoreEntity> BookScores { get; set; } = new List<BookScoreEntity>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookTextEntity> BookTexts { get; set; } = new List<BookTextEntity>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookUserEntity> BookUsers { get; set; } = new List<BookUserEntity>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookWeblinkEntity> BookWeblinks { get; set; } = new List<BookWeblinkEntity>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<PublicationEntity> Publications { get; set; } = new List<PublicationEntity>();
}
