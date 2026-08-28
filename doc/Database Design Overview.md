# Database Design Overview

## Article Tables and their Dependents

| Book          | Episode                  | Movie                    | Series                   | VideoGame          |
| ------------- | ------------------------ | ------------------------ | ------------------------ | ------------------ |
| ID            | ID                       | ID                       | ID                       | ID                 |
| OriginalTitle | OriginalTitle            | OriginalTitle            | OriginalTitle            | OriginalTitle      |
| EnglishTitle  | EnglishTitle             | EnglishTitle             | EnglishTitle             | EnglishTitle       |
| GermanTitle   | GermanTitle              | GemanTitle               | GermanTitle              | GermanTitle        |
| TypeID        |                          | TypeID                   | TypeID                   | TypeID             |
|               | SeriesID                 |                          |                          |                    |
|               |                          |                          | NoOfSeasons              |                    |
|               | SeasonNo                 |                          |                          |                    |
|               |                          |                          | NoOfEpisodes             |                    |
|               | EpisodeNo                |                          |                          |                    |
|               |                          | Budget                   | Budget                   | Budget             |
|               |                          | WorldwideGross           | WorldwideGross           | WorldwideGross     |
|               |                          | WorldwideGrossDate       | WorldwideGrossDate       | WorldwideGrossDate |
| CastStatusID  | CastStatusID             | CastStatusID             | CastStatusID             | CastStatusID       |
|               | CrewStatusID             | CrewStatusID             | CrewSTatusID             | CrewStatusID       |
| ConnectionID  |                          | ConnectionID             | ConnectionID             | ConnectionID       |
| Details       | Details                  | Details                  | Details                  | Details            |
| Notes         | Notes                    | Notes                    | Notes                    | Notes              |
| StatusID      | StatusID                 | StatusID                 | StatusID                 | StatusID           |
| LastUpdated   | LastUpdated              | LastUpdated              | LastUpdated              | LastUpdated        |
| ---           | ---                      | ---                      | ---                      | ---                |
|               |                          | AspectRatio              | AspectRatio              |                    |
| Award         | Award                    | Award                    | Award                    | Award              |
|               | Award_Person             | Award_Person             | Award_Person             |                    |
|               |                          | Camera                   | Camera                   |                    |
| Cast          | Cast                     | Cast                     | Cast                     | Cast               |
|               | Certification            | Certification            | Certification            | Certification      |
|               |                          | CinematographicProcess   | CinematographicProcess   |                    |
|               |                          | Color                    | Color                    |                    |
|               | CompanyCredits           | CompanyCredits           | CompanyCredits           | CompanyCredits     |
|               |                          |                          |                          | Completion         |
|               |                          | Country                  | Country                  |                    |
| Crew          | Crew                     | Crew                     | Crew                     | Crew               |
|               |                          |                          |                          | Difficulty         |
|               | FilmLength               | FilmLength               | FilmLength               |                    |
|               | FilmingDate              | FilmingDate              | FilmingDate              |                    |
|               | FilmingLocation          | FilmingLocation          | FilmingLocation          |                    |
| Genre         |                          | Genre                    | Genre                    | Genre              |
| Image         | Image                    | Image                    | Image                    | Image              |
|               |                          | Laboratory               | Laboratory               |                    |
| Language      |                          | Language                 | Language                 | Language           |
|               |                          | NegativeFormat           | NegativeFormat           |                    |
|               |                          |                          |                          | Perspective        |
|               |                          | PrintedFilmFormat        | PrintedFilmFormat        |                    |
|               | ProductionDate           | ProductionDate           | ProductionDate           |                    |
| Publication   |                          |                          |                          |                    |
|               | ReleaseDate              | ReleaseDate              |                          | ReleaseDate        |
|               |                          |                          | ReleaseDateFirstEpisode  |                    |
|               |                          |                          | ReleaseDateLastEpisode   |                    |
|               | Runtime                  | Runtime                  | Runtime                  |                    |
| Score         |                          | Score                    | Score                    | Score              |
|               |                          |                          |                          | Setting            |
|               |                          | SoundMix                 | SoundMix                 |                    |
| Text          | Text                     | Text                     | Text                     | Text               |
| User          |                          | User                     | User                     | User               |
|               |                          |                          |                          | Version            |
| Weblink       |                          | Weblink                  | Weblink                  | Weblink            |


## Special Reference Tables and their Dependents

