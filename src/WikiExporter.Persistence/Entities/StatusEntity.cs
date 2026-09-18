using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Status</c>. The entity is persistence-only.</summary>
public sealed class StatusEntity
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
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<AspectRatioEntity> AspectRatios { get; set; } = new List<AspectRatioEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<AwardEntity> Awards { get; set; } = new List<AwardEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookEntity> BookCastStatuss { get; set; } = new List<BookEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookEntity> BookCrewStatuss { get; set; } = new List<BookEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookEntity> BookStatuss { get; set; } = new List<BookEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookAwardEntity> BookAwards { get; set; } = new List<BookAwardEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookCastEntity> BookCasts { get; set; } = new List<BookCastEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookCrewEntity> BookCrews { get; set; } = new List<BookCrewEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookGenreEntity> BookGenres { get; set; } = new List<BookGenreEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookImageEntity> BookImages { get; set; } = new List<BookImageEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookLanguageEntity> BookLanguages { get; set; } = new List<BookLanguageEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookScoreEntity> BookScores { get; set; } = new List<BookScoreEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookTextEntity> BookTexts { get; set; } = new List<BookTextEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookUserEntity> BookUserStatuss { get; set; } = new List<BookUserEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookUserEntity> BookUserUserStatuss { get; set; } = new List<BookUserEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookWeblinkEntity> BookWeblinks { get; set; } = new List<BookWeblinkEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BusinessModelEntity> BusinessModels { get; set; } = new List<BusinessModelEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<CDROMDriveSpeedEntity> CDROMDriveSpeeds { get; set; } = new List<CDROMDriveSpeedEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<CPUEntity> CPUs { get; set; } = new List<CPUEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<CameraEntity> Cameras { get; set; } = new List<CameraEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<CertificationEntity> Certifications { get; set; } = new List<CertificationEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<CinematographicProcessEntity> CinematographicProcesss { get; set; } = new List<CinematographicProcessEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<ColorEntity> Colors { get; set; } = new List<ColorEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<CompanyEntity> Companys { get; set; } = new List<CompanyEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<ConnectionEntity> Connections { get; set; } = new List<ConnectionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<CopyProtectionEntity> CopyProtections { get; set; } = new List<CopyProtectionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<CountryEntity> Countrys { get; set; } = new List<CountryEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<DepartmentEntity> Departments { get; set; } = new List<DepartmentEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<DifficultyEntity> Difficultys { get; set; } = new List<DifficultyEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<DirectXEntity> DirectXs { get; set; } = new List<DirectXEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<DriverEntity> Drivers { get; set; } = new List<DriverEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EditionEntity> Editions { get; set; } = new List<EditionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EmployerEntity> Employers { get; set; } = new List<EmployerEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeEntity> EpisodeCastStatuss { get; set; } = new List<EpisodeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeEntity> EpisodeCrewStatuss { get; set; } = new List<EpisodeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeEntity> EpisodeStatuss { get; set; } = new List<EpisodeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeAwardEntity> EpisodeAwards { get; set; } = new List<EpisodeAwardEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeAwardPersonEntity> EpisodeAwardPersons { get; set; } = new List<EpisodeAwardPersonEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeCastEntity> EpisodeCasts { get; set; } = new List<EpisodeCastEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeCertificationEntity> EpisodeCertifications { get; set; } = new List<EpisodeCertificationEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeCompanyCreditsEntity> EpisodeCompanyCreditss { get; set; } = new List<EpisodeCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeCrewEntity> EpisodeCrews { get; set; } = new List<EpisodeCrewEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeFilmLengthEntity> EpisodeFilmLengths { get; set; } = new List<EpisodeFilmLengthEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeFilmingDateEntity> EpisodeFilmingDates { get; set; } = new List<EpisodeFilmingDateEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeFilmingLocationEntity> EpisodeFilmingLocations { get; set; } = new List<EpisodeFilmingLocationEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeImageEntity> EpisodeImages { get; set; } = new List<EpisodeImageEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeProductionDateEntity> EpisodeProductionDates { get; set; } = new List<EpisodeProductionDateEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeReleaseDateEntity> EpisodeReleaseDates { get; set; } = new List<EpisodeReleaseDateEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeRuntimeEntity> EpisodeRuntimes { get; set; } = new List<EpisodeRuntimeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeTextEntity> EpisodeTexts { get; set; } = new List<EpisodeTextEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<FilmFormatEntity> FilmFormats { get; set; } = new List<FilmFormatEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<GenderEntity> Genders { get; set; } = new List<GenderEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<GenreEntity> Genres { get; set; } = new List<GenreEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<HardwareEntity> Hardwares { get; set; } = new List<HardwareEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<ImageEntity> Images { get; set; } = new List<ImageEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<ImageSourceEntity> ImageSources { get; set; } = new List<ImageSourceEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<ImageTypeEntity> ImageTypes { get; set; } = new List<ImageTypeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<InputDeviceEntity> InputDevices { get; set; } = new List<InputDeviceEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<InputDeviceFeatureEntity> InputDeviceFeatures { get; set; } = new List<InputDeviceFeatureEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<LaboratoryEntity> Laboratorys { get; set; } = new List<LaboratoryEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<LanguageEntity> Languages { get; set; } = new List<LanguageEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<LocationEntity> Locations { get; set; } = new List<LocationEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MacOSSprocketEntity> MacOSSprockets { get; set; } = new List<MacOSSprocketEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MediaTypeEntity> MediaTypes { get; set; } = new List<MediaTypeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieEntity> MovieCastStatuss { get; set; } = new List<MovieEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieEntity> MovieCrewStatuss { get; set; } = new List<MovieEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieEntity> MovieStatuss { get; set; } = new List<MovieEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieAspectRatioEntity> MovieAspectRatios { get; set; } = new List<MovieAspectRatioEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieAwardEntity> MovieAwards { get; set; } = new List<MovieAwardEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieAwardPersonEntity> MovieAwardPersons { get; set; } = new List<MovieAwardPersonEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCameraEntity> MovieCameras { get; set; } = new List<MovieCameraEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCastEntity> MovieCasts { get; set; } = new List<MovieCastEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCertificationEntity> MovieCertifications { get; set; } = new List<MovieCertificationEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCinematographicProcessEntity> MovieCinematographicProcesss { get; set; } = new List<MovieCinematographicProcessEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieColorEntity> MovieColors { get; set; } = new List<MovieColorEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCompanyCreditsEntity> MovieCompanyCreditss { get; set; } = new List<MovieCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCountryEntity> MovieCountrys { get; set; } = new List<MovieCountryEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCrewEntity> MovieCrews { get; set; } = new List<MovieCrewEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieFilmLengthEntity> MovieFilmLengths { get; set; } = new List<MovieFilmLengthEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieFilmingDateEntity> MovieFilmingDates { get; set; } = new List<MovieFilmingDateEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieFilmingLocationEntity> MovieFilmingLocations { get; set; } = new List<MovieFilmingLocationEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieGenreEntity> MovieGenres { get; set; } = new List<MovieGenreEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieImageEntity> MovieImages { get; set; } = new List<MovieImageEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieLaboratoryEntity> MovieLaboratorys { get; set; } = new List<MovieLaboratoryEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieLanguageEntity> MovieLanguages { get; set; } = new List<MovieLanguageEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieNegativeFormatEntity> MovieNegativeFormats { get; set; } = new List<MovieNegativeFormatEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MoviePrintedFilmFormatEntity> MoviePrintedFilmFormats { get; set; } = new List<MoviePrintedFilmFormatEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieProductionDateEntity> MovieProductionDates { get; set; } = new List<MovieProductionDateEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieReleaseDateEntity> MovieReleaseDates { get; set; } = new List<MovieReleaseDateEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieRuntimeEntity> MovieRuntimes { get; set; } = new List<MovieRuntimeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieScoreEntity> MovieScores { get; set; } = new List<MovieScoreEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieSoundMixEntity> MovieSoundMixs { get; set; } = new List<MovieSoundMixEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieTextEntity> MovieTexts { get; set; } = new List<MovieTextEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieUserEntity> MovieUserStatuss { get; set; } = new List<MovieUserEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieUserEntity> MovieUserUserStatuss { get; set; } = new List<MovieUserEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieWeblinkEntity> MovieWeblinks { get; set; } = new List<MovieWeblinkEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MultiplayerGameModeEntity> MultiplayerGameModes { get; set; } = new List<MultiplayerGameModeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MultiplayerOptionEntity> MultiplayerOptions { get; set; } = new List<MultiplayerOptionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<OperatingSystemEntity> OperatingSystems { get; set; } = new List<OperatingSystemEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonEntity> Persons { get; set; } = new List<PersonEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonEmployerEntity> PersonEmployers { get; set; } = new List<PersonEmployerEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonFamilyEntity> PersonFamilys { get; set; } = new List<PersonFamilyEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonPositionEntity> PersonPositions { get; set; } = new List<PersonPositionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonProfessionEntity> PersonProfessions { get; set; } = new List<PersonProfessionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonSpeciesEntity> PersonSpeciess { get; set; } = new List<PersonSpeciesEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonTextEntity> PersonTexts { get; set; } = new List<PersonTextEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonWeblinkEntity> PersonWeblinks { get; set; } = new List<PersonWeblinkEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PerspectiveEntity> Perspectives { get; set; } = new List<PerspectiveEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PlatformEntity> Platforms { get; set; } = new List<PlatformEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PositionEntity> Positions { get; set; } = new List<PositionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PriorityEntity> Prioritys { get; set; } = new List<PriorityEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<ProfessionEntity> Professions { get; set; } = new List<ProfessionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PublicationEntity> Publications { get; set; } = new List<PublicationEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PublicationCertificationEntity> PublicationCertifications { get; set; } = new List<PublicationCertificationEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PublicationCompanyCreditsEntity> PublicationCompanyCreditss { get; set; } = new List<PublicationCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PublicationLanguageEntity> PublicationLanguages { get; set; } = new List<PublicationLanguageEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PublicationReleaseDateEntity> PublicationReleaseDates { get; set; } = new List<PublicationReleaseDateEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PublicationTextEntity> PublicationTexts { get; set; } = new List<PublicationTextEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<RAMEntity> RAMs { get; set; } = new List<RAMEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<RelationshipEntity> Relationships { get; set; } = new List<RelationshipEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SaveGameMethodEntity> SaveGameMethods { get; set; } = new List<SaveGameMethodEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesEntity> SeriesCastStatuss { get; set; } = new List<SeriesEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesEntity> SeriesCrewStatuss { get; set; } = new List<SeriesEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesEntity> SeriesStatuss { get; set; } = new List<SeriesEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesAspectRatioEntity> SeriesAspectRatios { get; set; } = new List<SeriesAspectRatioEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesAwardEntity> SeriesAwards { get; set; } = new List<SeriesAwardEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesAwardPersonEntity> SeriesAwardPersons { get; set; } = new List<SeriesAwardPersonEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCameraEntity> SeriesCameras { get; set; } = new List<SeriesCameraEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCastEntity> SeriesCasts { get; set; } = new List<SeriesCastEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCertificationEntity> SeriesCertifications { get; set; } = new List<SeriesCertificationEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCinematographicProcessEntity> SeriesCinematographicProcesss { get; set; } = new List<SeriesCinematographicProcessEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesColorEntity> SeriesColors { get; set; } = new List<SeriesColorEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCompanyCreditsEntity> SeriesCompanyCreditss { get; set; } = new List<SeriesCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCountryEntity> SeriesCountrys { get; set; } = new List<SeriesCountryEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCrewEntity> SeriesCrews { get; set; } = new List<SeriesCrewEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesFilmLengthEntity> SeriesFilmLengths { get; set; } = new List<SeriesFilmLengthEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesFilmingDateEntity> SeriesFilmingDates { get; set; } = new List<SeriesFilmingDateEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesFilmingLocationEntity> SeriesFilmingLocations { get; set; } = new List<SeriesFilmingLocationEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesGenreEntity> SeriesGenres { get; set; } = new List<SeriesGenreEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesImageEntity> SeriesImages { get; set; } = new List<SeriesImageEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesLaboratoryEntity> SeriesLaboratorys { get; set; } = new List<SeriesLaboratoryEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesLanguageEntity> SeriesLanguages { get; set; } = new List<SeriesLanguageEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesNegativeFormatEntity> SeriesNegativeFormats { get; set; } = new List<SeriesNegativeFormatEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesPrintedFilmFormatEntity> SeriesPrintedFilmFormats { get; set; } = new List<SeriesPrintedFilmFormatEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesProductionDateEntity> SeriesProductionDates { get; set; } = new List<SeriesProductionDateEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesReleaseDateFirstEpisodeEntity> SeriesReleaseDateFirstEpisodes { get; set; } = new List<SeriesReleaseDateFirstEpisodeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesReleaseDateLastEpisodeEntity> SeriesReleaseDateLastEpisodes { get; set; } = new List<SeriesReleaseDateLastEpisodeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesRuntimeEntity> SeriesRuntimes { get; set; } = new List<SeriesRuntimeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesScoreEntity> SeriesScores { get; set; } = new List<SeriesScoreEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesSoundMixEntity> SeriesSoundMixs { get; set; } = new List<SeriesSoundMixEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesTextEntity> SeriesTexts { get; set; } = new List<SeriesTextEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesUserEntity> SeriesUserStatuss { get; set; } = new List<SeriesUserEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesUserEntity> SeriesUserUserStatuss { get; set; } = new List<SeriesUserEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesWeblinkEntity> SeriesWeblinks { get; set; } = new List<SeriesWeblinkEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SettingEntity> Settings { get; set; } = new List<SettingEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SoundDeviceEntity> SoundDevices { get; set; } = new List<SoundDeviceEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SoundMixEntity> SoundMixs { get; set; } = new List<SoundMixEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SoundModeEntity> SoundModes { get; set; } = new List<SoundModeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SpeciesEntity> Speciess { get; set; } = new List<SpeciesEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<StatusEntity> Statuss { get; set; } = new List<StatusEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<System> Systems { get; set; } = new List<System>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationEntity> TechnicalSpecifications { get; set; } = new List<TechnicalSpecificationEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationCopyProtectionEntity> TechnicalSpecificationCopyProtections { get; set; } = new List<TechnicalSpecificationCopyProtectionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationMacOSSprocketEntity> TechnicalSpecificationMacOSSprockets { get; set; } = new List<TechnicalSpecificationMacOSSprocketEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationMediaTypeEntity> TechnicalSpecificationMediaTypes { get; set; } = new List<TechnicalSpecificationMediaTypeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationMultiplayerGameModeEntity> TechnicalSpecificationMultiplayerGameModes { get; set; } = new List<TechnicalSpecificationMultiplayerGameModeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationMultiplayerOptionEntity> TechnicalSpecificationMultiplayerOptions { get; set; } = new List<TechnicalSpecificationMultiplayerOptionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationRequiredAdditionalHardwareEntity> TechnicalSpecificationRequiredAdditionalHardwares { get; set; } = new List<TechnicalSpecificationRequiredAdditionalHardwareEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationRequiredInputDeviceEntity> TechnicalSpecificationRequiredInputDevices { get; set; } = new List<TechnicalSpecificationRequiredInputDeviceEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSaveGameMethodEntity> TechnicalSpecificationSaveGameMethods { get; set; } = new List<TechnicalSpecificationSaveGameMethodEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedAdditionalHardwareEntity> TechnicalSpecificationSupportedAdditionalHardwares { get; set; } = new List<TechnicalSpecificationSupportedAdditionalHardwareEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedDriverEntity> TechnicalSpecificationSupportedDrivers { get; set; } = new List<TechnicalSpecificationSupportedDriverEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDeviceEntity> TechnicalSpecificationSupportedInputDevices { get; set; } = new List<TechnicalSpecificationSupportedInputDeviceEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDeviceFeatureEntity> TechnicalSpecificationSupportedInputDeviceFeatures { get; set; } = new List<TechnicalSpecificationSupportedInputDeviceFeatureEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundDeviceEntity> TechnicalSpecificationSupportedSoundDevices { get; set; } = new List<TechnicalSpecificationSupportedSoundDeviceEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundModeEntity> TechnicalSpecificationSupportedSoundModes { get; set; } = new List<TechnicalSpecificationSupportedSoundModeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoModeEntity> TechnicalSpecificationSupportedVideoModes { get; set; } = new List<TechnicalSpecificationSupportedVideoModeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoResolutionEntity> TechnicalSpecificationSupportedVideoResolutions { get; set; } = new List<TechnicalSpecificationSupportedVideoResolutionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TextEntity> Texts { get; set; } = new List<TextEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TextAuthorEntity> TextAuthors { get; set; } = new List<TextAuthorEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TextSourceEntity> TextSources { get; set; } = new List<TextSourceEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TextTypeEntity> TextTypes { get; set; } = new List<TextTypeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TypeEntity> Types { get; set; } = new List<TypeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VersionEntity> Versions { get; set; } = new List<VersionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameEntity> VideoGameCastStatuss { get; set; } = new List<VideoGameEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameEntity> VideoGameCrewStatuss { get; set; } = new List<VideoGameEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameEntity> VideoGameStatuss { get; set; } = new List<VideoGameEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameAwardEntity> VideoGameAwards { get; set; } = new List<VideoGameAwardEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameCastEntity> VideoGameCasts { get; set; } = new List<VideoGameCastEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameCertificationEntity> VideoGameCertifications { get; set; } = new List<VideoGameCertificationEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameCompanyCreditsEntity> VideoGameCompanyCreditss { get; set; } = new List<VideoGameCompanyCreditsEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameCompletionEntity> VideoGameCompletionCompletionStatuss { get; set; } = new List<VideoGameCompletionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameCompletionEntity> VideoGameCompletionStatuss { get; set; } = new List<VideoGameCompletionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameCrewEntity> VideoGameCrews { get; set; } = new List<VideoGameCrewEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameDifficultyEntity> VideoGameDifficultys { get; set; } = new List<VideoGameDifficultyEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameGenreEntity> VideoGameGenres { get; set; } = new List<VideoGameGenreEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameImageEntity> VideoGameImages { get; set; } = new List<VideoGameImageEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameLanguageEntity> VideoGameLanguages { get; set; } = new List<VideoGameLanguageEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGamePerspectiveEntity> VideoGamePerspectives { get; set; } = new List<VideoGamePerspectiveEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameReleaseDateEntity> VideoGameReleaseDates { get; set; } = new List<VideoGameReleaseDateEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameScoreEntity> VideoGameScores { get; set; } = new List<VideoGameScoreEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameSettingEntity> VideoGameSettings { get; set; } = new List<VideoGameSettingEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameTextEntity> VideoGameTexts { get; set; } = new List<VideoGameTextEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameUserEntity> VideoGameUserStatuss { get; set; } = new List<VideoGameUserEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameUserEntity> VideoGameUserUserStatuss { get; set; } = new List<VideoGameUserEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameVersionEntity> VideoGameVersions { get; set; } = new List<VideoGameVersionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameWeblinkEntity> VideoGameWeblinks { get; set; } = new List<VideoGameWeblinkEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoModeEntity> VideoModes { get; set; } = new List<VideoModeEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoResolutionEntity> VideoResolutions { get; set; } = new List<VideoResolutionEntity>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<WeblinkEntity> Weblinks { get; set; } = new List<WeblinkEntity>();
}
