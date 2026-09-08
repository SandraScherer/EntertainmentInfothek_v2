using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Movie_NegativeFormat</c>. The entity is persistence-only.</summary>
public sealed class MovieNegativeFormat
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>MovieID</c>.</summary>
    public string? MovieId { get; set; }
    /// <summary>Maps to <c>FilmFormatID</c>.</summary>
    public string? FilmFormatId { get; set; }
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

    /// <summary>Navigation for FK <c>FilmFormatID</c> to <c>FilmFormat</c>.</summary>
    public FilmFormat? FilmFormat { get; set; }

    /// <summary>Navigation for FK <c>MovieID</c> to <c>Movie</c>.</summary>
    public Movie? Movie { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }
}
