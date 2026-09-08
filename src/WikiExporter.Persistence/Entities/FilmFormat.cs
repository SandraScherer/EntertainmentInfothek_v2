using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>FilmFormat</c>. The entity is persistence-only.</summary>
public sealed class FilmFormat
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>OriginalName</c>.</summary>
    public string? OriginalName { get; set; }
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

    /// <summary>Dependent rows referencing this FilmFormat.</summary>
    public ICollection<MovieNegativeFormat> MovieNegativeFormats { get; set; } = new List<MovieNegativeFormat>();

    /// <summary>Dependent rows referencing this FilmFormat.</summary>
    public ICollection<MoviePrintedFilmFormat> MoviePrintedFilmFormats { get; set; } = new List<MoviePrintedFilmFormat>();

    /// <summary>Dependent rows referencing this FilmFormat.</summary>
    public ICollection<SeriesNegativeFormat> SeriesNegativeFormats { get; set; } = new List<SeriesNegativeFormat>();

    /// <summary>Dependent rows referencing this FilmFormat.</summary>
    public ICollection<SeriesPrintedFilmFormat> SeriesPrintedFilmFormats { get; set; } = new List<SeriesPrintedFilmFormat>();
}
