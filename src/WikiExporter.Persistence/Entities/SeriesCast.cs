using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Series_Cast</c>. The entity is persistence-only.</summary>
public sealed class SeriesCast
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>SeriesID</c>.</summary>
    public string? SeriesId { get; set; }
    /// <summary>Maps to <c>ActorID</c>.</summary>
    public string? ActorId { get; set; }
    /// <summary>Maps to <c>EnglishDubberID</c>.</summary>
    public string? EnglishDubberId { get; set; }
    /// <summary>Maps to <c>GermanDubberID</c>.</summary>
    public string? GermanDubberId { get; set; }
    /// <summary>Maps to <c>CharacterID</c>.</summary>
    public string? CharacterId { get; set; }
    /// <summary>Maps to <c>EnglishRole</c>.</summary>
    public string? EnglishRole { get; set; }
    /// <summary>Maps to <c>GermanRole</c>.</summary>
    public string? GermanRole { get; set; }
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

    /// <summary>Navigation for FK <c>ActorID</c> to <c>Person</c>.</summary>
    public Person? Actor { get; set; }

    /// <summary>Navigation for FK <c>CharacterID</c> to <c>Person</c>.</summary>
    public Person? Character { get; set; }

    /// <summary>Navigation for FK <c>EnglishDubberID</c> to <c>Person</c>.</summary>
    public Person? EnglishDubber { get; set; }

    /// <summary>Navigation for FK <c>GermanDubberID</c> to <c>Person</c>.</summary>
    public Person? GermanDubber { get; set; }

    /// <summary>Navigation for FK <c>SeriesID</c> to <c>Series</c>.</summary>
    public Series? Series { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }
}