| Publication | TechnicalSpecification      |     |
| ----------- | --------------------------- | --- |
| (todo)      |                             |     |
|             | ID                          |     |
|             | VideoGameID                 |     |
|             | PlatformID                  |     |
|             | BusinessModelID             |     |
|             | MinimumCPUClassID           |     |
|             | MinimumOSClassID            |     |
|             | MinimumRAMID                |     |
|             | MinimumDirectXID            |     |
|             | MinimumCDRomDriveSpeedID    |     |
|             | MinimumVideoRAMID           |     |
|             | NoOfPlayersOffline          |     |
|             | NoOfPlayersOfflineMultitap  |     |
|             | NoOfPlayersOnline           |     |
|             | Annotation                  |     |
|             | MiscAttributes              |     |
|             | Details                     |     |
|             | Notes                       |     |
|             | StatusID                    |     |
|             | LastUpdated                 |     |
|             | ---                         |     |
|             | CopyProtection              |     |
|             | MacOSSprocket               |     |
|             | MediaType                   |     |
|             | MultiplayerGameMode         |     |
|             | MultiplayerOption           |     |
|             | RequiredAdditionalHardware  |     |
|             | RequiredInputDevice         |     |
|             | SaveGameMethod              |     |
|             | SupportedAdditionalHardware |     |
|             | SupportedControllerType     |     |
|             | SupportedDriver             |     |
|             | SupportedInputDevice        |     |
|             | SupportedInputDeviceFeature |     |
|             | SupportedSoundDevice        |     |
|             | SupportedSoundMode          |     |
|             | SupportedVideoMode          |     |
|             | SupportedVideoResolution    |     |


## "Bigger" Reference Tables (with and without Dependents)

| Award        | Certification | Company      | Connection   | Employer    | Image              | Laboratory  | Location    | Person              | Publication   | Text         | User         | Version      | Weblink     |     |
| ------------ | ------------- | ------------ | ------------ | ----------- | ------------------ | ----------- | ----------- | ------------------- | ------------- | ------------ | ------------ | ------------ | ----------- | --- |
| ID           | ID            | ID           | ID           | ID          | ID                 | ID          | ID          | ID                  | ID            | ID           | ID           | ID           | ID          |     |
|              |               |              |              |             |                    |             |             |                     |               |              |              |              | URL         |     |
|              |               |              |              | CompanyID   |                    |             |             |                     |               |              |              |              | URL         |     |
| OriginalName | OriginalName  | OriginalName | OriginalName |             |                    |             |             |                     |               |              | OriginalName | OriginalName |             |     |
|              |               |              |              | EnglishName |                    |             | EnglishName |                     |               |              |              |              | EnglishName |     |
|              |               |              |              | GermanName  |                    |             | GermanName  |                     |               |              |              |              | GermanName  |     |
|              |               |              |              |             |                    |             |             | FirstName           |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | LastName            |               |              |              |              |             |     |
|              |               | NameAddOn    |              |             |                    |             |             | NameAddOn           |               |              |              |              |             |     |
|              |               |              |              |             | FileName           |             |             |                     |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     |               |              | EMail        |              |             |     |
|              |               |              |              |             |                    |             |             | BirthName           |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     |               | Content      |              |              |             |     |
|              |               |              |              |             | EnglishDescription |             |             |                     |               |              |              |              |             |     |
|              |               |              |              |             | GermanDescription  |             |             |                     |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     | ISBN13        |              |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     | ISBN10        |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | DateOfBirth         |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     | ReleaseDate   |              |              | ReleaseDate  |             |     |
|              | ImageID       |              |              |             |                    |             |             |                     |               |              |              |              |             |     |
|              |               |              |              |             |                    | LocationID  | LocationID  | LocationOfBirthID   |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | DateOfDeath         |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | LocationOfDeathID   |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | EnglishCauseOfDeath |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | GermanCauseOfDeath  |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | GenderID            |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | Height              |               |              |              |              |             |     |
|              |               | TypeID       |              |             |                    |             |             | TypeID              |               |              |              | TypeID       |             |     |
|              | CountryID     |              |              |             |                    |             | CountryID   |                     |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     |               | LanguageID   |              |              | LanguageID  |     |
|              |               |              | ConnectionID |             |                    |             |             |                     |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     | FormatID      |              |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     | EditionID     |              |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     |               |              |              | PlatformID   |             |     |
|              |               |              |              |             |                    |             |             |                     | NoOfPages     |              |              |              |             |     |
| PresenterID  |               |              |              |             |                    |             |             |                     |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     |               |              | PersonID     |              |             |     |
| EnglishRole  |               |              |              |             |                    |             |             |                     |               |              | EnglishRole  |              |             |     |
| GermanRole   |               |              |              |             |                    |             |             |                     |               |              | GermanRole   |              |             |     |
| Details      | Details       | Details      | Details      | Details     | Details            | Details     | Details     | Details             | Details       | Details      | Details      | Details      | Details     |     |
| Notes        | Notes         | Notes        | Notes        | Notes       | Notes              | Notes       | Notes       | Notes               | Notes         | Notes        | Notes        | Notes        | Notes       |     |
| StatusID     | StatusID      | StatusID     | StatusID     | StatusID    | StatusID           | StatusID    | StatusID    | StatusID            | StatusID      | StatusID     | StatusID     | StatusID     | StatusID    |     |
| LastUpdated  | LastUpdated   | LastUpdated  | LastUpdated  | LastUpdated | LastUpdated        | LastUpdated | LastUpdated | LastUpdated         | LastUpdated   | LastUpdated  | LastUpdated  | LastUpdated  | LastUpdated |     |
| ---          | ---           | ---          | ---          | ---         | ---                | ---         | ---         | ---                 | ---           | ---          | ---          | ---          | ---         |     |
|              |               |              |              |             |                    |             |             |                     |               | Author       |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     | Certification |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | Description         |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | Employer            |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | Family              |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     | Language      |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | Position            |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | Profession          |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             |                     | Publisher     |              |              |              |             |     |
|              |               |              |              |             | Source             |             |             |                     |               | Source       |              |              |             |     |
|              |               |              |              |             |                    |             |             | Species             |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | Text                |               |              |              |              |             |     |
|              |               |              |              |             |                    |             |             | Weblink             |               |              |              |              |             |     |


