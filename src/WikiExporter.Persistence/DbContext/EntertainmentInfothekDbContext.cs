using Microsoft.EntityFrameworkCore;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.DbContext;

/// <summary>Read-only EF Core DbContext for the EntertainmentInfothek SQLite database.</summary>
public sealed class EntertainmentInfothekDbContext : Microsoft.EntityFrameworkCore.DbContext
{
/// <summary>Stores aspect ratio entity for use by this component.</summary>
    public DbSet<AspectRatioEntity> AspectRatioEntity => Set<AspectRatioEntity>();
/// <summary>Stores award entity for use by this component.</summary>
    public DbSet<AwardEntity> AwardEntity => Set<AwardEntity>();
/// <summary>Stores book entity for use by this component.</summary>
    public DbSet<BookEntity> BookEntity => Set<BookEntity>();
/// <summary>Stores book award entity for use by this component.</summary>
    public DbSet<BookAwardEntity> BookAwardEntity => Set<BookAwardEntity>();
/// <summary>Stores book cast entity for use by this component.</summary>
    public DbSet<BookCastEntity> BookCastEntity => Set<BookCastEntity>();
/// <summary>Stores book crew entity for use by this component.</summary>
    public DbSet<BookCrewEntity> BookCrewEntity => Set<BookCrewEntity>();
/// <summary>Stores book genre entity for use by this component.</summary>
    public DbSet<BookGenreEntity> BookGenreEntity => Set<BookGenreEntity>();
/// <summary>Stores book image entity for use by this component.</summary>
    public DbSet<BookImageEntity> BookImageEntity => Set<BookImageEntity>();
/// <summary>Stores book language entity for use by this component.</summary>
    public DbSet<BookLanguageEntity> BookLanguageEntity => Set<BookLanguageEntity>();
/// <summary>Stores book score entity for use by this component.</summary>
    public DbSet<BookScoreEntity> BookScoreEntity => Set<BookScoreEntity>();
/// <summary>Stores book text entity for use by this component.</summary>
    public DbSet<BookTextEntity> BookTextEntity => Set<BookTextEntity>();
/// <summary>Stores book user entity for use by this component.</summary>
    public DbSet<BookUserEntity> BookUserEntity => Set<BookUserEntity>();
/// <summary>Stores book weblink entity for use by this component.</summary>
    public DbSet<BookWeblinkEntity> BookWeblinkEntity => Set<BookWeblinkEntity>();
/// <summary>Stores business model entity for use by this component.</summary>
    public DbSet<BusinessModelEntity> BusinessModelEntity => Set<BusinessModelEntity>();
/// <summary>Stores cdrom drive speed entity for use by this component.</summary>
    public DbSet<CDROMDriveSpeedEntity> CDROMDriveSpeedEntity => Set<CDROMDriveSpeedEntity>();
/// <summary>Stores cpu entity for use by this component.</summary>
    public DbSet<CPUEntity> CPUEntity => Set<CPUEntity>();
/// <summary>Stores camera entity for use by this component.</summary>
    public DbSet<CameraEntity> CameraEntity => Set<CameraEntity>();
/// <summary>Stores certification entity for use by this component.</summary>
    public DbSet<CertificationEntity> CertificationEntity => Set<CertificationEntity>();
/// <summary>Stores cinematographic process entity for use by this component.</summary>
    public DbSet<CinematographicProcessEntity> CinematographicProcessEntity => Set<CinematographicProcessEntity>();
/// <summary>Stores color entity for use by this component.</summary>
    public DbSet<ColorEntity> ColorEntity => Set<ColorEntity>();
/// <summary>Stores company entity for use by this component.</summary>
    public DbSet<CompanyEntity> CompanyEntity => Set<CompanyEntity>();
/// <summary>Stores connection entity for use by this component.</summary>
    public DbSet<ConnectionEntity> ConnectionEntity => Set<ConnectionEntity>();
/// <summary>Stores copy protection entity for use by this component.</summary>
    public DbSet<CopyProtectionEntity> CopyProtectionEntity => Set<CopyProtectionEntity>();
/// <summary>Stores country entity for use by this component.</summary>
    public DbSet<CountryEntity> CountryEntity => Set<CountryEntity>();
/// <summary>Stores department entity for use by this component.</summary>
    public DbSet<DepartmentEntity> DepartmentEntity => Set<DepartmentEntity>();
/// <summary>Stores difficulty entity for use by this component.</summary>
    public DbSet<DifficultyEntity> DifficultyEntity => Set<DifficultyEntity>();
/// <summary>Stores direct x entity for use by this component.</summary>
    public DbSet<DirectXEntity> DirectXEntity => Set<DirectXEntity>();
/// <summary>Stores driver entity for use by this component.</summary>
    public DbSet<DriverEntity> DriverEntity => Set<DriverEntity>();
/// <summary>Stores edition entity for use by this component.</summary>
    public DbSet<EditionEntity> EditionEntity => Set<EditionEntity>();
/// <summary>Stores employer entity for use by this component.</summary>
    public DbSet<EmployerEntity> EmployerEntity => Set<EmployerEntity>();
/// <summary>Stores episode entity for use by this component.</summary>
    public DbSet<EpisodeEntity> EpisodeEntity => Set<EpisodeEntity>();
/// <summary>Stores episode award entity for use by this component.</summary>
    public DbSet<EpisodeAwardEntity> EpisodeAwardEntity => Set<EpisodeAwardEntity>();
/// <summary>Stores episode award person entity for use by this component.</summary>
    public DbSet<EpisodeAwardPersonEntity> EpisodeAwardPersonEntity => Set<EpisodeAwardPersonEntity>();
/// <summary>Stores episode cast entity for use by this component.</summary>
    public DbSet<EpisodeCastEntity> EpisodeCastEntity => Set<EpisodeCastEntity>();
/// <summary>Stores episode certification entity for use by this component.</summary>
    public DbSet<EpisodeCertificationEntity> EpisodeCertificationEntity => Set<EpisodeCertificationEntity>();
/// <summary>Stores episode company credits entity for use by this component.</summary>
    public DbSet<EpisodeCompanyCreditsEntity> EpisodeCompanyCreditsEntity => Set<EpisodeCompanyCreditsEntity>();
/// <summary>Stores episode crew entity for use by this component.</summary>
    public DbSet<EpisodeCrewEntity> EpisodeCrewEntity => Set<EpisodeCrewEntity>();
/// <summary>Stores episode film length entity for use by this component.</summary>
    public DbSet<EpisodeFilmLengthEntity> EpisodeFilmLengthEntity => Set<EpisodeFilmLengthEntity>();
/// <summary>Stores episode filming date entity for use by this component.</summary>
    public DbSet<EpisodeFilmingDateEntity> EpisodeFilmingDateEntity => Set<EpisodeFilmingDateEntity>();
/// <summary>Stores episode filming location entity for use by this component.</summary>
    public DbSet<EpisodeFilmingLocationEntity> EpisodeFilmingLocationEntity => Set<EpisodeFilmingLocationEntity>();
/// <summary>Stores episode image entity for use by this component.</summary>
    public DbSet<EpisodeImageEntity> EpisodeImageEntity => Set<EpisodeImageEntity>();
/// <summary>Stores episode production date entity for use by this component.</summary>
    public DbSet<EpisodeProductionDateEntity> EpisodeProductionDateEntity => Set<EpisodeProductionDateEntity>();
/// <summary>Stores episode release date entity for use by this component.</summary>
    public DbSet<EpisodeReleaseDateEntity> EpisodeReleaseDateEntity => Set<EpisodeReleaseDateEntity>();
/// <summary>Stores episode runtime entity for use by this component.</summary>
    public DbSet<EpisodeRuntimeEntity> EpisodeRuntimeEntity => Set<EpisodeRuntimeEntity>();
/// <summary>Stores episode text entity for use by this component.</summary>
    public DbSet<EpisodeTextEntity> EpisodeTextEntity => Set<EpisodeTextEntity>();
/// <summary>Stores film format entity for use by this component.</summary>
    public DbSet<FilmFormatEntity> FilmFormatEntity => Set<FilmFormatEntity>();
/// <summary>Stores gender entity for use by this component.</summary>
    public DbSet<GenderEntity> GenderEntity => Set<GenderEntity>();
/// <summary>Stores genre entity for use by this component.</summary>
    public DbSet<GenreEntity> GenreEntity => Set<GenreEntity>();
/// <summary>Stores hardware entity for use by this component.</summary>
    public DbSet<HardwareEntity> HardwareEntity => Set<HardwareEntity>();
/// <summary>Stores image entity for use by this component.</summary>
    public DbSet<ImageEntity> ImageEntity => Set<ImageEntity>();
/// <summary>Stores image source entity for use by this component.</summary>
    public DbSet<ImageSourceEntity> ImageSourceEntity => Set<ImageSourceEntity>();
/// <summary>Stores image type entity for use by this component.</summary>
    public DbSet<ImageTypeEntity> ImageTypeEntity => Set<ImageTypeEntity>();
/// <summary>Stores input device entity for use by this component.</summary>
    public DbSet<InputDeviceEntity> InputDeviceEntity => Set<InputDeviceEntity>();
/// <summary>Stores input device feature entity for use by this component.</summary>
    public DbSet<InputDeviceFeatureEntity> InputDeviceFeatureEntity => Set<InputDeviceFeatureEntity>();
/// <summary>Stores laboratory entity for use by this component.</summary>
    public DbSet<LaboratoryEntity> LaboratoryEntity => Set<LaboratoryEntity>();
/// <summary>Stores language entity for use by this component.</summary>
    public DbSet<LanguageEntity> LanguageEntity => Set<LanguageEntity>();
/// <summary>Stores location entity for use by this component.</summary>
    public DbSet<LocationEntity> LocationEntity => Set<LocationEntity>();
/// <summary>Stores mac os sprocket entity for use by this component.</summary>
    public DbSet<MacOSSprocketEntity> MacOSSprocketEntity => Set<MacOSSprocketEntity>();
/// <summary>Stores media type entity for use by this component.</summary>
    public DbSet<MediaTypeEntity> MediaTypeEntity => Set<MediaTypeEntity>();
/// <summary>Stores movie entity for use by this component.</summary>
    public DbSet<MovieEntity> MovieEntity => Set<MovieEntity>();
/// <summary>Stores movie aspect ratio entity for use by this component.</summary>
    public DbSet<MovieAspectRatioEntity> MovieAspectRatioEntity => Set<MovieAspectRatioEntity>();
/// <summary>Stores movie award entity for use by this component.</summary>
    public DbSet<MovieAwardEntity> MovieAwardEntity => Set<MovieAwardEntity>();
/// <summary>Stores movie award person entity for use by this component.</summary>
    public DbSet<MovieAwardPersonEntity> MovieAwardPersonEntity => Set<MovieAwardPersonEntity>();
/// <summary>Stores movie camera entity for use by this component.</summary>
    public DbSet<MovieCameraEntity> MovieCameraEntity => Set<MovieCameraEntity>();
/// <summary>Stores movie cast entity for use by this component.</summary>
    public DbSet<MovieCastEntity> MovieCastEntity => Set<MovieCastEntity>();
/// <summary>Stores movie certification entity for use by this component.</summary>
    public DbSet<MovieCertificationEntity> MovieCertificationEntity => Set<MovieCertificationEntity>();
/// <summary>Stores movie cinematographic process entity for use by this component.</summary>
    public DbSet<MovieCinematographicProcessEntity> MovieCinematographicProcessEntity => Set<MovieCinematographicProcessEntity>();
/// <summary>Stores movie color entity for use by this component.</summary>
    public DbSet<MovieColorEntity> MovieColorEntity => Set<MovieColorEntity>();
/// <summary>Stores movie company credits entity for use by this component.</summary>
    public DbSet<MovieCompanyCreditsEntity> MovieCompanyCreditsEntity => Set<MovieCompanyCreditsEntity>();
/// <summary>Stores movie country entity for use by this component.</summary>
    public DbSet<MovieCountryEntity> MovieCountryEntity => Set<MovieCountryEntity>();
/// <summary>Stores movie crew entity for use by this component.</summary>
    public DbSet<MovieCrewEntity> MovieCrewEntity => Set<MovieCrewEntity>();
/// <summary>Stores movie film length entity for use by this component.</summary>
    public DbSet<MovieFilmLengthEntity> MovieFilmLengthEntity => Set<MovieFilmLengthEntity>();
/// <summary>Stores movie filming date entity for use by this component.</summary>
    public DbSet<MovieFilmingDateEntity> MovieFilmingDateEntity => Set<MovieFilmingDateEntity>();
/// <summary>Stores movie filming location entity for use by this component.</summary>
    public DbSet<MovieFilmingLocationEntity> MovieFilmingLocationEntity => Set<MovieFilmingLocationEntity>();
/// <summary>Stores movie genre entity for use by this component.</summary>
    public DbSet<MovieGenreEntity> MovieGenreEntity => Set<MovieGenreEntity>();
/// <summary>Stores movie image entity for use by this component.</summary>
    public DbSet<MovieImageEntity> MovieImageEntity => Set<MovieImageEntity>();
/// <summary>Stores movie laboratory entity for use by this component.</summary>
    public DbSet<MovieLaboratoryEntity> MovieLaboratoryEntity => Set<MovieLaboratoryEntity>();
/// <summary>Stores movie language entity for use by this component.</summary>
    public DbSet<MovieLanguageEntity> MovieLanguageEntity => Set<MovieLanguageEntity>();
/// <summary>Stores movie negative format entity for use by this component.</summary>
    public DbSet<MovieNegativeFormatEntity> MovieNegativeFormatEntity => Set<MovieNegativeFormatEntity>();
/// <summary>Stores movie printed film format entity for use by this component.</summary>
    public DbSet<MoviePrintedFilmFormatEntity> MoviePrintedFilmFormatEntity => Set<MoviePrintedFilmFormatEntity>();
/// <summary>Stores movie production date entity for use by this component.</summary>
    public DbSet<MovieProductionDateEntity> MovieProductionDateEntity => Set<MovieProductionDateEntity>();
/// <summary>Stores movie release date entity for use by this component.</summary>
    public DbSet<MovieReleaseDateEntity> MovieReleaseDateEntity => Set<MovieReleaseDateEntity>();
/// <summary>Stores movie runtime entity for use by this component.</summary>
    public DbSet<MovieRuntimeEntity> MovieRuntimeEntity => Set<MovieRuntimeEntity>();
/// <summary>Stores movie score entity for use by this component.</summary>
    public DbSet<MovieScoreEntity> MovieScoreEntity => Set<MovieScoreEntity>();
/// <summary>Stores movie sound mix entity for use by this component.</summary>
    public DbSet<MovieSoundMixEntity> MovieSoundMixEntity => Set<MovieSoundMixEntity>();
/// <summary>Stores movie text entity for use by this component.</summary>
    public DbSet<MovieTextEntity> MovieTextEntity => Set<MovieTextEntity>();
/// <summary>Stores movie user entity for use by this component.</summary>
    public DbSet<MovieUserEntity> MovieUserEntity => Set<MovieUserEntity>();
/// <summary>Stores movie weblink entity for use by this component.</summary>
    public DbSet<MovieWeblinkEntity> MovieWeblinkEntity => Set<MovieWeblinkEntity>();
/// <summary>Stores multiplayer game mode entity for use by this component.</summary>
    public DbSet<MultiplayerGameModeEntity> MultiplayerGameModeEntity => Set<MultiplayerGameModeEntity>();
/// <summary>Stores multiplayer option entity for use by this component.</summary>
    public DbSet<MultiplayerOptionEntity> MultiplayerOptionEntity => Set<MultiplayerOptionEntity>();
/// <summary>Stores operating system entity for use by this component.</summary>
    public DbSet<OperatingSystemEntity> OperatingSystemEntity => Set<OperatingSystemEntity>();
/// <summary>Stores person entity for use by this component.</summary>
    public DbSet<PersonEntity> PersonEntity => Set<PersonEntity>();
/// <summary>Stores person employer entity for use by this component.</summary>
    public DbSet<PersonEmployerEntity> PersonEmployerEntity => Set<PersonEmployerEntity>();
/// <summary>Stores person family entity for use by this component.</summary>
    public DbSet<PersonFamilyEntity> PersonFamilyEntity => Set<PersonFamilyEntity>();
/// <summary>Stores person position entity for use by this component.</summary>
    public DbSet<PersonPositionEntity> PersonPositionEntity => Set<PersonPositionEntity>();
/// <summary>Stores person profession entity for use by this component.</summary>
    public DbSet<PersonProfessionEntity> PersonProfessionEntity => Set<PersonProfessionEntity>();
/// <summary>Stores person species entity for use by this component.</summary>
    public DbSet<PersonSpeciesEntity> PersonSpeciesEntity => Set<PersonSpeciesEntity>();
/// <summary>Stores person text entity for use by this component.</summary>
    public DbSet<PersonTextEntity> PersonTextEntity => Set<PersonTextEntity>();
/// <summary>Stores person weblink entity for use by this component.</summary>
    public DbSet<PersonWeblinkEntity> PersonWeblinkEntity => Set<PersonWeblinkEntity>();
/// <summary>Stores perspective entity for use by this component.</summary>
    public DbSet<PerspectiveEntity> PerspectiveEntity => Set<PerspectiveEntity>();
/// <summary>Stores platform entity for use by this component.</summary>
    public DbSet<PlatformEntity> PlatformEntity => Set<PlatformEntity>();
/// <summary>Stores position entity for use by this component.</summary>
    public DbSet<PositionEntity> PositionEntity => Set<PositionEntity>();
/// <summary>Stores priority entity for use by this component.</summary>
    public DbSet<PriorityEntity> PriorityEntity => Set<PriorityEntity>();
/// <summary>Stores profession entity for use by this component.</summary>
    public DbSet<ProfessionEntity> ProfessionEntity => Set<ProfessionEntity>();
/// <summary>Stores publication entity for use by this component.</summary>
    public DbSet<PublicationEntity> PublicationEntity => Set<PublicationEntity>();
/// <summary>Stores publication certification entity for use by this component.</summary>
    public DbSet<PublicationCertificationEntity> PublicationCertificationEntity => Set<PublicationCertificationEntity>();
/// <summary>Stores publication company credits entity for use by this component.</summary>
    public DbSet<PublicationCompanyCreditsEntity> PublicationCompanyCreditsEntity => Set<PublicationCompanyCreditsEntity>();
/// <summary>Stores publication language entity for use by this component.</summary>
    public DbSet<PublicationLanguageEntity> PublicationLanguageEntity => Set<PublicationLanguageEntity>();
/// <summary>Stores publication release date entity for use by this component.</summary>
    public DbSet<PublicationReleaseDateEntity> PublicationReleaseDateEntity => Set<PublicationReleaseDateEntity>();
/// <summary>Stores publication text entity for use by this component.</summary>
    public DbSet<PublicationTextEntity> PublicationTextEntity => Set<PublicationTextEntity>();
/// <summary>Stores ram entity for use by this component.</summary>
    public DbSet<RAMEntity> RAMEntity => Set<RAMEntity>();
/// <summary>Stores relationship entity for use by this component.</summary>
    public DbSet<RelationshipEntity> RelationshipEntity => Set<RelationshipEntity>();
/// <summary>Stores save game method entity for use by this component.</summary>
    public DbSet<SaveGameMethodEntity> SaveGameMethodEntity => Set<SaveGameMethodEntity>();
/// <summary>Stores series entity for use by this component.</summary>
    public DbSet<SeriesEntity> SeriesEntity => Set<SeriesEntity>();
/// <summary>Stores series aspect ratio entity for use by this component.</summary>
    public DbSet<SeriesAspectRatioEntity> SeriesAspectRatioEntity => Set<SeriesAspectRatioEntity>();
/// <summary>Stores series award entity for use by this component.</summary>
    public DbSet<SeriesAwardEntity> SeriesAwardEntity => Set<SeriesAwardEntity>();
/// <summary>Stores series award person entity for use by this component.</summary>
    public DbSet<SeriesAwardPersonEntity> SeriesAwardPersonEntity => Set<SeriesAwardPersonEntity>();
/// <summary>Stores series camera entity for use by this component.</summary>
    public DbSet<SeriesCameraEntity> SeriesCameraEntity => Set<SeriesCameraEntity>();
/// <summary>Stores series cast entity for use by this component.</summary>
    public DbSet<SeriesCastEntity> SeriesCastEntity => Set<SeriesCastEntity>();
/// <summary>Stores series certification entity for use by this component.</summary>
    public DbSet<SeriesCertificationEntity> SeriesCertificationEntity => Set<SeriesCertificationEntity>();
/// <summary>Stores series cinematographic process entity for use by this component.</summary>
    public DbSet<SeriesCinematographicProcessEntity> SeriesCinematographicProcessEntity => Set<SeriesCinematographicProcessEntity>();
/// <summary>Stores series color entity for use by this component.</summary>
    public DbSet<SeriesColorEntity> SeriesColorEntity => Set<SeriesColorEntity>();
/// <summary>Stores series company credits entity for use by this component.</summary>
    public DbSet<SeriesCompanyCreditsEntity> SeriesCompanyCreditsEntity => Set<SeriesCompanyCreditsEntity>();
/// <summary>Stores series country entity for use by this component.</summary>
    public DbSet<SeriesCountryEntity> SeriesCountryEntity => Set<SeriesCountryEntity>();
/// <summary>Stores series crew entity for use by this component.</summary>
    public DbSet<SeriesCrewEntity> SeriesCrewEntity => Set<SeriesCrewEntity>();
/// <summary>Stores series film length entity for use by this component.</summary>
    public DbSet<SeriesFilmLengthEntity> SeriesFilmLengthEntity => Set<SeriesFilmLengthEntity>();
/// <summary>Stores series filming date entity for use by this component.</summary>
    public DbSet<SeriesFilmingDateEntity> SeriesFilmingDateEntity => Set<SeriesFilmingDateEntity>();
/// <summary>Stores series filming location entity for use by this component.</summary>
    public DbSet<SeriesFilmingLocationEntity> SeriesFilmingLocationEntity => Set<SeriesFilmingLocationEntity>();
/// <summary>Stores series genre entity for use by this component.</summary>
    public DbSet<SeriesGenreEntity> SeriesGenreEntity => Set<SeriesGenreEntity>();
/// <summary>Stores series image entity for use by this component.</summary>
    public DbSet<SeriesImageEntity> SeriesImageEntity => Set<SeriesImageEntity>();
/// <summary>Stores series laboratory entity for use by this component.</summary>
    public DbSet<SeriesLaboratoryEntity> SeriesLaboratoryEntity => Set<SeriesLaboratoryEntity>();
/// <summary>Stores series language entity for use by this component.</summary>
    public DbSet<SeriesLanguageEntity> SeriesLanguageEntity => Set<SeriesLanguageEntity>();
/// <summary>Stores series negative format entity for use by this component.</summary>
    public DbSet<SeriesNegativeFormatEntity> SeriesNegativeFormatEntity => Set<SeriesNegativeFormatEntity>();
/// <summary>Stores series printed film format entity for use by this component.</summary>
    public DbSet<SeriesPrintedFilmFormatEntity> SeriesPrintedFilmFormatEntity => Set<SeriesPrintedFilmFormatEntity>();
/// <summary>Stores series production date entity for use by this component.</summary>
    public DbSet<SeriesProductionDateEntity> SeriesProductionDateEntity => Set<SeriesProductionDateEntity>();
/// <summary>Stores series release date first episode entity for use by this component.</summary>
    public DbSet<SeriesReleaseDateFirstEpisodeEntity> SeriesReleaseDateFirstEpisodeEntity => Set<SeriesReleaseDateFirstEpisodeEntity>();
/// <summary>Stores series release date last episode entity for use by this component.</summary>
    public DbSet<SeriesReleaseDateLastEpisodeEntity> SeriesReleaseDateLastEpisodeEntity => Set<SeriesReleaseDateLastEpisodeEntity>();
/// <summary>Stores series runtime entity for use by this component.</summary>
    public DbSet<SeriesRuntimeEntity> SeriesRuntimeEntity => Set<SeriesRuntimeEntity>();
/// <summary>Stores series score entity for use by this component.</summary>
    public DbSet<SeriesScoreEntity> SeriesScoreEntity => Set<SeriesScoreEntity>();
/// <summary>Stores series sound mix entity for use by this component.</summary>
    public DbSet<SeriesSoundMixEntity> SeriesSoundMixEntity => Set<SeriesSoundMixEntity>();
/// <summary>Stores series text entity for use by this component.</summary>
    public DbSet<SeriesTextEntity> SeriesTextEntity => Set<SeriesTextEntity>();
/// <summary>Stores series user entity for use by this component.</summary>
    public DbSet<SeriesUserEntity> SeriesUserEntity => Set<SeriesUserEntity>();
/// <summary>Stores series weblink entity for use by this component.</summary>
    public DbSet<SeriesWeblinkEntity> SeriesWeblinkEntity => Set<SeriesWeblinkEntity>();
/// <summary>Stores setting entity for use by this component.</summary>
    public DbSet<SettingEntity> SettingEntity => Set<SettingEntity>();
/// <summary>Stores sound device entity for use by this component.</summary>
    public DbSet<SoundDeviceEntity> SoundDeviceEntity => Set<SoundDeviceEntity>();
/// <summary>Stores sound mix entity for use by this component.</summary>
    public DbSet<SoundMixEntity> SoundMixEntity => Set<SoundMixEntity>();
/// <summary>Stores sound mode entity for use by this component.</summary>
    public DbSet<SoundModeEntity> SoundModeEntity => Set<SoundModeEntity>();
/// <summary>Stores species entity for use by this component.</summary>
    public DbSet<SpeciesEntity> SpeciesEntity => Set<SpeciesEntity>();
/// <summary>Stores status entity for use by this component.</summary>
    public DbSet<StatusEntity> StatusEntity => Set<StatusEntity>();
/// <summary>Stores system entity for use by this component.</summary>
    public DbSet<SystemEntity> SystemEntity => Set<SystemEntity>();
/// <summary>Stores technical specification entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationEntity> TechnicalSpecificationEntity => Set<TechnicalSpecificationEntity>();
/// <summary>Stores technical specification copy protection entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationCopyProtectionEntity> TechnicalSpecificationCopyProtectionEntity => Set<TechnicalSpecificationCopyProtectionEntity>();
/// <summary>Stores technical specification mac os sprocket entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationMacOSSprocketEntity> TechnicalSpecificationMacOSSprocketEntity => Set<TechnicalSpecificationMacOSSprocketEntity>();
/// <summary>Stores technical specification media type entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationMediaTypeEntity> TechnicalSpecificationMediaTypeEntity => Set<TechnicalSpecificationMediaTypeEntity>();
/// <summary>Stores technical specification multiplayer game mode entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationMultiplayerGameModeEntity> TechnicalSpecificationMultiplayerGameModeEntity => Set<TechnicalSpecificationMultiplayerGameModeEntity>();
/// <summary>Stores technical specification multiplayer option entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationMultiplayerOptionEntity> TechnicalSpecificationMultiplayerOptionEntity => Set<TechnicalSpecificationMultiplayerOptionEntity>();
/// <summary>Stores technical specification required additional hardware entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationRequiredAdditionalHardwareEntity> TechnicalSpecificationRequiredAdditionalHardwareEntity => Set<TechnicalSpecificationRequiredAdditionalHardwareEntity>();
/// <summary>Stores technical specification required input device entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationRequiredInputDeviceEntity> TechnicalSpecificationRequiredInputDeviceEntity => Set<TechnicalSpecificationRequiredInputDeviceEntity>();
/// <summary>Stores technical specification save game method entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationSaveGameMethodEntity> TechnicalSpecificationSaveGameMethodEntity => Set<TechnicalSpecificationSaveGameMethodEntity>();
/// <summary>Stores technical specification supported additional hardware entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationSupportedAdditionalHardwareEntity> TechnicalSpecificationSupportedAdditionalHardwareEntity => Set<TechnicalSpecificationSupportedAdditionalHardwareEntity>();
/// <summary>Stores technical specification supported driver entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationSupportedDriverEntity> TechnicalSpecificationSupportedDriverEntity => Set<TechnicalSpecificationSupportedDriverEntity>();
/// <summary>Stores technical specification supported input device entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationSupportedInputDeviceEntity> TechnicalSpecificationSupportedInputDeviceEntity => Set<TechnicalSpecificationSupportedInputDeviceEntity>();
/// <summary>Stores technical specification supported input device feature entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationSupportedInputDeviceFeatureEntity> TechnicalSpecificationSupportedInputDeviceFeatureEntity => Set<TechnicalSpecificationSupportedInputDeviceFeatureEntity>();
/// <summary>Stores technical specification supported sound device entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationSupportedSoundDeviceEntity> TechnicalSpecificationSupportedSoundDeviceEntity => Set<TechnicalSpecificationSupportedSoundDeviceEntity>();
/// <summary>Stores technical specification supported sound mode entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationSupportedSoundModeEntity> TechnicalSpecificationSupportedSoundModeEntity => Set<TechnicalSpecificationSupportedSoundModeEntity>();
/// <summary>Stores technical specification supported video mode entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationSupportedVideoModeEntity> TechnicalSpecificationSupportedVideoModeEntity => Set<TechnicalSpecificationSupportedVideoModeEntity>();
/// <summary>Stores technical specification supported video resolution entity for use by this component.</summary>
    public DbSet<TechnicalSpecificationSupportedVideoResolutionEntity> TechnicalSpecificationSupportedVideoResolutionEntity => Set<TechnicalSpecificationSupportedVideoResolutionEntity>();
/// <summary>Stores text entity for use by this component.</summary>
    public DbSet<TextEntity> TextEntity => Set<TextEntity>();
/// <summary>Stores text author entity for use by this component.</summary>
    public DbSet<TextAuthorEntity> TextAuthorEntity => Set<TextAuthorEntity>();
/// <summary>Stores text source entity for use by this component.</summary>
    public DbSet<TextSourceEntity> TextSourceEntity => Set<TextSourceEntity>();
/// <summary>Stores text type entity for use by this component.</summary>
    public DbSet<TextTypeEntity> TextTypeEntity => Set<TextTypeEntity>();
/// <summary>Stores type entity for use by this component.</summary>
    public DbSet<TypeEntity> TypeEntity => Set<TypeEntity>();
/// <summary>Stores user entity for use by this component.</summary>
    public DbSet<UserEntity> UserEntity => Set<UserEntity>();
/// <summary>Stores version entity for use by this component.</summary>
    public DbSet<VersionEntity> VersionEntity => Set<VersionEntity>();
/// <summary>Stores video game entity for use by this component.</summary>
    public DbSet<VideoGameEntity> VideoGameEntity => Set<VideoGameEntity>();
/// <summary>Stores video game award entity for use by this component.</summary>
    public DbSet<VideoGameAwardEntity> VideoGameAwardEntity => Set<VideoGameAwardEntity>();
/// <summary>Stores video game cast entity for use by this component.</summary>
    public DbSet<VideoGameCastEntity> VideoGameCastEntity => Set<VideoGameCastEntity>();
/// <summary>Stores video game certification entity for use by this component.</summary>
    public DbSet<VideoGameCertificationEntity> VideoGameCertificationEntity => Set<VideoGameCertificationEntity>();
/// <summary>Stores video game company credits entity for use by this component.</summary>
    public DbSet<VideoGameCompanyCreditsEntity> VideoGameCompanyCreditsEntity => Set<VideoGameCompanyCreditsEntity>();
/// <summary>Stores video game completion entity for use by this component.</summary>
    public DbSet<VideoGameCompletionEntity> VideoGameCompletionEntity => Set<VideoGameCompletionEntity>();
/// <summary>Stores video game crew entity for use by this component.</summary>
    public DbSet<VideoGameCrewEntity> VideoGameCrewEntity => Set<VideoGameCrewEntity>();
/// <summary>Stores video game difficulty entity for use by this component.</summary>
    public DbSet<VideoGameDifficultyEntity> VideoGameDifficultyEntity => Set<VideoGameDifficultyEntity>();
/// <summary>Stores video game genre entity for use by this component.</summary>
    public DbSet<VideoGameGenreEntity> VideoGameGenreEntity => Set<VideoGameGenreEntity>();
/// <summary>Stores video game image entity for use by this component.</summary>
    public DbSet<VideoGameImageEntity> VideoGameImageEntity => Set<VideoGameImageEntity>();
/// <summary>Stores video game language entity for use by this component.</summary>
    public DbSet<VideoGameLanguageEntity> VideoGameLanguageEntity => Set<VideoGameLanguageEntity>();
/// <summary>Stores video game perspective entity for use by this component.</summary>
    public DbSet<VideoGamePerspectiveEntity> VideoGamePerspectiveEntity => Set<VideoGamePerspectiveEntity>();
/// <summary>Stores video game release date entity for use by this component.</summary>
    public DbSet<VideoGameReleaseDateEntity> VideoGameReleaseDateEntity => Set<VideoGameReleaseDateEntity>();
/// <summary>Stores video game score entity for use by this component.</summary>
    public DbSet<VideoGameScoreEntity> VideoGameScoreEntity => Set<VideoGameScoreEntity>();
/// <summary>Stores video game setting entity for use by this component.</summary>
    public DbSet<VideoGameSettingEntity> VideoGameSettingEntity => Set<VideoGameSettingEntity>();
/// <summary>Stores video game text entity for use by this component.</summary>
    public DbSet<VideoGameTextEntity> VideoGameTextEntity => Set<VideoGameTextEntity>();
/// <summary>Stores video game user entity for use by this component.</summary>
    public DbSet<VideoGameUserEntity> VideoGameUserEntity => Set<VideoGameUserEntity>();
/// <summary>Stores video game version entity for use by this component.</summary>
    public DbSet<VideoGameVersionEntity> VideoGameVersionEntity => Set<VideoGameVersionEntity>();
/// <summary>Stores video game weblink entity for use by this component.</summary>
    public DbSet<VideoGameWeblinkEntity> VideoGameWeblinkEntity => Set<VideoGameWeblinkEntity>();
/// <summary>Stores video mode entity for use by this component.</summary>
    public DbSet<VideoModeEntity> VideoModeEntity => Set<VideoModeEntity>();
/// <summary>Stores video resolution entity for use by this component.</summary>
    public DbSet<VideoResolutionEntity> VideoResolutionEntity => Set<VideoResolutionEntity>();
/// <summary>Stores weblink entity for use by this component.</summary>
    public DbSet<WeblinkEntity> WeblinkEntity => Set<WeblinkEntity>();

/// <summary>Initializes this entertainment infothek db context instance.</summary>
    public EntertainmentInfothekDbContext(DbContextOptions<EntertainmentInfothekDbContext> options) : base(options) { }

/// <summary>Performs the on model creating operation.</summary>
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
