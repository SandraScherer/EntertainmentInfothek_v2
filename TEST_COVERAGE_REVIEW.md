# Test Coverage Review

## Scope reviewed

The test suite was reviewed by responsibility across Domain, Application, Export, Persistence, and Console. The review focused on externally observable behavior and edge cases rather than testing private implementation details.

## Additional tests added

- **Application / export orchestration**
  - Missing entity returns one failure and does not invoke the document builder.
  - A document-builder exception is converted into a per-entity failure result.
- **Localization**
  - Whitespace-only translations are skipped and a missing translation returns `null`.
- **Export infrastructure**
  - File names are deterministic for the same entity ID and differ for different IDs.
  - Every known document type maps to its expected output folder, with an unknown-type fallback.
  - DokuWiki table cells escape pipe characters.
- **Console parser**
  - `--name=value` syntax and the help flag are accepted.
  - Zero, negative, and non-numeric batch sizes are rejected.
  - Unknown arguments and missing argument values are rejected.

## Existing coverage retained

Existing tests continue to cover document-builder registration, localized-value selection, both Markdown renderers, UTF-8 file output without a BOM, path-traversal rejection, command-line parsing, dependency-injection registration, and Series-to-Episode references.

## Additional tests in the follow-up pass

- **Batch export orchestration**
  - A builder failure for one item does not prevent later items from being exported.
  - Result counts, successful document IDs, and per-item error details are consistent.
  - Empty export-all input returns zero counts and no documents or errors.
  - The configured batch size is passed to the reader.
- **Batch-size normalization**
  - Default size, negative and zero sizes, normal values, the upper bound, and values above the upper bound are tested.

## Remaining gaps / recommended follow-up

1. Add schema-level persistence tests asserting all mapped table names and foreign-key counts against the checked-in SQLite schema. Keep the schema fixture/version explicit so intentional schema changes update the expectations deliberately.
2. Add reader integration tests for all seven export roots, including missing IDs, null optional lookups, multi-level associations (awards, publications, technical specifications), and language-specific text.
3. Add end-to-end tests against a small, versioned SQLite fixture that export to both DokuWiki and Obsidian and validate generated file paths, cross-document links, and contents.
4. Add batch-export tests proving that one bad entity does not stop later entities, and that cancellation is propagated.
5. Add tests for output write failures, invalid output roots, duplicate titles, and IDs containing unusual characters.
6. Add line/branch coverage reporting (for example, Coverlet) before setting a numeric coverage target. No numeric coverage percentage is claimed by this review.

## Validation note

The editing environment used for this review does not have the .NET SDK installed. The added tests were checked against the source-level contracts, but `dotnet test` could not be executed here. Run `dotnet test` locally before treating this package as verified.

## Additional tests in the latest pass

- **Persistence / export-reader integration**
  - Each of the seven export readers returns `null` for an unknown entity ID against an in-memory SQLite database with the EF schema created.
  - Movie export-all uses stable ID ordering and continues correctly across one-item pages.
- **Application / cancellation**
  - Single-item export forwards the cancellation token to the reader, propagates cancellation, and does not invoke the document builder.

## Validation note for this pass

The new tests were added to the source package but were not executed in this environment because the .NET SDK is unavailable here. Run `dotnet test` locally to validate them.


## Additional tests in this pass

- **Connection reader / relationship scoping**
  - Child connections are returned as references.
  - Works are associated only with their own connection when multiple connections are loaded in one batch.
  - Work references include different exportable work types and remain references rather than nested documents.
- **Book reader / publication data**
  - Publication is included as related row data, with representative edition metadata retained.
  - `Notes`, `StatusID`, and `LastUpdated` are excluded while `Details` remains available.
- **Video-game reader / technical specifications**
  - Technical specification data is included in the video game's related rows.
  - Representative player-count and localized annotation fields are retained while notes are excluded.
- **Person reader**
  - Person display name is composed from first name, last name, and optional name add-on.
  - Details are retained while notes and tracking/status columns are excluded.

The added integration coverage also exposed two reader mapping issues: connection work references were being shared across every connection in a multi-item batch, and person names were mapped using title/name fields that do not exist on the Person table. Both implementations were corrected alongside the tests.

## Validation note for this pass

The .NET SDK is not available in the editing environment, so these additions and fixes have not been executed here. Run `dotnet test` locally before merging.


## Additional test batch (2026-10)

- `SeriesReader_OrdersEpisodeReferencesAndKeepsThemAsLightweightReferences`: verifies episode reference ordering by season/episode and title mapping without embedding episode detail fields in the reference model.
- `EpisodeReader_ReadAllUsesStableBatchesAndExcludesNotesAndTrackingColumns`: verifies stable keyset pagination with batch size one, parent-series reference mapping, Details inclusion, and exclusion of Notes/StatusID/LastUpdated from exported row fields.
- `ObsidianRenderer_QuotesYamlValuesWithSpecialCharactersAndEscapesQuotes`: covers YAML quoting for whitespace/special characters, embedded quotes, empty values, nulls, and ordinary values.
- `RendererResolver_RejectsUnknownFormat`: verifies invalid enum values are rejected rather than silently choosing a renderer.

These tests were added but could not be executed in this environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate them.

## Additional edge-case coverage

The latest test expansion adds `DocumentBuilderEdgeCaseTests` with coverage for:

- all seven document builders falling back to `Untitled` when all title variants are blank, and omitting empty Details sections;
- localized movie title fallback to the original title when the requested language is unavailable;
- connection references whose target is not present in the read model, preserving the stable target ID as the link label;
- publication text being included only for the publication that owns the relationship, excluding orphaned publication-text rows;
- technical-specification child rows being scoped to their parent specification rather than leaking across specifications.
