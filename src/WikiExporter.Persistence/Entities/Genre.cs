using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Genre</c>. The entity is persistence-only.</summary>
public sealed class Genre
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>EnglishName</c>.</summary>
    public string? EnglishName { get; set; }
    /// <summary>Maps to <c>GermanName</c>.</summary>
    public string? GermanName { get; set; }
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

    /// <summary>Dependent rows referencing this Genre.</summary>
    public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();

    /// <summary>Dependent rows referencing this Genre.</summary>
    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

    /// <summary>Dependent rows referencing this Genre.</summary>
    public ICollection<SeriesGenre> SeriesGenres { get; set; } = new List<SeriesGenre>();

    /// <summary>Dependent rows referencing this Genre.</summary>
    public ICollection<VideoGameGenre> VideoGameGenres { get; set; } = new List<VideoGameGenre>();
}
