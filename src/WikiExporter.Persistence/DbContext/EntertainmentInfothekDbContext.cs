using Microsoft.EntityFrameworkCore;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.DbContext;

/// <summary>Read-only EF Core DbContext for the EntertainmentInfothek SQLite database.</summary>
public sealed class EntertainmentInfothekDbContext : Microsoft.EntityFrameworkCore.DbContext
{
/// <summary>Stores the aspect ratio entity value.</summary>
    public DbSet<AspectRatioEntity> AspectRatioEntity => Set<AspectRatioEntity>();
/// <summary>Stores the award entity value.</summary>
    public DbSet<AwardEntity> AwardEntity => Set<AwardEntity>();
/// <summary>Stores the book entity value.</summary>
    public DbSet<BookEntity> BookEntity => Set<BookEntity>();
/// <summary>Stores the book award entity value.</summary>
    public DbSet<BookAwardEntity> BookAwardEntity => Set<BookAwardEntity>();
/// <summary>Stores the book cast entity value.</summary>
    public DbSet<BookCastEntity> BookCastEntity => Set<BookCastEntity>();
/// <summary>Stores the book crew entity value.</summary>
    public DbSet<BookCrewEntity> BookCrewEntity => Set<BookCrewEntity>();
/// <summary>Stores the book genre entity value.</summary>
    public DbSet<BookGenreEntity> BookGenreEntity => Set<BookGenreEntity>();
/// <summary>Stores the book image entity value.</summary>
    public DbSet<BookImageEntity> BookImageEntity => Set<BookImageEntity>();
/// <summary>Stores the book language entity value.</summary>
    public DbSet<BookLanguageEntity> BookLanguageEntity => Set<BookLanguageEntity>();
/// <summary>Stores the book score entity value.</summary>
    public DbSet<BookScoreEntity> BookScoreEntity => Set<BookScoreEntity>();
/// <summary>Stores the book text entity value.</summary>
    public DbSet<BookTextEntity> BookTextEntity => Set<BookTextEntity>();
/// <summary>Stores the book user entity value.</summary>
    public DbSet<BookUserEntity> BookUserEntity => Set<BookUserEntity>();
/// <summary>Stores the book weblink entity value.</summary>
    public DbSet<BookWeblinkEntity> BookWeblinkEntity => Set<BookWeblinkEntity>();
/// <summary>Stores the business model entity value.</summary>
    public DbSet<BusinessModelEntity> BusinessModelEntity => Set<BusinessModelEntity>();
/// <summary>Stores the cdrom drive speed entity value.</summary>
    public DbSet<CDROMDriveSpeedEntity> CDROMDriveSpeedEntity => Set<CDROMDriveSpeedEntity>();
/// <summary>Stores the cpu entity value.</summary>
    public DbSet<CPUEntity> CPUEntity => Set<CPUEntity>();
/// <summary>Stores the camera entity value.</summary>
    public DbSet<CameraEntity> CameraEntity => Set<CameraEntity>();
/// <summary>Stores the certification entity value.</summary>
    public DbSet<CertificationEntity> CertificationEntity => Set<CertificationEntity>();
/// <summary>Stores the cinematographic process entity value.</summary>
    public DbSet<CinematographicProcessEntity> CinematographicProcessEntity => Set<CinematographicProcessEntity>();
/// <summary>Stores the color entity value.</summary>
    public DbSet<ColorEntity> ColorEntity => Set<ColorEntity>();
/// <summary>Stores the company entity value.</summary>
    public DbSet<CompanyEntity> CompanyEntity => Set<CompanyEntity>();
/// <summary>Stores the connection entity value.</summary>
    public DbSet<ConnectionEntity> ConnectionEntity => Set<ConnectionEntity>();
/// <summary>Stores the copy protection entity value.</summary>
    public DbSet<CopyProtectionEntity> CopyProtectionEntity => Set<CopyProtectionEntity>();
/// <summary>Stores the country entity value.</summary>
    public DbSet<CountryEntity> CountryEntity => Set<CountryEntity>();
/// <summary>Stores the department entity value.</summary>
    public DbSet<DepartmentEntity> DepartmentEntity => Set<DepartmentEntity>();
/// <summary>Stores the difficulty entity value.</summary>
    public DbSet<DifficultyEntity> DifficultyEntity => Set<DifficultyEntity>();
/// <summary>Stores the direct x entity value.</summary>
    public DbSet<DirectXEntity> DirectXEntity => Set<DirectXEntity>();
/// <summary>Stores the driver entity value.</summary>
    public DbSet<DriverEntity> DriverEntity => Set<DriverEntity>();
/// <summary>Stores the edition entity value.</summary>
    public DbSet<EditionEntity> EditionEntity => Set<EditionEntity>();
/// <summary>Stores the employer entity value.</summary>
    public DbSet<EmployerEntity> EmployerEntity => Set<EmployerEntity>();
/// <summary>Stores the episode entity value.</summary>
    public DbSet<EpisodeEntity> EpisodeEntity => Set<EpisodeEntity>();
/// <summary>Stores the episode award entity value.</summary>
    public DbSet<EpisodeAwardEntity> EpisodeAwardEntity => Set<EpisodeAwardEntity>();
/// <summary>Stores the episode award person entity value.</summary>
    public DbSet<EpisodeAwardPersonEntity> EpisodeAwardPersonEntity => Set<EpisodeAwardPersonEntity>();
/// <summary>Stores the episode cast entity value.</summary>
    public DbSet<EpisodeCastEntity> EpisodeCastEntity => Set<EpisodeCastEntity>();
/// <summary>Stores the episode certification entity value.</summary>
    public DbSet<EpisodeCertificationEntity> EpisodeCertificationEntity => Set<EpisodeCertificationEntity>();
/// <summary>Stores the episode company credits entity value.</summary>
    public DbSet<EpisodeCompanyCreditsEntity> EpisodeCompanyCreditsEntity => Set<EpisodeCompanyCreditsEntity>();
/// <summary>Stores the episode crew entity value.</summary>
    public DbSet<EpisodeCrewEntity> EpisodeCrewEntity => Set<EpisodeCrewEntity>();
/// <summary>Stores the episode film length entity value.</summary>
    public DbSet<EpisodeFilmLengthEntity> EpisodeFilmLengthEntity => Set<EpisodeFilmLengthEntity>();
/// <summary>Stores the episode filming date entity value.</summary>
    public DbSet<EpisodeFilmingDateEntity> EpisodeFilmingDateEntity => Set<EpisodeFilmingDateEntity>();
/// <summary>Stores the episode filming location entity value.</summary>
    public DbSet<EpisodeFilmingLocationEntity> EpisodeFilmingLocationEntity => Set<EpisodeFilmingLocationEntity>();
/// <summary>Stores the episode image entity value.</summary>
    public DbSet<EpisodeImageEntity> EpisodeImageEntity => Set<EpisodeImageEntity>();
/// <summary>Stores the episode production date entity value.</summary>
    public DbSet<EpisodeProductionDateEntity> EpisodeProductionDateEntity => Set<EpisodeProductionDateEntity>();
/// <summary>Stores the episode release date entity value.</summary>
    public DbSet<EpisodeReleaseDateEntity> EpisodeReleaseDateEntity => Set<EpisodeReleaseDateEntity>();
/// <summary>Stores the episode runtime entity value.</summary>
    public DbSet<EpisodeRuntimeEntity> EpisodeRuntimeEntity => Set<EpisodeRuntimeEntity>();
/// <summary>Stores the episode text entity value.</summary>
    public DbSet<EpisodeTextEntity> EpisodeTextEntity => Set<EpisodeTextEntity>();
/// <summary>Stores the film format entity value.</summary>
    public DbSet<FilmFormatEntity> FilmFormatEntity => Set<FilmFormatEntity>();
/// <summary>Stores the gender entity value.</summary>
    public DbSet<GenderEntity> GenderEntity => Set<GenderEntity>();
/// <summary>Stores the genre entity value.</summary>
    public DbSet<GenreEntity> GenreEntity => Set<GenreEntity>();
/// <summary>Stores the hardware entity value.</summary>
    public DbSet<HardwareEntity> HardwareEntity => Set<HardwareEntity>();
/// <summary>Stores the image entity value.</summary>
    public DbSet<ImageEntity> ImageEntity => Set<ImageEntity>();
/// <summary>Stores the image source entity value.</summary>
    public DbSet<ImageSourceEntity> ImageSourceEntity => Set<ImageSourceEntity>();
/// <summary>Stores the image type entity value.</summary>
    public DbSet<ImageTypeEntity> ImageTypeEntity => Set<ImageTypeEntity>();
/// <summary>Stores the input device entity value.</summary>
    public DbSet<InputDeviceEntity> InputDeviceEntity => Set<InputDeviceEntity>();
/// <summary>Stores the input device feature entity value.</summary>
    public DbSet<InputDeviceFeatureEntity> InputDeviceFeatureEntity => Set<InputDeviceFeatureEntity>();
/// <summary>Stores the laboratory entity value.</summary>
    public DbSet<LaboratoryEntity> LaboratoryEntity => Set<LaboratoryEntity>();
/// <summary>Stores the language entity value.</summary>
    public DbSet<LanguageEntity> LanguageEntity => Set<LanguageEntity>();
/// <summary>Stores the location entity value.</summary>
    public DbSet<LocationEntity> LocationEntity => Set<LocationEntity>();
/// <summary>Stores the mac os sprocket entity value.</summary>
    public DbSet<MacOSSprocketEntity> MacOSSprocketEntity => Set<MacOSSprocketEntity>();
/// <summary>Stores the media type entity value.</summary>
    public DbSet<MediaTypeEntity> MediaTypeEntity => Set<MediaTypeEntity>();
/// <summary>Stores the movie entity value.</summary>
    public DbSet<MovieEntity> MovieEntity => Set<MovieEntity>();
/// <summary>Stores the movie aspect ratio entity value.</summary>
    public DbSet<MovieAspectRatioEntity> MovieAspectRatioEntity => Set<MovieAspectRatioEntity>();
/// <summary>Stores the movie award entity value.</summary>
    public DbSet<MovieAwardEntity> MovieAwardEntity => Set<MovieAwardEntity>();
/// <summary>Stores the movie award person entity value.</summary>
    public DbSet<MovieAwardPersonEntity> MovieAwardPersonEntity => Set<MovieAwardPersonEntity>();
/// <summary>Stores the movie camera entity value.</summary>
    public DbSet<MovieCameraEntity> MovieCameraEntity => Set<MovieCameraEntity>();
/// <summary>Stores the movie cast entity value.</summary>
    public DbSet<MovieCastEntity> MovieCastEntity => Set<MovieCastEntity>();
/// <summary>Stores the movie certification entity value.</summary>
    public DbSet<MovieCertificationEntity> MovieCertificationEntity => Set<MovieCertificationEntity>();
/// <summary>Stores the movie cinematographic process entity value.</summary>
    public DbSet<MovieCinematographicProcessEntity> MovieCinematographicProcessEntity => Set<MovieCinematographicProcessEntity>();
/// <summary>Stores the movie color entity value.</summary>
    public DbSet<MovieColorEntity> MovieColorEntity => Set<MovieColorEntity>();
/// <summary>Stores the movie company credits entity value.</summary>
    public DbSet<MovieCompanyCreditsEntity> MovieCompanyCreditsEntity => Set<MovieCompanyCreditsEntity>();
/// <summary>Stores the movie country entity value.</summary>
    public DbSet<MovieCountryEntity> MovieCountryEntity => Set<MovieCountryEntity>();
/// <summary>Stores the movie crew entity value.</summary>
    public DbSet<MovieCrewEntity> MovieCrewEntity => Set<MovieCrewEntity>();
/// <summary>Stores the movie film length entity value.</summary>
    public DbSet<MovieFilmLengthEntity> MovieFilmLengthEntity => Set<MovieFilmLengthEntity>();
/// <summary>Stores the movie filming date entity value.</summary>
    public DbSet<MovieFilmingDateEntity> MovieFilmingDateEntity => Set<MovieFilmingDateEntity>();
/// <summary>Stores the movie filming location entity value.</summary>
    public DbSet<MovieFilmingLocationEntity> MovieFilmingLocationEntity => Set<MovieFilmingLocationEntity>();
/// <summary>Stores the movie genre entity value.</summary>
    public DbSet<MovieGenreEntity> MovieGenreEntity => Set<MovieGenreEntity>();
/// <summary>Stores the movie image entity value.</summary>
    public DbSet<MovieImageEntity> MovieImageEntity => Set<MovieImageEntity>();
/// <summary>Stores the movie laboratory entity value.</summary>
    public DbSet<MovieLaboratoryEntity> MovieLaboratoryEntity => Set<MovieLaboratoryEntity>();
/// <summary>Stores the movie language entity value.</summary>
    public DbSet<MovieLanguageEntity> MovieLanguageEntity => Set<MovieLanguageEntity>();
/// <summary>Stores the movie negative format entity value.</summary>
    public DbSet<MovieNegativeFormatEntity> MovieNegativeFormatEntity => Set<MovieNegativeFormatEntity>();
/// <summary>Stores the movie printed film format entity value.</summary>
    public DbSet<MoviePrintedFilmFormatEntity> MoviePrintedFilmFormatEntity => Set<MoviePrintedFilmFormatEntity>();
/// <summary>Stores the movie production date entity value.</summary>
    public DbSet<MovieProductionDateEntity> MovieProductionDateEntity => Set<MovieProductionDateEntity>();
/// <summary>Stores the movie release date entity value.</summary>
    public DbSet<MovieReleaseDateEntity> MovieReleaseDateEntity => Set<MovieReleaseDateEntity>();
/// <summary>Stores the movie runtime entity value.</summary>
    public DbSet<MovieRuntimeEntity> MovieRuntimeEntity => Set<MovieRuntimeEntity>();
/// <summary>Stores the movie score entity value.</summary>
    public DbSet<MovieScoreEntity> MovieScoreEntity => Set<MovieScoreEntity>();
/// <summary>Stores the movie sound mix entity value.</summary>
    public DbSet<MovieSoundMixEntity> MovieSoundMixEntity => Set<MovieSoundMixEntity>();
/// <summary>Stores the movie text entity value.</summary>
    public DbSet<MovieTextEntity> MovieTextEntity => Set<MovieTextEntity>();
/// <summary>Stores the movie user entity value.</summary>
    public DbSet<MovieUserEntity> MovieUserEntity => Set<MovieUserEntity>();
/// <summary>Stores the movie weblink entity value.</summary>
    public DbSet<MovieWeblinkEntity> MovieWeblinkEntity => Set<MovieWeblinkEntity>();
/// <summary>Stores the multiplayer game mode entity value.</summary>
    public DbSet<MultiplayerGameModeEntity> MultiplayerGameModeEntity => Set<MultiplayerGameModeEntity>();
/// <summary>Stores the multiplayer option entity value.</summary>
    public DbSet<MultiplayerOptionEntity> MultiplayerOptionEntity => Set<MultiplayerOptionEntity>();
/// <summary>Stores the operating system entity value.</summary>
    public DbSet<OperatingSystemEntity> OperatingSystemEntity => Set<OperatingSystemEntity>();
/// <summary>Stores the person entity value.</summary>
    public DbSet<PersonEntity> PersonEntity => Set<PersonEntity>();
/// <summary>Stores the person employer entity value.</summary>
    public DbSet<PersonEmployerEntity> PersonEmployerEntity => Set<PersonEmployerEntity>();
/// <summary>Stores the person family entity value.</summary>
    public DbSet<PersonFamilyEntity> PersonFamilyEntity => Set<PersonFamilyEntity>();
/// <summary>Stores the person position entity value.</summary>
    public DbSet<PersonPositionEntity> PersonPositionEntity => Set<PersonPositionEntity>();
/// <summary>Stores the person profession entity value.</summary>
    public DbSet<PersonProfessionEntity> PersonProfessionEntity => Set<PersonProfessionEntity>();
/// <summary>Stores the person species entity value.</summary>
    public DbSet<PersonSpeciesEntity> PersonSpeciesEntity => Set<PersonSpeciesEntity>();
/// <summary>Stores the person text entity value.</summary>
    public DbSet<PersonTextEntity> PersonTextEntity => Set<PersonTextEntity>();
/// <summary>Stores the person weblink entity value.</summary>
    public DbSet<PersonWeblinkEntity> PersonWeblinkEntity => Set<PersonWeblinkEntity>();
/// <summary>Stores the perspective entity value.</summary>
    public DbSet<PerspectiveEntity> PerspectiveEntity => Set<PerspectiveEntity>();
/// <summary>Stores the platform entity value.</summary>
    public DbSet<PlatformEntity> PlatformEntity => Set<PlatformEntity>();
/// <summary>Stores the position entity value.</summary>
    public DbSet<PositionEntity> PositionEntity => Set<PositionEntity>();
/// <summary>Stores the priority entity value.</summary>
    public DbSet<PriorityEntity> PriorityEntity => Set<PriorityEntity>();
/// <summary>Stores the profession entity value.</summary>
    public DbSet<ProfessionEntity> ProfessionEntity => Set<ProfessionEntity>();
/// <summary>Stores the publication entity value.</summary>
    public DbSet<PublicationEntity> PublicationEntity => Set<PublicationEntity>();
/// <summary>Stores the publication certification entity value.</summary>
    public DbSet<PublicationCertificationEntity> PublicationCertificationEntity => Set<PublicationCertificationEntity>();
/// <summary>Stores the publication company credits entity value.</summary>
    public DbSet<PublicationCompanyCreditsEntity> PublicationCompanyCreditsEntity => Set<PublicationCompanyCreditsEntity>();
/// <summary>Stores the publication language entity value.</summary>
    public DbSet<PublicationLanguageEntity> PublicationLanguageEntity => Set<PublicationLanguageEntity>();
/// <summary>Stores the publication release date entity value.</summary>
    public DbSet<PublicationReleaseDateEntity> PublicationReleaseDateEntity => Set<PublicationReleaseDateEntity>();
/// <summary>Stores the publication text entity value.</summary>
    public DbSet<PublicationTextEntity> PublicationTextEntity => Set<PublicationTextEntity>();
/// <summary>Stores the ram entity value.</summary>
    public DbSet<RAMEntity> RAMEntity => Set<RAMEntity>();
/// <summary>Stores the relationship entity value.</summary>
    public DbSet<RelationshipEntity> RelationshipEntity => Set<RelationshipEntity>();
/// <summary>Stores the save game method entity value.</summary>
    public DbSet<SaveGameMethodEntity> SaveGameMethodEntity => Set<SaveGameMethodEntity>();
/// <summary>Stores the series entity value.</summary>
    public DbSet<SeriesEntity> SeriesEntity => Set<SeriesEntity>();
/// <summary>Stores the series aspect ratio entity value.</summary>
    public DbSet<SeriesAspectRatioEntity> SeriesAspectRatioEntity => Set<SeriesAspectRatioEntity>();
/// <summary>Stores the series award entity value.</summary>
    public DbSet<SeriesAwardEntity> SeriesAwardEntity => Set<SeriesAwardEntity>();
/// <summary>Stores the series award person entity value.</summary>
    public DbSet<SeriesAwardPersonEntity> SeriesAwardPersonEntity => Set<SeriesAwardPersonEntity>();
/// <summary>Stores the series camera entity value.</summary>
    public DbSet<SeriesCameraEntity> SeriesCameraEntity => Set<SeriesCameraEntity>();
/// <summary>Stores the series cast entity value.</summary>
    public DbSet<SeriesCastEntity> SeriesCastEntity => Set<SeriesCastEntity>();
/// <summary>Stores the series certification entity value.</summary>
    public DbSet<SeriesCertificationEntity> SeriesCertificationEntity => Set<SeriesCertificationEntity>();
/// <summary>Stores the series cinematographic process entity value.</summary>
    public DbSet<SeriesCinematographicProcessEntity> SeriesCinematographicProcessEntity => Set<SeriesCinematographicProcessEntity>();
/// <summary>Stores the series color entity value.</summary>
    public DbSet<SeriesColorEntity> SeriesColorEntity => Set<SeriesColorEntity>();
/// <summary>Stores the series company credits entity value.</summary>
    public DbSet<SeriesCompanyCreditsEntity> SeriesCompanyCreditsEntity => Set<SeriesCompanyCreditsEntity>();
/// <summary>Stores the series country entity value.</summary>
    public DbSet<SeriesCountryEntity> SeriesCountryEntity => Set<SeriesCountryEntity>();
/// <summary>Stores the series crew entity value.</summary>
    public DbSet<SeriesCrewEntity> SeriesCrewEntity => Set<SeriesCrewEntity>();
/// <summary>Stores the series film length entity value.</summary>
    public DbSet<SeriesFilmLengthEntity> SeriesFilmLengthEntity => Set<SeriesFilmLengthEntity>();
/// <summary>Stores the series filming date entity value.</summary>
    public DbSet<SeriesFilmingDateEntity> SeriesFilmingDateEntity => Set<SeriesFilmingDateEntity>();
/// <summary>Stores the series filming location entity value.</summary>
    public DbSet<SeriesFilmingLocationEntity> SeriesFilmingLocationEntity => Set<SeriesFilmingLocationEntity>();
/// <summary>Stores the series genre entity value.</summary>
    public DbSet<SeriesGenreEntity> SeriesGenreEntity => Set<SeriesGenreEntity>();
/// <summary>Stores the series image entity value.</summary>
    public DbSet<SeriesImageEntity> SeriesImageEntity => Set<SeriesImageEntity>();
/// <summary>Stores the series laboratory entity value.</summary>
    public DbSet<SeriesLaboratoryEntity> SeriesLaboratoryEntity => Set<SeriesLaboratoryEntity>();
/// <summary>Stores the series language entity value.</summary>
    public DbSet<SeriesLanguageEntity> SeriesLanguageEntity => Set<SeriesLanguageEntity>();
/// <summary>Stores the series negative format entity value.</summary>
    public DbSet<SeriesNegativeFormatEntity> SeriesNegativeFormatEntity => Set<SeriesNegativeFormatEntity>();
/// <summary>Stores the series printed film format entity value.</summary>
    public DbSet<SeriesPrintedFilmFormatEntity> SeriesPrintedFilmFormatEntity => Set<SeriesPrintedFilmFormatEntity>();
/// <summary>Stores the series production date entity value.</summary>
    public DbSet<SeriesProductionDateEntity> SeriesProductionDateEntity => Set<SeriesProductionDateEntity>();
/// <summary>Stores the series release date first episode entity value.</summary>
    public DbSet<SeriesReleaseDateFirstEpisodeEntity> SeriesReleaseDateFirstEpisodeEntity => Set<SeriesReleaseDateFirstEpisodeEntity>();
/// <summary>Stores the series release date last episode entity value.</summary>
    public DbSet<SeriesReleaseDateLastEpisodeEntity> SeriesReleaseDateLastEpisodeEntity => Set<SeriesReleaseDateLastEpisodeEntity>();
/// <summary>Stores the series runtime entity value.</summary>
    public DbSet<SeriesRuntimeEntity> SeriesRuntimeEntity => Set<SeriesRuntimeEntity>();
/// <summary>Stores the series score entity value.</summary>
    public DbSet<SeriesScoreEntity> SeriesScoreEntity => Set<SeriesScoreEntity>();
/// <summary>Stores the series sound mix entity value.</summary>
    public DbSet<SeriesSoundMixEntity> SeriesSoundMixEntity => Set<SeriesSoundMixEntity>();
/// <summary>Stores the series text entity value.</summary>
    public DbSet<SeriesTextEntity> SeriesTextEntity => Set<SeriesTextEntity>();
/// <summary>Stores the series user entity value.</summary>
    public DbSet<SeriesUserEntity> SeriesUserEntity => Set<SeriesUserEntity>();
/// <summary>Stores the series weblink entity value.</summary>
    public DbSet<SeriesWeblinkEntity> SeriesWeblinkEntity => Set<SeriesWeblinkEntity>();
/// <summary>Stores the setting entity value.</summary>
    public DbSet<SettingEntity> SettingEntity => Set<SettingEntity>();
/// <summary>Stores the sound device entity value.</summary>
    public DbSet<SoundDeviceEntity> SoundDeviceEntity => Set<SoundDeviceEntity>();
/// <summary>Stores the sound mix entity value.</summary>
    public DbSet<SoundMixEntity> SoundMixEntity => Set<SoundMixEntity>();
/// <summary>Stores the sound mode entity value.</summary>
    public DbSet<SoundModeEntity> SoundModeEntity => Set<SoundModeEntity>();
/// <summary>Stores the species entity value.</summary>
    public DbSet<SpeciesEntity> SpeciesEntity => Set<SpeciesEntity>();
/// <summary>Stores the status entity value.</summary>
    public DbSet<StatusEntity> StatusEntity => Set<StatusEntity>();
/// <summary>Stores the system entity value.</summary>
    public DbSet<SystemEntity> SystemEntity => Set<SystemEntity>();
/// <summary>Stores the technical specification entity value.</summary>
    public DbSet<TechnicalSpecificationEntity> TechnicalSpecificationEntity => Set<TechnicalSpecificationEntity>();
/// <summary>Stores the technical specification copy protection entity value.</summary>
    public DbSet<TechnicalSpecificationCopyProtectionEntity> TechnicalSpecificationCopyProtectionEntity => Set<TechnicalSpecificationCopyProtectionEntity>();
/// <summary>Stores the technical specification mac os sprocket entity value.</summary>
    public DbSet<TechnicalSpecificationMacOSSprocketEntity> TechnicalSpecificationMacOSSprocketEntity => Set<TechnicalSpecificationMacOSSprocketEntity>();
/// <summary>Stores the technical specification media type entity value.</summary>
    public DbSet<TechnicalSpecificationMediaTypeEntity> TechnicalSpecificationMediaTypeEntity => Set<TechnicalSpecificationMediaTypeEntity>();
/// <summary>Stores the technical specification multiplayer game mode entity value.</summary>
    public DbSet<TechnicalSpecificationMultiplayerGameModeEntity> TechnicalSpecificationMultiplayerGameModeEntity => Set<TechnicalSpecificationMultiplayerGameModeEntity>();
/// <summary>Stores the technical specification multiplayer option entity value.</summary>
    public DbSet<TechnicalSpecificationMultiplayerOptionEntity> TechnicalSpecificationMultiplayerOptionEntity => Set<TechnicalSpecificationMultiplayerOptionEntity>();
/// <summary>Stores the technical specification required additional hardware entity value.</summary>
    public DbSet<TechnicalSpecificationRequiredAdditionalHardwareEntity> TechnicalSpecificationRequiredAdditionalHardwareEntity => Set<TechnicalSpecificationRequiredAdditionalHardwareEntity>();
/// <summary>Stores the technical specification required input device entity value.</summary>
    public DbSet<TechnicalSpecificationRequiredInputDeviceEntity> TechnicalSpecificationRequiredInputDeviceEntity => Set<TechnicalSpecificationRequiredInputDeviceEntity>();
/// <summary>Stores the technical specification save game method entity value.</summary>
    public DbSet<TechnicalSpecificationSaveGameMethodEntity> TechnicalSpecificationSaveGameMethodEntity => Set<TechnicalSpecificationSaveGameMethodEntity>();
/// <summary>Stores the technical specification supported additional hardware entity value.</summary>
    public DbSet<TechnicalSpecificationSupportedAdditionalHardwareEntity> TechnicalSpecificationSupportedAdditionalHardwareEntity => Set<TechnicalSpecificationSupportedAdditionalHardwareEntity>();
/// <summary>Stores the technical specification supported driver entity value.</summary>
    public DbSet<TechnicalSpecificationSupportedDriverEntity> TechnicalSpecificationSupportedDriverEntity => Set<TechnicalSpecificationSupportedDriverEntity>();
/// <summary>Stores the technical specification supported input device entity value.</summary>
    public DbSet<TechnicalSpecificationSupportedInputDeviceEntity> TechnicalSpecificationSupportedInputDeviceEntity => Set<TechnicalSpecificationSupportedInputDeviceEntity>();
/// <summary>Stores the technical specification supported input device feature entity value.</summary>
    public DbSet<TechnicalSpecificationSupportedInputDeviceFeatureEntity> TechnicalSpecificationSupportedInputDeviceFeatureEntity => Set<TechnicalSpecificationSupportedInputDeviceFeatureEntity>();
/// <summary>Stores the technical specification supported sound device entity value.</summary>
    public DbSet<TechnicalSpecificationSupportedSoundDeviceEntity> TechnicalSpecificationSupportedSoundDeviceEntity => Set<TechnicalSpecificationSupportedSoundDeviceEntity>();
/// <summary>Stores the technical specification supported sound mode entity value.</summary>
    public DbSet<TechnicalSpecificationSupportedSoundModeEntity> TechnicalSpecificationSupportedSoundModeEntity => Set<TechnicalSpecificationSupportedSoundModeEntity>();
/// <summary>Stores the technical specification supported video mode entity value.</summary>
    public DbSet<TechnicalSpecificationSupportedVideoModeEntity> TechnicalSpecificationSupportedVideoModeEntity => Set<TechnicalSpecificationSupportedVideoModeEntity>();
/// <summary>Stores the technical specification supported video resolution entity value.</summary>
    public DbSet<TechnicalSpecificationSupportedVideoResolutionEntity> TechnicalSpecificationSupportedVideoResolutionEntity => Set<TechnicalSpecificationSupportedVideoResolutionEntity>();
/// <summary>Stores the text entity value.</summary>
    public DbSet<TextEntity> TextEntity => Set<TextEntity>();
/// <summary>Stores the text author entity value.</summary>
    public DbSet<TextAuthorEntity> TextAuthorEntity => Set<TextAuthorEntity>();
/// <summary>Stores the text source entity value.</summary>
    public DbSet<TextSourceEntity> TextSourceEntity => Set<TextSourceEntity>();
/// <summary>Stores the text type entity value.</summary>
    public DbSet<TextTypeEntity> TextTypeEntity => Set<TextTypeEntity>();
/// <summary>Stores the type entity value.</summary>
    public DbSet<TypeEntity> TypeEntity => Set<TypeEntity>();
/// <summary>Stores the user entity value.</summary>
    public DbSet<UserEntity> UserEntity => Set<UserEntity>();
/// <summary>Stores the version entity value.</summary>
    public DbSet<VersionEntity> VersionEntity => Set<VersionEntity>();
/// <summary>Stores the video game entity value.</summary>
    public DbSet<VideoGameEntity> VideoGameEntity => Set<VideoGameEntity>();
/// <summary>Stores the video game award entity value.</summary>
    public DbSet<VideoGameAwardEntity> VideoGameAwardEntity => Set<VideoGameAwardEntity>();
/// <summary>Stores the video game cast entity value.</summary>
    public DbSet<VideoGameCastEntity> VideoGameCastEntity => Set<VideoGameCastEntity>();
/// <summary>Stores the video game certification entity value.</summary>
    public DbSet<VideoGameCertificationEntity> VideoGameCertificationEntity => Set<VideoGameCertificationEntity>();
/// <summary>Stores the video game company credits entity value.</summary>
    public DbSet<VideoGameCompanyCreditsEntity> VideoGameCompanyCreditsEntity => Set<VideoGameCompanyCreditsEntity>();
/// <summary>Stores the video game completion entity value.</summary>
    public DbSet<VideoGameCompletionEntity> VideoGameCompletionEntity => Set<VideoGameCompletionEntity>();
/// <summary>Stores the video game crew entity value.</summary>
    public DbSet<VideoGameCrewEntity> VideoGameCrewEntity => Set<VideoGameCrewEntity>();
/// <summary>Stores the video game difficulty entity value.</summary>
    public DbSet<VideoGameDifficultyEntity> VideoGameDifficultyEntity => Set<VideoGameDifficultyEntity>();
/// <summary>Stores the video game genre entity value.</summary>
    public DbSet<VideoGameGenreEntity> VideoGameGenreEntity => Set<VideoGameGenreEntity>();
/// <summary>Stores the video game image entity value.</summary>
    public DbSet<VideoGameImageEntity> VideoGameImageEntity => Set<VideoGameImageEntity>();
/// <summary>Stores the video game language entity value.</summary>
    public DbSet<VideoGameLanguageEntity> VideoGameLanguageEntity => Set<VideoGameLanguageEntity>();
/// <summary>Stores the video game perspective entity value.</summary>
    public DbSet<VideoGamePerspectiveEntity> VideoGamePerspectiveEntity => Set<VideoGamePerspectiveEntity>();
/// <summary>Stores the video game release date entity value.</summary>
    public DbSet<VideoGameReleaseDateEntity> VideoGameReleaseDateEntity => Set<VideoGameReleaseDateEntity>();
/// <summary>Stores the video game score entity value.</summary>
    public DbSet<VideoGameScoreEntity> VideoGameScoreEntity => Set<VideoGameScoreEntity>();
/// <summary>Stores the video game setting entity value.</summary>
    public DbSet<VideoGameSettingEntity> VideoGameSettingEntity => Set<VideoGameSettingEntity>();
/// <summary>Stores the video game text entity value.</summary>
    public DbSet<VideoGameTextEntity> VideoGameTextEntity => Set<VideoGameTextEntity>();
/// <summary>Stores the video game user entity value.</summary>
    public DbSet<VideoGameUserEntity> VideoGameUserEntity => Set<VideoGameUserEntity>();
/// <summary>Stores the video game version entity value.</summary>
    public DbSet<VideoGameVersionEntity> VideoGameVersionEntity => Set<VideoGameVersionEntity>();
/// <summary>Stores the video game weblink entity value.</summary>
    public DbSet<VideoGameWeblinkEntity> VideoGameWeblinkEntity => Set<VideoGameWeblinkEntity>();
/// <summary>Stores the video mode entity value.</summary>
    public DbSet<VideoModeEntity> VideoModeEntity => Set<VideoModeEntity>();
/// <summary>Stores the video resolution entity value.</summary>
    public DbSet<VideoResolutionEntity> VideoResolutionEntity => Set<VideoResolutionEntity>();
/// <summary>Stores the weblink entity value.</summary>
    public DbSet<WeblinkEntity> WeblinkEntity => Set<WeblinkEntity>();

/// <summary>Initializes a new instance of the entertainment infothek db context type.</summary>
    public EntertainmentInfothekDbContext(DbContextOptions<EntertainmentInfothekDbContext> options) : base(options) { }

/// <summary>Executes the on model creating operation.</summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Every one of the 196 tables has an explicit configuration class.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntertainmentInfothekDbContext).Assembly);

