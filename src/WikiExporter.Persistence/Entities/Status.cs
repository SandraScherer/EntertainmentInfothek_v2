using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Status</c>. The entity is persistence-only.</summary>
public sealed class Status
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

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<AspectRatio> AspectRatios { get; set; } = new List<AspectRatio>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Award> Awards { get; set; } = new List<Award>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Book> BookCastStatuss { get; set; } = new List<Book>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Book> BookCrewStatuss { get; set; } = new List<Book>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Book> BookStatuss { get; set; } = new List<Book>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookAward> BookAwards { get; set; } = new List<BookAward>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookCast> BookCasts { get; set; } = new List<BookCast>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookCrew> BookCrews { get; set; } = new List<BookCrew>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookImage> BookImages { get; set; } = new List<BookImage>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookLanguage> BookLanguages { get; set; } = new List<BookLanguage>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookScore> BookScores { get; set; } = new List<BookScore>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookText> BookTexts { get; set; } = new List<BookText>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookUser> BookUserStatuss { get; set; } = new List<BookUser>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookUser> BookUserUserStatuss { get; set; } = new List<BookUser>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BookWeblink> BookWeblinks { get; set; } = new List<BookWeblink>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<BusinessModel> BusinessModels { get; set; } = new List<BusinessModel>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<CDROMDriveSpeed> CDROMDriveSpeeds { get; set; } = new List<CDROMDriveSpeed>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<CPU> CPUs { get; set; } = new List<CPU>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Camera> Cameras { get; set; } = new List<Camera>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<CinematographicProcess> CinematographicProcesss { get; set; } = new List<CinematographicProcess>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Color> Colors { get; set; } = new List<Color>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Company> Companys { get; set; } = new List<Company>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Connection> Connections { get; set; } = new List<Connection>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<CopyProtection> CopyProtections { get; set; } = new List<CopyProtection>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Country> Countrys { get; set; } = new List<Country>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Department> Departments { get; set; } = new List<Department>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Difficulty> Difficultys { get; set; } = new List<Difficulty>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<DirectX> DirectXs { get; set; } = new List<DirectX>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Edition> Editions { get; set; } = new List<Edition>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Employer> Employers { get; set; } = new List<Employer>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Episode> EpisodeCastStatuss { get; set; } = new List<Episode>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Episode> EpisodeCrewStatuss { get; set; } = new List<Episode>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Episode> EpisodeStatuss { get; set; } = new List<Episode>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeAward> EpisodeAwards { get; set; } = new List<EpisodeAward>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeAwardPerson> EpisodeAwardPersons { get; set; } = new List<EpisodeAwardPerson>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeCast> EpisodeCasts { get; set; } = new List<EpisodeCast>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeCertification> EpisodeCertifications { get; set; } = new List<EpisodeCertification>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeCompanyCredits> EpisodeCompanyCreditss { get; set; } = new List<EpisodeCompanyCredits>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeCrew> EpisodeCrews { get; set; } = new List<EpisodeCrew>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeFilmLength> EpisodeFilmLengths { get; set; } = new List<EpisodeFilmLength>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeFilmingDate> EpisodeFilmingDates { get; set; } = new List<EpisodeFilmingDate>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeFilmingLocation> EpisodeFilmingLocations { get; set; } = new List<EpisodeFilmingLocation>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeImage> EpisodeImages { get; set; } = new List<EpisodeImage>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeProductionDate> EpisodeProductionDates { get; set; } = new List<EpisodeProductionDate>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeReleaseDate> EpisodeReleaseDates { get; set; } = new List<EpisodeReleaseDate>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeRuntime> EpisodeRuntimes { get; set; } = new List<EpisodeRuntime>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<EpisodeText> EpisodeTexts { get; set; } = new List<EpisodeText>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<FilmFormat> FilmFormats { get; set; } = new List<FilmFormat>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Gender> Genders { get; set; } = new List<Gender>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Hardware> Hardwares { get; set; } = new List<Hardware>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Image> Images { get; set; } = new List<Image>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<ImageSource> ImageSources { get; set; } = new List<ImageSource>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<ImageType> ImageTypes { get; set; } = new List<ImageType>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<InputDevice> InputDevices { get; set; } = new List<InputDevice>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<InputDeviceFeature> InputDeviceFeatures { get; set; } = new List<InputDeviceFeature>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Laboratory> Laboratorys { get; set; } = new List<Laboratory>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Language> Languages { get; set; } = new List<Language>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Location> Locations { get; set; } = new List<Location>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MacOSSprocket> MacOSSprockets { get; set; } = new List<MacOSSprocket>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MediaType> MediaTypes { get; set; } = new List<MediaType>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Movie> MovieCastStatuss { get; set; } = new List<Movie>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Movie> MovieCrewStatuss { get; set; } = new List<Movie>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Movie> MovieStatuss { get; set; } = new List<Movie>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieAspectRatio> MovieAspectRatios { get; set; } = new List<MovieAspectRatio>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieAward> MovieAwards { get; set; } = new List<MovieAward>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieAwardPerson> MovieAwardPersons { get; set; } = new List<MovieAwardPerson>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCamera> MovieCameras { get; set; } = new List<MovieCamera>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCast> MovieCasts { get; set; } = new List<MovieCast>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCertification> MovieCertifications { get; set; } = new List<MovieCertification>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCinematographicProcess> MovieCinematographicProcesss { get; set; } = new List<MovieCinematographicProcess>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieColor> MovieColors { get; set; } = new List<MovieColor>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCompanyCredits> MovieCompanyCreditss { get; set; } = new List<MovieCompanyCredits>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCountry> MovieCountrys { get; set; } = new List<MovieCountry>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieCrew> MovieCrews { get; set; } = new List<MovieCrew>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieFilmLength> MovieFilmLengths { get; set; } = new List<MovieFilmLength>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieFilmingDate> MovieFilmingDates { get; set; } = new List<MovieFilmingDate>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieFilmingLocation> MovieFilmingLocations { get; set; } = new List<MovieFilmingLocation>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieImage> MovieImages { get; set; } = new List<MovieImage>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieLaboratory> MovieLaboratorys { get; set; } = new List<MovieLaboratory>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieLanguage> MovieLanguages { get; set; } = new List<MovieLanguage>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieNegativeFormat> MovieNegativeFormats { get; set; } = new List<MovieNegativeFormat>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MoviePrintedFilmFormat> MoviePrintedFilmFormats { get; set; } = new List<MoviePrintedFilmFormat>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieProductionDate> MovieProductionDates { get; set; } = new List<MovieProductionDate>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieReleaseDate> MovieReleaseDates { get; set; } = new List<MovieReleaseDate>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieRuntime> MovieRuntimes { get; set; } = new List<MovieRuntime>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieScore> MovieScores { get; set; } = new List<MovieScore>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieSoundMix> MovieSoundMixs { get; set; } = new List<MovieSoundMix>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieText> MovieTexts { get; set; } = new List<MovieText>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieUser> MovieUserStatuss { get; set; } = new List<MovieUser>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieUser> MovieUserUserStatuss { get; set; } = new List<MovieUser>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MovieWeblink> MovieWeblinks { get; set; } = new List<MovieWeblink>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MultiplayerGameMode> MultiplayerGameModes { get; set; } = new List<MultiplayerGameMode>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<MultiplayerOption> MultiplayerOptions { get; set; } = new List<MultiplayerOption>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<OperatingSystem> OperatingSystems { get; set; } = new List<OperatingSystem>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Person> Persons { get; set; } = new List<Person>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonEmployer> PersonEmployers { get; set; } = new List<PersonEmployer>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonFamily> PersonFamilys { get; set; } = new List<PersonFamily>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonPosition> PersonPositions { get; set; } = new List<PersonPosition>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonProfession> PersonProfessions { get; set; } = new List<PersonProfession>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonSpecies> PersonSpeciess { get; set; } = new List<PersonSpecies>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonText> PersonTexts { get; set; } = new List<PersonText>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PersonWeblink> PersonWeblinks { get; set; } = new List<PersonWeblink>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Perspective> Perspectives { get; set; } = new List<Perspective>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Platform> Platforms { get; set; } = new List<Platform>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Position> Positions { get; set; } = new List<Position>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Priority> Prioritys { get; set; } = new List<Priority>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Profession> Professions { get; set; } = new List<Profession>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Publication> Publications { get; set; } = new List<Publication>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PublicationCertification> PublicationCertifications { get; set; } = new List<PublicationCertification>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PublicationCompanyCredits> PublicationCompanyCreditss { get; set; } = new List<PublicationCompanyCredits>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PublicationLanguage> PublicationLanguages { get; set; } = new List<PublicationLanguage>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PublicationReleaseDate> PublicationReleaseDates { get; set; } = new List<PublicationReleaseDate>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<PublicationText> PublicationTexts { get; set; } = new List<PublicationText>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<RAM> RAMs { get; set; } = new List<RAM>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Relationship> Relationships { get; set; } = new List<Relationship>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SaveGameMethod> SaveGameMethods { get; set; } = new List<SaveGameMethod>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Series> SeriesCastStatuss { get; set; } = new List<Series>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Series> SeriesCrewStatuss { get; set; } = new List<Series>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Series> SeriesStatuss { get; set; } = new List<Series>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesAspectRatio> SeriesAspectRatios { get; set; } = new List<SeriesAspectRatio>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesAward> SeriesAwards { get; set; } = new List<SeriesAward>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesAwardPerson> SeriesAwardPersons { get; set; } = new List<SeriesAwardPerson>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCamera> SeriesCameras { get; set; } = new List<SeriesCamera>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCast> SeriesCasts { get; set; } = new List<SeriesCast>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCertification> SeriesCertifications { get; set; } = new List<SeriesCertification>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCinematographicProcess> SeriesCinematographicProcesss { get; set; } = new List<SeriesCinematographicProcess>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesColor> SeriesColors { get; set; } = new List<SeriesColor>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCompanyCredits> SeriesCompanyCreditss { get; set; } = new List<SeriesCompanyCredits>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCountry> SeriesCountrys { get; set; } = new List<SeriesCountry>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesCrew> SeriesCrews { get; set; } = new List<SeriesCrew>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesFilmLength> SeriesFilmLengths { get; set; } = new List<SeriesFilmLength>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesFilmingDate> SeriesFilmingDates { get; set; } = new List<SeriesFilmingDate>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesFilmingLocation> SeriesFilmingLocations { get; set; } = new List<SeriesFilmingLocation>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesGenre> SeriesGenres { get; set; } = new List<SeriesGenre>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesImage> SeriesImages { get; set; } = new List<SeriesImage>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesLaboratory> SeriesLaboratorys { get; set; } = new List<SeriesLaboratory>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesLanguage> SeriesLanguages { get; set; } = new List<SeriesLanguage>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesNegativeFormat> SeriesNegativeFormats { get; set; } = new List<SeriesNegativeFormat>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesPrintedFilmFormat> SeriesPrintedFilmFormats { get; set; } = new List<SeriesPrintedFilmFormat>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesProductionDate> SeriesProductionDates { get; set; } = new List<SeriesProductionDate>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesReleaseDateFirstEpisode> SeriesReleaseDateFirstEpisodes { get; set; } = new List<SeriesReleaseDateFirstEpisode>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesReleaseDateLastEpisode> SeriesReleaseDateLastEpisodes { get; set; } = new List<SeriesReleaseDateLastEpisode>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesRuntime> SeriesRuntimes { get; set; } = new List<SeriesRuntime>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesScore> SeriesScores { get; set; } = new List<SeriesScore>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesSoundMix> SeriesSoundMixs { get; set; } = new List<SeriesSoundMix>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesText> SeriesTexts { get; set; } = new List<SeriesText>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesUser> SeriesUserStatuss { get; set; } = new List<SeriesUser>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesUser> SeriesUserUserStatuss { get; set; } = new List<SeriesUser>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SeriesWeblink> SeriesWeblinks { get; set; } = new List<SeriesWeblink>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Setting> Settings { get; set; } = new List<Setting>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SoundDevice> SoundDevices { get; set; } = new List<SoundDevice>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SoundMix> SoundMixs { get; set; } = new List<SoundMix>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<SoundMode> SoundModes { get; set; } = new List<SoundMode>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Species> Speciess { get; set; } = new List<Species>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Status> Statuss { get; set; } = new List<Status>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<System> Systems { get; set; } = new List<System>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecification> TechnicalSpecifications { get; set; } = new List<TechnicalSpecification>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationCopyProtection> TechnicalSpecificationCopyProtections { get; set; } = new List<TechnicalSpecificationCopyProtection>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationMacOSSprocket> TechnicalSpecificationMacOSSprockets { get; set; } = new List<TechnicalSpecificationMacOSSprocket>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationMediaType> TechnicalSpecificationMediaTypes { get; set; } = new List<TechnicalSpecificationMediaType>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationMultiplayerGameMode> TechnicalSpecificationMultiplayerGameModes { get; set; } = new List<TechnicalSpecificationMultiplayerGameMode>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationMultiplayerOption> TechnicalSpecificationMultiplayerOptions { get; set; } = new List<TechnicalSpecificationMultiplayerOption>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationRequiredAdditionalHardware> TechnicalSpecificationRequiredAdditionalHardwares { get; set; } = new List<TechnicalSpecificationRequiredAdditionalHardware>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationRequiredInputDevice> TechnicalSpecificationRequiredInputDevices { get; set; } = new List<TechnicalSpecificationRequiredInputDevice>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSaveGameMethod> TechnicalSpecificationSaveGameMethods { get; set; } = new List<TechnicalSpecificationSaveGameMethod>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedAdditionalHardware> TechnicalSpecificationSupportedAdditionalHardwares { get; set; } = new List<TechnicalSpecificationSupportedAdditionalHardware>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedDriver> TechnicalSpecificationSupportedDrivers { get; set; } = new List<TechnicalSpecificationSupportedDriver>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDevice> TechnicalSpecificationSupportedInputDevices { get; set; } = new List<TechnicalSpecificationSupportedInputDevice>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedInputDeviceFeature> TechnicalSpecificationSupportedInputDeviceFeatures { get; set; } = new List<TechnicalSpecificationSupportedInputDeviceFeature>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundDevice> TechnicalSpecificationSupportedSoundDevices { get; set; } = new List<TechnicalSpecificationSupportedSoundDevice>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedSoundMode> TechnicalSpecificationSupportedSoundModes { get; set; } = new List<TechnicalSpecificationSupportedSoundMode>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoMode> TechnicalSpecificationSupportedVideoModes { get; set; } = new List<TechnicalSpecificationSupportedVideoMode>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TechnicalSpecificationSupportedVideoResolution> TechnicalSpecificationSupportedVideoResolutions { get; set; } = new List<TechnicalSpecificationSupportedVideoResolution>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Text> Texts { get; set; } = new List<Text>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TextAuthor> TextAuthors { get; set; } = new List<TextAuthor>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TextSource> TextSources { get; set; } = new List<TextSource>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<TextType> TextTypes { get; set; } = new List<TextType>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Type> Types { get; set; } = new List<Type>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<User> Users { get; set; } = new List<User>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Version> Versions { get; set; } = new List<Version>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGame> VideoGameCastStatuss { get; set; } = new List<VideoGame>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGame> VideoGameCrewStatuss { get; set; } = new List<VideoGame>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGame> VideoGameStatuss { get; set; } = new List<VideoGame>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameAward> VideoGameAwards { get; set; } = new List<VideoGameAward>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameCast> VideoGameCasts { get; set; } = new List<VideoGameCast>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameCertification> VideoGameCertifications { get; set; } = new List<VideoGameCertification>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameCompanyCredits> VideoGameCompanyCreditss { get; set; } = new List<VideoGameCompanyCredits>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameCompletion> VideoGameCompletionCompletionStatuss { get; set; } = new List<VideoGameCompletion>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameCompletion> VideoGameCompletionStatuss { get; set; } = new List<VideoGameCompletion>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameCrew> VideoGameCrews { get; set; } = new List<VideoGameCrew>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameDifficulty> VideoGameDifficultys { get; set; } = new List<VideoGameDifficulty>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameGenre> VideoGameGenres { get; set; } = new List<VideoGameGenre>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameImage> VideoGameImages { get; set; } = new List<VideoGameImage>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameLanguage> VideoGameLanguages { get; set; } = new List<VideoGameLanguage>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGamePerspective> VideoGamePerspectives { get; set; } = new List<VideoGamePerspective>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameReleaseDate> VideoGameReleaseDates { get; set; } = new List<VideoGameReleaseDate>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameScore> VideoGameScores { get; set; } = new List<VideoGameScore>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameSetting> VideoGameSettings { get; set; } = new List<VideoGameSetting>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameText> VideoGameTexts { get; set; } = new List<VideoGameText>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameUser> VideoGameUserStatuss { get; set; } = new List<VideoGameUser>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameUser> VideoGameUserUserStatuss { get; set; } = new List<VideoGameUser>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameVersion> VideoGameVersions { get; set; } = new List<VideoGameVersion>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoGameWeblink> VideoGameWeblinks { get; set; } = new List<VideoGameWeblink>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoMode> VideoModes { get; set; } = new List<VideoMode>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<VideoResolution> VideoResolutions { get; set; } = new List<VideoResolution>();

    /// <summary>Dependent rows referencing this Status.</summary>
    public ICollection<Weblink> Weblinks { get; set; } = new List<Weblink>();
}
