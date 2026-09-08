using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Book</c>. The entity is persistence-only.</summary>
public sealed class Book
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
    public Status? CastStatus { get; set; }

    /// <summary>Navigation for FK <c>CrewStatusID</c> to <c>Status</c>.</summary>
    public Status? CrewStatus { get; set; }

    /// <summary>Navigation for FK <c>ConnectionID</c> to <c>Connection</c>.</summary>
    public Connection? Connection { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation for FK <c>TypeID</c> to <c>Type</c>.</summary>
    public Type? Type { get; set; }

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookAward> BookAwards { get; set; } = new List<BookAward>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookCast> BookCasts { get; set; } = new List<BookCast>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookCrew> BookCrews { get; set; } = new List<BookCrew>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookImage> BookImages { get; set; } = new List<BookImage>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookLanguage> BookLanguages { get; set; } = new List<BookLanguage>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookScore> BookScores { get; set; } = new List<BookScore>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookText> BookTexts { get; set; } = new List<BookText>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookUser> BookUsers { get; set; } = new List<BookUser>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<BookWeblink> BookWeblinks { get; set; } = new List<BookWeblink>();

    /// <summary>Dependent rows referencing this Book.</summary>
    public ICollection<Publication> Publications { get; set; } = new List<Publication>();
}