        // The generated EF entities contain collection properties for every schema FK.
        // Most of those collections are convenience properties only; the actual FK
        // relationships are configured from the dependent side. If EF is allowed to
        // discover these collections by convention, it creates a second relationship
        // for many FKs (and therefore more relationships than exist in the schema).
        // Keep only the collection navigations that are explicitly paired in the
        // configuration; all other collection properties are ignored by EF.
        var configuredCollectionNavigations = new HashSet<string>(StringComparer.Ordinal)
        {
            $"{nameof(RAMEntity)}.{nameof(Entities.RAMEntity.TechnicalSpecificationMinimumRAMs)}",
            $"{nameof(RAMEntity)}.{nameof(Entities.RAMEntity.TechnicalSpecificationMinimumVideoRAMs)}",
            $"{nameof(LocationEntity)}.{nameof(Entities.LocationEntity.PersonLocationOfBirths)}",
            $"{nameof(LocationEntity)}.{nameof(Entities.LocationEntity.PersonLocationOfDeaths)}"
        };

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var collectionProperties = entityType.ClrType
                .GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                .Where(property =>
                    property.PropertyType.IsGenericType &&
                    property.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToList();

            foreach (var property in collectionProperties)
            {
                var key = $"{entityType.ClrType.Name}.{property.Name}";
                if (!configuredCollectionNavigations.Contains(key))
                    modelBuilder.Entity(entityType.ClrType).Ignore(property.Name);
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}
