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
