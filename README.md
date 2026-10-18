# WikiExporter – refined application and test baseline

This package contains the complete Clean-Architecture baseline built from the supplied EntertainmentInfothek SQLite schema.

For layer boundaries, export flow, localization fallback, persistence strategy, and design constraints, see [ARCHITECTURE.md](ARCHITECTURE.md).

## Layers

- `WikiExporter.Domain` – export read models and neutral domain contracts.
- `WikiExporter.Application` – export request/use case, localization fallback, semantic document builders and neutral `MarkdownDocument`.
- `WikiExporter.Persistence` – EF Core model for all 196 tables, explicit configurations and bounded set-based export graph loading.
- `WikiExporter.Export` – DokuWiki/Obsidian rendering, links, paths, file names and filesystem writing.
- `WikiExporter.Console` – CLI, interactive configuration and composition root.

## Semantic document building

The builders no longer dump all association rows as generic lists. They recognize the export vocabulary and create dedicated sections for:

- Cast and Crew
- Awards and award recipients
- Company credits
- Genres, countries, languages and certifications
- Production/filming/release/runtime information
- Images, texts and web links
- Book publications and their nested publication metadata
- Video-game technical specifications and feature tables
- Series episode references
- Person family/employer/position/profession/species relations
- Connection parent/child hierarchy and grouped works

References remain links; they are never recursively exported as embedded documents.

## Tests

A test project exists for each layer:

- `WikiExporter.Domain.Tests`
- `WikiExporter.Application.Tests`
- `WikiExporter.Persistence.Tests`
- `WikiExporter.Export.Tests`
- `WikiExporter.Console.Tests`

The persistence tests validate the 196-table / 542-FK EF model and exercise a reader against SQLite in-memory data. Application tests cover localization, all seven document builders and the export use case. Export tests cover both renderers, paths, links and filesystem traversal protection. Console tests cover argument parsing and the composition root.

The latest project baseline was reported by the project owner to build and pass its tests before this documentation review. Documentation-only edits in this archive have not been independently compiled in this environment.


## Persistence entity naming

All EF Core entity classes in `WikiExporter.Persistence.Entities` use the `*Entity` suffix, e.g. `BookEntity`, `MovieEntity`, `DepartmentEntity`. Database table names remain unchanged and are configured explicitly with `ToTable(...)`.

### Latest test additions

MoreTests35 adds regression coverage for deterministic ordering of episodes within a series, absent/blank series references on episode documents, and fallback to a series ID when related display data is missing. See `TEST_COVERAGE_REVIEW.md` for details.


### MoreTests36 – title localization consistency

Added `DocumentTitleLocalizationConsistencyTests.cs` with 42 parameterized cases covering all seven document builders, all three export languages, consistency between the first heading and metadata title, and the fallback to `Untitled` when every localized title value is blank. No production code was changed.

Run the complete suite with `dotnet test`. The test suite has not been run in the authoring environment because the .NET SDK is unavailable.

### MoreTests38 — localized roles and person relationships

This package adds application tests for language-dependent cast roles, family relationship labels, person references, and cause-of-death sections. Run `dotnet test` from the solution directory to validate the full suite.

### MoreTests40

Added regression tests for deterministic cast ordering (explicit order and stable ID tie-breaker), preservation of character/dubber links when an actor is missing, and omission of empty cast sections for rows with no usable relationship data. Run `dotnet test` to validate locally.

### Latest regression tests

The `AwardAndRelationIsolationTests` application test class adds coverage for award-contributor scoping, deterministic award ordering, company-credit ordering, and person family-reference ordering. Run `dotnet test` to validate the complete solution.

### MoreTests42 — empty person relationship rows

Adds ten parameterized regression cases across family, employer, position, profession, and species relationships. Empty/whitespace target IDs must not create empty relationship sections; when valid and blank rows coexist, only valid relationship references are emitted. The person relationship builder was adjusted to filter unusable target IDs before creating a section. Run `dotnet test` locally; the .NET SDK is not available in the authoring environment.

### MoreTests43 — repeated relationships and stable output

The latest test batch adds regression coverage for multiple family relationships to the same person, output ordering independent of input row order, and repeated work/episode references whose display titles match. Run `dotnet test` from the solution directory to validate locally.

### MoreTests44 — repeated export writes and persistence failures

Adds tests for overwriting stale Markdown output, repeated writes to the same path with UTF-8 content, and propagation of file-writer failures through `MarkdownExportService`. Run `dotnet test` from the solution directory to validate locally; the .NET SDK is unavailable in the authoring environment.

### Latest test additions

MoreTests45 adds filesystem path-boundary regression tests and checks the filename generator's fallback when a document type sanitizes to only dots. Run `dotnet test` locally; this editing environment does not have the .NET SDK installed.
