using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Publication</c>. The entity is persistence-only.</summary>
public sealed class Publication
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>EnglishTitle</c>.</summary>
    public string? EnglishTitle { get; set; }
    /// <summary>Maps to <c>GermanTitle</c>.</summary>
    public string? GermanTitle { get; set; }
    /// <summary>Maps to <c>ISBN13</c>.</summary>
    public string? ISBN13 { get; set; }
    /// <summary>Maps to <c>ISBN10</c>.</summary>
    public string? ISBN10 { get; set; }
    /// <summary>Maps to <c>BookID</c>.</summary>
    public string? BookId { get; set; }
    /// <summary>Maps to <c>EditionID</c>.</summary>
    public string? EditionId { get; set; }
    /// <summary>Maps to <c>Format</c>.</summary>
    public string? Format { get; set; }
    /// <summary>Maps to <c>NoOfPages</c>.</summary>
    public string? NoOfPages { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>BookID</c> to <c>Book</c>.</summary>
    public Book? Book { get; set; }

    /// <summary>Navigation for FK <c>EditionID</c> to <c>Edition</c>.</summary>
    public Edition? Edition { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Dependent rows referencing this Publication.</summary>
    public ICollection<BookUser> BookUsers { get; set; } = new List<BookUser>();

    /// <summary>Dependent rows referencing this Publication.</summary>
    public ICollection<PublicationCertification> PublicationCertifications { get; set; } = new List<PublicationCertification>();

    /// <summary>Dependent rows referencing this Publication.</summary>
    public ICollection<PublicationCompanyCredits> PublicationCompanyCreditss { get; set; } = new List<PublicationCompanyCredits>();

    /// <summary>Dependent rows referencing this Publication.</summary>
    public ICollection<PublicationLanguage> PublicationLanguages { get; set; } = new List<PublicationLanguage>();

    /// <summary>Dependent rows referencing this Publication.</summary>
    public ICollection<PublicationReleaseDate> PublicationReleaseDates { get; set; } = new List<PublicationReleaseDate>();

    /// <summary>Dependent rows referencing this Publication.</summary>
    public ICollection<PublicationText> PublicationTexts { get; set; } = new List<PublicationText>();
}
