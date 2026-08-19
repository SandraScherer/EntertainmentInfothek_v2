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
| ReleaseDate   | ReleaseDate              | ReleaseDate              |                          |                    |
|               |                          |                          | ReleaseDateFirstEpisode  |                    |
|               |                          |                          | ReleaseDateLastEpisode   |                    |
|               |                          |                          | NoOfSeasons              |                    |
|               | SeasonNo                 |                          |                          |                    |
|               |                          |                          | NoOfEpisodes             |                    |
|               | EpisodeNo                |                          |                          |                    |
|               |                          | Budget                   | Budget                   | Budget             |
|               |                          | WorldwideGross           | WorldwideGross           | WorldwideGross     |
|               |                          | WorldwideGrossDate       | WorldwideGrossDate       | WorldwideGrossDate |
| CastStatusID  | CastStatusID             | CastStatusID             | CastStatusID             | CastStatusID       |
|               | CrewStatusID             | CrewStatusID             | CrewSTatusID             |                    |
| ConnectionID  |                          | ConnectionID             | ConnectionID             | ConnectionID       |
| Details       | Details                  | Details                  | Details                  | Details            |
| Notes         | Notes                    | Notes                    | Notes                    | Notes              |
| StatusID      | StatusID                 | StatusID                 | StatusID                 | StatusID           |
| LastUpdated   | LastUpdated              | LastUpdated              | LastUpdated              | LastUpdated        |
| ---           | ---                      | ---                      | ---                      | ---                |
|               | AnimationDepartment      | AnimationDepartment      | AnimationDepartment      |                    |
|               | ArtDepartment            | ArtDepartment            | ArtDepartment            |                    |
|               | ArtDirection             | ArtDirection             | ArtDirection             |                    |
|               |                          | AspectRatio              | AspectRatio              |                    |
|               | AssistantDirector        | AssistantDirector        | AssistantDirector        |                    |
| Award         | Award                    | Award                    | Award                    | Award              |
|               | Award_Person             | Award_Person             | Award_Person             |                    |
|               |                          | Camera                   | Camera                   |                    |
| Cast          | Cast                     | Cast                     | Cast                     | Cast               |
|               | Casting                  | Casting                  | Casting                  |                    |
|               | CastingDepartment        | CastingDepartment        | CastingDepartment        |                    |
|               | Certification            | Certification            | Certification            | Certification      |
|               |                          | CinematographicProcess   | CinematographicProcess   |                    |
|               | Cinematography           | Cinematography           | Cinematography           |                    |
|               |                          | Color                    | Color                    |                    |
|               |                          |                          |                          | Completion         |
|               | ContinuityDepartment     | ContinuityDepartment     | ContinuityDepartment     |                    |
|               | CostumeDepartment        | CostumeDepartment        | CostumeDepartment        |                    |
|               | CostumeDesign            | CostumeDesign            | CostumeDesing            |                    |
|               |                          | Country                  | Country                  |                    |
| Cover         |                          | Cover                    | Cover                    | Cover              |
|               |                          |                          | Creator                  | Creator            |
| Description   | Description              | Description              | Description              | Description        |
|               |                          |                          |                          | Developer          |
|               |                          |                          |                          | Difficulty         |
|               | Director                 | Director                 | Director                 |                    |
|               | Distributor              | Distributor              | Distributor              | Distributor        |
|               | EditiorialDepartment     | EditorialDepartment      | EditorialDepartment      |                    |
|               | ElectricalDepartment     | ElectricalDepartment     | ElectricalDepartment     |                    |
|               | FimEditing               | FilmEditing              | FilmEditing              |                    |
|               | FilmLength               | FilmLength               | FilmLength               |                    |
|               | FilmingDate              | FilmingDate              | FilmingDate              |                    |
|               | FilmingLocation          | FilmingLocation          | FilmingLocation          |                    |
| Genre         |                          | Genre                    | Genre                    | Genre              |
|               | Image                    | Image                    | Image                    | Image              |
|               |                          | Laboratory               | Laboratory               |                    |
| Language      |                          | Language                 | Language                 | Language           |
|               | LocationManagement       | LocationManagement       | LocationManagement       |                    |
| Logo          |                          | Logo                     | Logo                     | Logo               |
|               | MakeupDepartment         | MakeupDepartment         | MakeupDepartment         |                    |
|               | Music                    | Music                    | Music                    |                    |
|               | MusicDepartment          | MusicDepartment          | MusicDepartment          |                    |
|               |                          | NegativeFormat           | NegativeFormat           |                    |
|               | OtherCompany             | OtherCompany             | OtherCompany             |                    |
|               | OtherCrew                | OtherCrew                | OtherCrew                |                    |
|               |                          |                          |                          | Perspective        |
|               |                          | Poster                   | Poster                   |                    |
|               |                          | PrintedFilmFormat        | PrintedFilmFormat        |                    |
|               | Producer                 | Producer                 | Producer                 |                    |
|               | ProductionCompany        | ProductionCompany        | ProductionCompany        |                    |
|               | ProductionDate           | ProductionDate           | ProductionDate           |                    |
|               | ProductionDesign         | ProductionDesign         | ProductionDesign         |                    |
|               | ProductionManagement     | ProductionManagement     | ProductionManagment      |                    |
|               |                          |                          |                          | Publisher          |
| Publication   |                          |                          |                          |                    |
|               |                          |                          |                          | ReleaseDate        |
| Review        | Review                   | Review                   | Review                   | Review             |
|               | Runtime                  | Runtime                  | Runtime                  |                    |
| Score         |                          | Score                    | Score                    | Score              |
|               | SetDecoration            | SetDecoration            | SetDecortation           |                    |
|               |                          |                          |                          | Setting            |
|               | SoundDepartment          | SoundDepartment          | SoundDepartment          |                    |
|               |                          | SoundMix                 | SoundMix                 |                    |
|               | SpecialEffects           | SpecialEffects           | SpecialEffects           |                    |
|               | SpecialEffectsCompany    | SpecialEffectsCompany    | SpecialEffectsCompany    |                    |
|               | Stunts                   | Stunts                   | Stunts                   |                    |
|               | Thanks                   | Thanks                   | Thanks                   |                    |
|               | TransportationDepartment | TransportationDepartment | TransportationDepartment |                    |
| User          |                          | User                     | User                     | User               |
|               |                          |                          |                          | Version            |
|               | VisualEffects            | VisualEffects            | VisualEffects            |                    |
| Weblink       |                          | Weblink                  | Weblink                  | Weblink            |
| Writer        | Writer                   | Writer                   | Writer                   |                    |