## Basic Reference Tables (no Dependents)

| AspectRatio  | BusinessModel | CDROMDriveSpeed | CPU          | Camera       | CinematographicProcess | Color       | ControllerType | CopyProtection | Country           | Department  | Difficulty  | DirectX      | Driver      | Edition     | FilmFormat   | Genre       | Hardware    | InputDevice | InputDeviceFeature | Language     | MacOSSprocket | MediaType    | MultiplayerGameMode | MultiplayerOption | OperatingSystem | Perspective | Platform     | Position    | Priority    | Profession  | RAM          | SaveGameMethod | Setting     | SoundDevice | SoundMix     | SoundMode    | Species     | Status      | System      | Type        | VideoMode   | VideoResolution |     |
| ------------ | ------------- | --------------- | ------------ | ------------ | ---------------------- | ----------- | -------------- | -------------- | ----------------- | ----------- | ----------- | ------------ | ----------- | ----------- | ------------ | ----------- | ----------- | ----------- | ------------------ | ------------ | ------------- | ------------ | ------------------- | ----------------- | --------------- | ----------- | ------------ | ----------- | ----------- | ----------- | ------------ | -------------- | ----------- | ----------- | ------------ | ------------ | ----------- | ----------- | ----------- | ----------- | ----------- | --------------- | --- |
| ID           | ID            | ID              | ID           | ID           | ID                     | ID          | ID             | ID             | ID                | ID          | ID          | ID           | ID          | ID          | ID           | ID          | ID          | ID          | ID                 | ID           | ID            | ID           | ID                  | ID                | ID              | ID          | ID           | ID          | ID          | ID          | ID           | ID             | ID          | ID          | ID           | ID           | ID          | ID          | ID          | ID          | ID          | ID              |     |
|              |               |                 |              |              |                        |             |                |                | OriginalShortName |             |             |              |             |             |              |             |             |             |                    |              |               |              |                     |                   |                 |             |              |             |             |             |              |                |             |             |              |              |             |             |             |             |             |                 |     |
| OriginalName |               | OriginalName    | OriginalName | OriginalName |                        |             |                | OriginalName   | OriginalName      |             |             | OriginalName |             |             | OriginalName |             |             |             |                    | OriginalName | OriginalName  | OriginalName |                     |                   | OriginalName    |             | OriginalName |             |             |             | OriginalName |                |             |             | OriginalName | OriginalName |             |             |             |             |             | OriginalName    |     |
|              |               |                 |              |              |                        |             |                |                | EnglishShortName  |             |             |              |             |             |              |             |             |             |                    |              |               |              |                     |                   |                 |             |              |             |             |             |              |                |             |             |              |              |             |             |             |             |             |                 |     |
|              | EnglishName   |                 |              |              | EnglishName            | EnglishName | EnglishName    |                | EnglishName       | EnglishName | EnglishName |              | EnglishName | EnglishName |              | EnglishName | EnglishName | EnglishName | EnglishName        | EnglishName  |               |              | EnglishName         | EnglishName       |                 | EnglishName |              | EnglishName | EnglishName | EnglishName |              | EnglishName    | EnglishName | EnglishName |              |              | EnglishName | EnglishName | EnglishName | EnglishName | EnglishName |                 |     |
|              |               |                 |              |              |                        |             |                |                | GermanShortName   |             |             |              |             |             |              |             |             |             |                    |              |               |              |                     |                   |                 |             |              |             |             |             |              |                |             |             |              |              |             |             |             |             |             |                 |     |
|              | GermanName    |                 |              |              | GermanName             | GermanName  | GermanName     |                | GermanName        | GermanName  | GermanName  |              | GermanName  | GermanName  |              | GermanName  | GermanName  | GermanName  | GermanName         | GermanName   |               |              | GermanName          | GermanName        |                 | GermanName  |              | GermanName  | GermanName  | GermanName  |              | GermanName     | GermanName  | GermanName  |              |              | GermanName  | GermanName  | GermanName  | GermanName  | GermanName  |                 |     |
|              |               |                 |              | Lenses       |                        |             |                |                |                   |             |             |              |             |             |              |             |             |             |                    |              |               |              |                     |                   |                 |             |              |             |             |             |              |                |             |             |              |              |             |             |             |             |             |                 |     |
|              |               |                 |              |              |                        |             |                |                |                   |             |             |              |             |             |              |             |             |             |                    |              |               |              |                     |                   |                 |             |              |             |             |             |              |                |             |             |              |              |             |             |             |             |             |                 |     |
|              |               |                 |              |              |                        |             |                |                |                   |             |             |              |             |             |              |             |             |             |                    |              |               |              |                     |                   |                 |             |              |             |             |             |              |                |             |             |              |              |             |             |             |             |             |                 |     |
| Details      | Details       | Details         | Details      | Details      | Details                | Details     | Details        | Details        | Details           | Details     | Details     | Details      | Details     | Details     | Details      | Details     | Details     | Details     | Details            | Details      | Details       | Details      | Details             | Details           | Details         | Details     | Details      | Details     | Details     | Details     | Details      | Details        | Details     | Details     | Details      | Details      | Details     | Details     | Details     | Details     | Details     | Details         |     |
| Notes        | Notes         | Notes           | Notes        | Notes        | Notes                  | Notes       | Notes          | Notes          | Notes             | Notes       | Notes       | Notes        | Notes       | Notes       | Notes        | Notes       | Notes       | Notes       | Notes              | Notes        | Notes         | Notes        | Notes               | Notes             | Notes           | Notes       | Notes        | Notes       | Notes       | Notes       | Notes        | Notes          | Notes       | Notes       | Notes        | Notes        | Notes       | Notes       | Notes       | Notes       | Notes       | Notes           |     |
| StatusID     | StatusID      | StatusID        | StatusID     | StatusID     | StatusID               | StatusID    | StatusID       | StatusID       | StatusID          | StatusID    | StatusID    | StatusID     | StatusID    | StatusID    | StatusID     | StatusID    | StatusID    | StatusID    | StatusID           | StatusID     | StatusID      | StatusID     | StatusID            | StatusID          | StatusID        | StatusID    | StatusID     | StatusID    | StatusID    | StatusID    | StatusID     | StatusID       | StatusID    | StatusID    | StatusID     | StatusID     | StatusID    | StatusID    | StatusID    | StatusID    | StatusID    | StatusID        |     |
| LastUpdated  | LastUpdated   | LastUpdated     | LastUpdated  | LastUpdated  | LastUpdated            | LastUpdated | LastUpdated    | LastUpdated    | LastUpdated       | LastUpdated | LastUpdated | LastUpdated  | LastUpdated | LastUpdated | LastUpdated  | LastUpdated | LastUpdated | LastUpdated | LastUpdated        | LastUpdated  | LastUpdated   | LastUpdated  | LastUpdated         | LastUpdated       | LastUpdated     | LastUpdated | LastUpdated  | LastUpdated | LastUpdated | LastUpdated | LastUpdated  | LastUpdated    | LastUpdated | LastUpdated | LastUpdated  | LastUpdated  | LastUpdated | LastUpdated | LastUpdated | LastUpdated | LastUpdated | LastUpdated     |     |

