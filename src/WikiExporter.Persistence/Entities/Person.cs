using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Person</c>. The entity is persistence-only.</summary>
public sealed class Person
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>FirstName</c>.</summary>
    public string? FirstName { get; set; }
    /// <summary>Maps to <c>LastName</c>.</summary>
    public string? LastName { get; set; }
    /// <summary>Maps to <c>NameAddOn</c>.</summary>
    public string? NameAddOn { get; set; }
    /// <summary>Maps to <c>BirthName</c>.</summary>
    public string? BirthName { get; set; }
    /// <summary>Maps to <c>DateOfBirth</c>.</summary>
    public string? DateOfBirth { get; set; }
    /// <summary>Maps to <c>LocationOfBirthID</c>.</summary>
    public string? LocationOfBirthId { get; set; }
    /// <summary>Maps to <c>DateOfDeath</c>.</summary>
    public string? DateOfDeath { get; set; }
    /// <summary>Maps to <c>LocationOfDeathID</c>.</summary>
    public string? LocationOfDeathId { get; set; }
    /// <summary>Maps to <c>EnglishCauseOfDeath</c>.</summary>
    public string? EnglishCauseOfDeath { get; set; }
    /// <summary>Maps to <c>GermanCauseOfDeath</c>.</summary>
    public string? GermanCauseOfDeath { get; set; }
    /// <summary>Maps to <c>GenderID</c>.</summary>
    public string? GenderId { get; set; }
    /// <summary>Maps to <c>Height</c>.</summary>
    public string? Height { get; set; }
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

    /// <summary>Navigation for FK <c>GenderID</c> to <c>Gender</c>.</summary>
    public Gender? Gender { get; set; }

    /// <summary>Navigation for FK <c>LocationOfBirthID</c> to <c>Location</c>.</summary>
    public Location? LocationOfBirth { get; set; }

    /// <summary>Navigation for FK <c>LocationOfDeathID</c> to <c>Location</c>.</summary>
    public Location? LocationOfDeath { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }

    /// <summary>Navigation for FK <c>TypeID</c> to <c>Type</c>.</summary>
    public Type? Type { get; set; }

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<BookCast> BookCasts { get; set; } = new List<BookCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<BookCrew> BookCrews { get; set; } = new List<BookCrew>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<EpisodeAwardPerson> EpisodeAwardPersons { get; set; } = new List<EpisodeAwardPerson>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<EpisodeCast> EpisodeCastActors { get; set; } = new List<EpisodeCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<EpisodeCast> EpisodeCastCharacters { get; set; } = new List<EpisodeCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<EpisodeCast> EpisodeCastEnglishDubbers { get; set; } = new List<EpisodeCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<EpisodeCast> EpisodeCastGermanDubbers { get; set; } = new List<EpisodeCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<EpisodeCrew> EpisodeCrews { get; set; } = new List<EpisodeCrew>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<MovieAwardPerson> MovieAwardPersons { get; set; } = new List<MovieAwardPerson>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<MovieCast> MovieCastActors { get; set; } = new List<MovieCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<MovieCast> MovieCastCharacters { get; set; } = new List<MovieCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<MovieCast> MovieCastEnglishDubbers { get; set; } = new List<MovieCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<MovieCast> MovieCastGermanDubbers { get; set; } = new List<MovieCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<MovieCrew> MovieCrews { get; set; } = new List<MovieCrew>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonEmployer> PersonEmployers { get; set; } = new List<PersonEmployer>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonFamily> PersonFamilyFamilys { get; set; } = new List<PersonFamily>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonFamily> PersonFamilyPersons { get; set; } = new List<PersonFamily>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonPosition> PersonPositions { get; set; } = new List<PersonPosition>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonProfession> PersonProfessions { get; set; } = new List<PersonProfession>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonSpecies> PersonSpeciess { get; set; } = new List<PersonSpecies>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonText> PersonTexts { get; set; } = new List<PersonText>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonWeblink> PersonWeblinks { get; set; } = new List<PersonWeblink>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<SeriesAwardPerson> SeriesAwardPersons { get; set; } = new List<SeriesAwardPerson>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<SeriesCast> SeriesCastActors { get; set; } = new List<SeriesCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<SeriesCast> SeriesCastCharacters { get; set; } = new List<SeriesCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<SeriesCast> SeriesCastEnglishDubbers { get; set; } = new List<SeriesCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<SeriesCast> SeriesCastGermanDubbers { get; set; } = new List<SeriesCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<SeriesCrew> SeriesCrews { get; set; } = new List<SeriesCrew>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<TextAuthor> TextAuthors { get; set; } = new List<TextAuthor>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<User> Users { get; set; } = new List<User>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<VideoGameCast> VideoGameCastActors { get; set; } = new List<VideoGameCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<VideoGameCast> VideoGameCastCharacters { get; set; } = new List<VideoGameCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<VideoGameCast> VideoGameCastEnglishDubbers { get; set; } = new List<VideoGameCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<VideoGameCast> VideoGameCastGermanDubbers { get; set; } = new List<VideoGameCast>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<VideoGameCrew> VideoGameCrews { get; set; } = new List<VideoGameCrew>();
}