## "Bigger" Reference Tables (with and without Dependents)

| Award       | Certification | Company     | Connection   | Image       | Laboratory  | Location    | Person              | Text |     |     |
| ----------- | ------------- | ----------- | ------------ | ----------- | ----------- | ----------- | ------------------- | ---- | --- | --- |
| ID          | ID            | ID          | ID           | ID          | ID          | ID          | ID                  | ID   |     |     |
| Name        | Name          | Name        | Name         |             |             |             |                     |      |     |     |
|             |               |             |              |             |             | EnglishName |                     |      |     |     |
|             |               |             |              |             |             | GermanName  |                     |      |     |     |
|             |               |             |              |             |             |             | FirstName           |      |     |     |
|             |               |             |              |             |             |             | LastName            |      |     |     |
|             |               | NameAddOn   |              |             |             |             | NameAddOn           |      |     |     |
|             |               |             |              | FileName    |             |             |                     |      |     |     |
|             |               |             |              |             |             |             | BirthName           |      |     |     |
|             |               |             |              | Description |             |             |                     |      |     |     |
|             |               |             |              |             |             |             | DateOfBirth         |      |     |     |
|             | ImageID       |             |              |             |             |             |                     |      |     |     |
|             |               |             |              |             | LocationID  | LocationID  | LocationOfBirthID   |      |     |     |
|             |               |             |              |             |             |             | DateOfDeath         |      |     |     |
|             |               |             |              |             |             |             | LocationOfDeathID   |      |     |     |
|             |               |             |              |             |             |             | EnglishCauseOfDeath |      |     |     |
|             |               |             |              |             |             |             | GermanCauseOfDeath  |      |     |     |
|             |               |             |              |             |             |             | GenderID            |      |     |     |
|             |               |             |              |             |             |             | Height              |      |     |     |
|             |               | TypeID      |              | TypeID      |             |             | TypeID              |      |     |     |
|             | CountryID     |             |              | CountryID   |             | CountryID   |                     |      |     |     |
|             |               |             | ConnectionID |             |             |             |                     |      |     |     |
| PresenterID |               |             |              |             |             |             |                     |      |     |     |
| EnglishRole |               |             |              |             |             |             |                     |      |     |     |
| GermanRole  |               |             |              |             |             |             |                     |      |     |     |
| Details     | Details       | Details     | Details      | Details     | Details     | Details     | Details             |      |     |     |
| Notes       | Notes         | Notes       | Notes        | Notes       | Notes       | Notes       | Notes               |      |     |     |
| StatusID    | StatusID      | StatusID    | StatusID     | StatusID    | StatusID    | StatusID    | StatusID            |      |     |     |
| LastUpdated | LastUpdated   | LastUpdated | LastUpdated  | LastUpdated | LastUpdated | LastUpdated | LastUpdated         |      |     |     |
| ---         | ---           | ---         | ---          | ---         | ---         | ---         | ---                 | ---  | --- | --- |
|             |               |             |              | Source      |             |             | (todo)              |      |     |     |


