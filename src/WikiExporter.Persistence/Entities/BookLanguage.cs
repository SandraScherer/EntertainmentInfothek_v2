using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Book_Language</c>. The entity is persistence-only.</summary>
public sealed class BookLanguage
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>BookID</c>.</summary>
    public string? BookId { get; set; }
    /// <summary>Maps to <c>LanguageID</c>.</summary>
    public string? LanguageId { get; set; }
    /// <summary>Maps to <c>Order</c>.</summary>
    public string? Order { get; set; }
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

    /// <summary>Navigation for FK <c>LanguageID</c> to <c>Language</c>.</summary>
    public Language? Language { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }
}
