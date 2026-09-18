using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>FilmFormat</c>. The entity is persistence-only.</summary>
public sealed class FilmFormatEntity
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
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this FilmFormat.</summary>
    public ICollection<MovieNegativeFormatEntity> MovieNegativeFormats { get; set; } = new List<MovieNegativeFormatEntity>();

    /// <summary>Dependent rows referencing this FilmFormat.</summary>
    public ICollection<MoviePrintedFilmFormatEntity> MoviePrintedFilmFormats { get; set; } = new List<MoviePrintedFilmFormatEntity>();

    /// <summary>Dependent rows referencing this FilmFormat.</summary>
    public ICollection<SeriesNegativeFormatEntity> SeriesNegativeFormats { get; set; } = new List<SeriesNegativeFormatEntity>();

    /// <summary>Dependent rows referencing this FilmFormat.</summary>
    public ICollection<SeriesPrintedFilmFormatEntity> SeriesPrintedFilmFormats { get; set; } = new List<SeriesPrintedFilmFormatEntity>();
}
