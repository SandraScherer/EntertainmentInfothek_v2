using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Person</c>. The entity is persistence-only.</summary>
public sealed class PersonEntity
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
    public GenderEntity? GenderEntity { get; set; }

    /// <summary>Navigation for FK <c>LocationOfBirthID</c> to <c>Location</c>.</summary>
    public LocationEntity? LocationOfBirth { get; set; }

    /// <summary>Navigation for FK <c>LocationOfDeathID</c> to <c>Location</c>.</summary>
    public LocationEntity? LocationOfDeath { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Navigation for FK <c>TypeID</c> to <c>Type</c>.</summary>
    public TypeEntity? TypeEntity { get; set; }

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<BookCastEntity> BookCasts { get; set; } = new List<BookCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<BookCrewEntity> BookCrews { get; set; } = new List<BookCrewEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<EpisodeAwardPersonEntity> EpisodeAwardPersons { get; set; } = new List<EpisodeAwardPersonEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<EpisodeCastEntity> EpisodeCastActors { get; set; } = new List<EpisodeCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<EpisodeCastEntity> EpisodeCastCharacters { get; set; } = new List<EpisodeCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<EpisodeCastEntity> EpisodeCastEnglishDubbers { get; set; } = new List<EpisodeCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<EpisodeCastEntity> EpisodeCastGermanDubbers { get; set; } = new List<EpisodeCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<EpisodeCrewEntity> EpisodeCrews { get; set; } = new List<EpisodeCrewEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<MovieAwardPersonEntity> MovieAwardPersons { get; set; } = new List<MovieAwardPersonEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<MovieCastEntity> MovieCastActors { get; set; } = new List<MovieCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<MovieCastEntity> MovieCastCharacters { get; set; } = new List<MovieCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<MovieCastEntity> MovieCastEnglishDubbers { get; set; } = new List<MovieCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<MovieCastEntity> MovieCastGermanDubbers { get; set; } = new List<MovieCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<MovieCrewEntity> MovieCrews { get; set; } = new List<MovieCrewEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonEmployerEntity> PersonEmployers { get; set; } = new List<PersonEmployerEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonFamilyEntity> PersonFamilyFamilys { get; set; } = new List<PersonFamilyEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonFamilyEntity> PersonFamilyPersons { get; set; } = new List<PersonFamilyEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonPositionEntity> PersonPositions { get; set; } = new List<PersonPositionEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonProfessionEntity> PersonProfessions { get; set; } = new List<PersonProfessionEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonSpeciesEntity> PersonSpeciess { get; set; } = new List<PersonSpeciesEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonTextEntity> PersonTexts { get; set; } = new List<PersonTextEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<PersonWeblinkEntity> PersonWeblinks { get; set; } = new List<PersonWeblinkEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<SeriesAwardPersonEntity> SeriesAwardPersons { get; set; } = new List<SeriesAwardPersonEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<SeriesCastEntity> SeriesCastActors { get; set; } = new List<SeriesCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<SeriesCastEntity> SeriesCastCharacters { get; set; } = new List<SeriesCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<SeriesCastEntity> SeriesCastEnglishDubbers { get; set; } = new List<SeriesCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<SeriesCastEntity> SeriesCastGermanDubbers { get; set; } = new List<SeriesCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<SeriesCrewEntity> SeriesCrews { get; set; } = new List<SeriesCrewEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<TextAuthorEntity> TextAuthors { get; set; } = new List<TextAuthorEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<VideoGameCastEntity> VideoGameCastActors { get; set; } = new List<VideoGameCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<VideoGameCastEntity> VideoGameCastCharacters { get; set; } = new List<VideoGameCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<VideoGameCastEntity> VideoGameCastEnglishDubbers { get; set; } = new List<VideoGameCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<VideoGameCastEntity> VideoGameCastGermanDubbers { get; set; } = new List<VideoGameCastEntity>();

    /// <summary>Dependent rows referencing this Person.</summary>
    public ICollection<VideoGameCrewEntity> VideoGameCrews { get; set; } = new List<VideoGameCrewEntity>();
}
