# WikiExporter – refined application and test baseline

This package contains the complete Clean-Architecture baseline built from the supplied EntertainmentInfothek SQLite schema.

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

The environment used to generate this archive did not contain the .NET SDK, so `dotnet build`/`dotnet test` could not be executed here.
