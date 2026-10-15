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

## Additional renderer and export-service coverage (2026-10, follow-up)

- **Obsidian renderer block types**: unordered/ordered lists, images including blank image paths, fenced code blocks, horizontal rules, and heading-level clamping.
- **DokuWiki renderer block types**: unordered/ordered lists, images, code blocks, horizontal rules, and heading-level clamping.
- **Text normalization**: paragraph CRLF/CR newlines are normalized, and table-cell pipes and embedded line breaks are escaped consistently for both renderers.
- **Markdown export service**: rendering is followed by writing; the rendered result is returned; null documents and blank output directories are rejected before writing; cancellation and writer exceptions propagate.

The editing environment does not have the .NET SDK, so the new tests have not been executed here. Run `dotnet test` locally.


## Additional test batch (2026-10, file-writer boundary cases)

- `FileWriter_CreatesNestedDirectoriesAndAllowsEmptyContent`: verifies nested output folders are created and an empty Markdown document is still written as a file.
- `FileWriter_RejectsAbsolutePathOutsideOutputDirectory`: verifies absolute paths cannot escape the configured export root and no outside file is written.
- `FileWriter_RejectsBlankRelativePathBeforeCreatingOutput`: verifies invalid relative paths fail before creating the output directory.

These tests were added but not executed in this editing environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate them.

## Additional test batch (2026-10, links and localization)

- `ExportLinkResolverTests` verifies that Obsidian links use relative paths across folders, avoid unnecessary parent traversal within the same folder, omit `.md` from wiki-link targets, and use stable ID-derived filenames. DokuWiki links are checked for colon namespaces and stable target names; unknown entity types are checked against the `Other` folder fallback.
- `LocalizedValueSelectorFallbackMatrixTests` covers all three requested-language fallback orders (German → Original → English, English → Original → German, Original → English → German), including whitespace-only values.

These tests were added but could not be executed in this environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate the package.

## Additional test batch (2026-10, stability and cancellation)

- **Batch export cancellation**: verifies cancellation from the reader propagates out of export-all and no document builder is invoked.
- **File-name stability and safety**: verifies file names are based on stable entity IDs rather than mutable titles, sanitize unsafe document-type characters, and differ for distinct IDs even when titles are duplicated.
- **Command-line enum validation**: verifies invalid entity types, languages, formats, and empty `--name=` values are rejected.

These tests were added but not executed in this environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate the package.

## Additional test batch (2026-10, YAML scalar fidelity)

- `ObsidianRenderer_QuotesYamlStringsThatCouldChangeTypeAndEscapesBackslashes`: verifies string values such as `true`, `null`, and numeric-looking values stay strings in YAML frontmatter, while embedded quotes and Windows-style backslashes are escaped. Ordinary simple values remain readable and unquoted.
- `ObsidianRenderer_SortsMetadataKeysDeterministically`: verifies frontmatter metadata is emitted in ordinal key order regardless of dictionary insertion order.
- The scalar tests exposed a serialization gap: quote-only, backslash, and type-like scalar values were not consistently quoted. The Obsidian YAML scalar writer was tightened accordingly.

These tests have not been executed in this environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate the package.


## Additional test batch (2026-10-13, relationship ordering and YAML scalars)

- `ConnectionBuilder_EmitsParentChildrenAndWorksAsSortedReferences`: checks that parent and child connections remain links, children are sorted by display label with ID fallback, and referenced works are grouped by type and sorted by localized title.
- `SeriesBuilder_OrdersEpisodesBySeasonThenEpisodeAndKeepsThemAsLinks`: checks season/episode ordering, selected-language labels, and that episodes are represented as lightweight links.
- `ObsidianRenderer_QuotesYamlReservedAndAmbiguousScalars`: checks quoting for YAML-reserved values (`yes`, `~`), leading dashes, colon-containing strings, and strings with leading/trailing whitespace.

The .NET SDK is unavailable in this editing environment, so this batch has not been executed here. Run `dotnet test` locally before treating the package as verified.


## Additional test batch (2026-10-13, end-to-end file export)

- `ExportService_WritesDocumentAndResolvableCrossDocumentLink`: runs the real renderer resolver, both renderers, stable filename/path generation, link resolution, and filesystem writer together for Obsidian and DokuWiki; verifies files and emitted link targets.
- `ExportService_ReExportingSameEntityIdOverwritesItsFileWithoutCreatingDuplicate`: verifies repeated exports of one stable entity ID update the same Markdown file instead of creating a duplicate.