## Basic Reference Tables (no Dependents)

| AspectRatio | BusinessModel | CDROMDriveSpeed | CPU         | Camera      | CinematographicProcess | Color       | ControllerType | CopyProtection | Country           | Difficulty  | DirectX     | Driver      | Edition     | FilmFormat  | Genre       | Hardware    | InputDevice | InputDeviceFeature | Language     | MacOSSprocket | MediaType   | MultiplayerGameMode | MultiplayerOption | OperatingSystem |     |
| ----------- | ------------- | --------------- | ----------- | ----------- | ---------------------- | ----------- | -------------- | -------------- | ----------------- | ----------- | ----------- | ----------- | ----------- | ----------- | ----------- | ----------- | ----------- | ------------------ | ------------ | ------------- | ----------- | ------------------- | ----------------- | --------------- |     |
| ID          | ID            | ID              | ID          | ID          | ID                     | ID          | ID             | ID             | ID                | ID          | ID          | ID          | ID          | ID          | ID          | ID          | ID          | ID                 | ID           | ID            | ID          | ID                  | ID                | ID              |     |
| Name        |               | Name            | Name        | Name        |                        |             |                | Name           |                   |             | Name        |             |             | Name        |             |             |             |                    |              | Name          | Name        |                     |                   | Name            |     |
|             |               |                 |             |             |                        |             |                |                | OriginalShortName |             |             |             |             |             |             |             |             |                    |              |               |             |                     |                   |                 |     |
|             |               |                 |             |             |                        |             |                |                | OriginalName      |             |             |             |             |             |             |             |             |                    | OriginalName |               |             |                     |                   |                 |     |
|             |               |                 |             |             |                        |             |                |                | EnglishShortName  |             |             |             |             |             |             |             |             |                    |              |               |             |                     |                   |                 |     |
|             | EnglishName   |                 |             |             | EnglishName            | EnglishName | EnglishName    |                | EnglishName       | EnglishName |             | EnglishName | EnglishName |             | EnglishName | EnglishName | EnglishName | EnglishName        | EnglishName  |               |             | EnglishName         | EnglishName       |                 |     |
|             |               |                 |             |             |                        |             |                |                | GermanShortName   |             |             |             |             |             |             |             |             |                    |              |               |             |                     |                   |                 |     |
|             | GermanName    |                 |             |             | GermanName             | GermanName  | GermanName     |                | GermanName        | GermanName  |             | GermanName  | GermanName  |             | GermanName  | GermanName  | GermanName  | GermanName         | GermanName   |               |             | GermanName          | GermanName        |                 |     |
|             |               |                 |             | Lenses      |                        |             |                |                |                   |             |             |             |             |             |             |             |             |                    |              |               |             |                     |                   |                 |     |
|             |               |                 |             |             |                        |             |                |                |                   |             |             |             |             |             |             |             |             |                    |              |               |             |                     |                   |                 |     |
|             |               |                 |             |             |                        |             |                |                |                   |             |             |             |             |             |             |             |             |                    |              |               |             |                     |                   |                 |     |
| Details     | Details       | Details         | Details     | Details     | Details                | Details     | Details        | Details        | Details           | Details     | Details     | Details     | Details     | Details     | Details     | Details     | Details     | Details            | Details      | Details       | Details     | Details             | Details           | Details         |     |
| Notes       | Notes         | Notes           | Notes       | Notes       | Notes                  | Notes       | Notes          | Notes          | Notes             | Notes       | Notes       | Notes       | Notes       | Notes       | Notes       | Notes       | Notes       | Notes              | Notes        | Notes         | Notes       | Notes               | Notes             | Notes           |     |
| StatusID    | StatusID      | StatusID        | StatusID    | StatusID    | StatusID               | StatusID    | StatusID       | StatusID       | StatusID          | StatusID    | StatusID    | StatusID    | StatusID    | StatusID    | StatusID    | StatusID    | StatusID    | StatusID           | StatusID     | StatusID      | StatusID    | StatusID            | StatusID          | StatusID        |     |
| LastUpdated | LastUpdated   | LastUpdated     | LastUpdated | LastUpdated | LastUpdated            | LastUpdated | LastUpdated    | LastUpdated    | LastUpdated       | LastUpdated | LastUpdated | LastUpdated | LastUpdated | LastUpdated | LastUpdated | LastUpdated | LastUpdated | LastUpdated        | LastUpdated  | LastUpdated   | LastUpdated | LastUpdated         | LastUpdated       | LastUpdated     |     |