These tests were added but not executed in this environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate the package.

## Additional test batch (2026-10, cancellation and unusual identifiers)

- **Mid-export cancellation**: verifies that cancellation occurring while processing an export-all stream is observed before the next entity is built.
- **Path-like entity IDs in links**: verifies that IDs containing traversal-like segments, backslashes, and Unicode are represented by stable hashed link targets rather than injected into the output path, for both Obsidian and DokuWiki.
- **Unicode and empty IDs**: verifies stable link naming for Unicode IDs and empty IDs without leaking the raw ID into the generated link.
- **Empty document rendering**: verifies both renderers still return a stable Markdown path and a final newline for a document with no blocks or metadata.

The .NET SDK is unavailable in this editing environment, so these tests have not been executed here. Run `dotnet test` locally to validate the package.

## Additional test batch (2026-10-13, persistence reader consistency)

- `AllSevenReaders_ReadAllUseStableIdOrderAcrossSmallBatches`: seeds all seven export entity types in deliberately unsorted order, reads with batch size one, and verifies each reader returns every ID in deterministic ascending order across batch boundaries.
- `AllSevenReaders_RespectCancellationBeforeStartingReadAll`: supplies an already-cancelled token to each reader's async stream and verifies enumeration observes cancellation before returning an item.

These tests were added but not executed in this editing environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate the package.

## Additional test batch (2026-10-13, batch graph isolation)

- `MovieReader_ScopesRootAndRelatedRowsToEachMovieWhenBatchContainsMultipleMovies`: places two movies and their genre-association rows in one reader batch, then verifies each exported model contains only its own root row and its own relationship row. Also verifies relationship `Details` is retained and `Notes` is excluded.
- `VideoGameReader_ScopesTechnicalSpecificationsToTheirOwningGameAcrossBatch`: places two games and their technical specifications in the same graph batch and verifies that each game receives only its own specification.
- These tests exposed a graph-mapping defect: `ExportGraphMapper.Rows` previously returned every relevant table row from a batch for each root entity. The mapper now follows foreign-key relationships back to the requested root and excludes rows belonging to sibling roots in the same batch.

Validation note: the .NET SDK is unavailable in this editing environment, so this package has not been executed here. Run `dotnet test` locally before treating it as verified.

## Follow-up fix package (2026-10-13, root-specific relationship filtering)

- Fixed `ExportGraphMapper.Rows` to traverse only related rows connected to the current root through actual foreign-key relationships. This prevents sibling root rows and sibling association rows from leaking into each entity's `RelatedData` when multiple roots are loaded in one batch.
- Kept Text/Image author/source association rows reachable through root-specific rows while excluding the lookup principal rows themselves from emitted related data.
- The two reported persistence tests cover this regression: movie genre associations and video-game technical specifications must remain scoped to their owning root.

The .NET SDK is unavailable in this environment, so the corrected package has not been executed here. Run `dotnet test` locally before treating it as verified.

## Additional test batch (2026-10-13, book and series batch isolation)

- `BookReader_ScopesPublicationsToTheirOwningBookAcrossBatch`: seeds two books with distinct publication rows in the same batch and verifies each book receives only its own edition metadata.
- `SeriesReader_ScopesEpisodeReferencesToTheirOwningSeriesAcrossBatch`: seeds two series and one episode per series in the same batch and verifies episode references do not leak across series.

These tests were added but not executed in this environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate them.


## Regression correction after MoreTests18 feedback

- Fixed `SeriesExportReader` so episode references are filtered by their owning `SeriesId` when the batch graph contains more than one series.
- The cross-batch regression test `SeriesReader_ScopesEpisodeReferencesToTheirOwningSeriesAcrossBatch` verifies that each series only receives its own episode references.
- Local `dotnet test` execution is still required to validate this correction in the target environment.


## Additional test batch (2026-10-15, episode relationship isolation)

- `EpisodeReader_ScopesCastRowsToTheirOwningEpisodeAcrossBatch`: seeds two episodes in one series, each with its own `Episode_Cast` row, and verifies the reader includes only the owning episode's cast row, retains role and `Details` values, and excludes `Notes`.

The .NET SDK is not available in the editing environment, so this test has not been executed here. Run `dotnet test` locally to validate it.
