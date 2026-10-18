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
  - Both renderers produce deterministic paths and content for identical documents.
  - DokuWiki output does not leak Obsidian YAML frontmatter; Obsidian metadata ordering does not alter content-block order.
  - DokuWiki table headers and cells escape pipes and normalize line breaks.
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


## Additional test batch (2026-10-15, direct-reader paths)

- `SeriesReader_GetAsyncReturnsOnlyEpisodesOwnedByRequestedSeries`: creates two series with one episode each, requests a single series through `GetAsync`, and verifies that only that series' episode reference is returned. This complements the existing batch enumeration regression test with the single-entity access path.
- `PersonReader_IncludesNameAddOnInDisplayNameWithoutLeakingNotes`: verifies that the person's first name, last name, and name add-on are combined in the display name, that public details are preserved, and that private notes are omitted from related export fields.

These tests have been added but not executed in this editing environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate them.


## Additional test batch (2026-10-15, command-line enum validation)

- `Parser_RejectsUndefinedNumericEnumValues`: verifies that numeric enum values outside the declared `ExportEntityType`, `ExportLanguage`, and `ExportFormat` members are rejected. This closes a parser edge case because `Enum.TryParse` alone accepts undefined numeric values.
- `Parser_AcceptsDefinedEnumValuesCaseInsensitively`: verifies valid named enum members remain case-insensitive for entity type, language, and format.
- Updated `CommandLineParser.ParseEnum` to require both successful parsing and `Enum.IsDefined`.

The .NET SDK is unavailable in the editing environment, so these tests have not been executed here. Run `dotnet test` locally to validate the package.

## Additional test batch (2026-10-15, CLI value parsing boundaries)

- `Parser_RejectsEmptyInlineValuesForEveryValueOption`: verifies that `--database=`, `--output=`, `--id=`, enum options, and `--batch-size=` are rejected rather than accepted as empty strings.
- `Parser_DoesNotTreatFollowingOptionAsMissingOptionValue`: verifies that a subsequent switch such as `--all` or `--help` is not consumed as the previous option's value.
- `Parser_PreservesEqualsSignsInsideInlineValue`: verifies that inline paths/values containing additional `=` characters remain intact.
- `Parser_RejectsBatchSizesOutsideInt32Range`: verifies numeric overflow and underflow are rejected.
- Updated `CommandLineParser.Split` to reject blank inline values and recognize a following option as a missing value. This avoids silently swallowing command switches.

The .NET SDK is unavailable in this editing environment, so these tests have not been executed here. Run `dotnet test` locally to validate the package.


## Additional test batch (2026-10-15, cancellation during document building)

- `SingleExport_PropagatesCancellationRaisedDuringDocumentBuild`: verifies cancellation requested while a single entity is being built is propagated rather than recorded as an ordinary document-build failure.
- `AllExport_PropagatesCancellationRaisedDuringDocumentBuild`: verifies the same cancellation semantics during an export-all stream.
- Updated `ExportUseCase` to rethrow `OperationCanceledException` when the caller's cancellation token has been cancelled, for both single and all-export paths. Other builder exceptions continue to be recorded as per-entity failures.

These tests have not been executed in this environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate the package.

## Additional test batch (2026-10-16, Markdown export orchestration)

- `ExportAsync_ResolvesRequestedFormat_WritesRenderedDocumentAndReturnsIt`: verifies the requested format is resolved, the exact neutral document is rendered, the rendered result is passed to the writer with the requested output directory, and the same result is returned.
- `ExportAsync_WhenRendererThrows_DoesNotCallWriter`: verifies rendering failures propagate and no file write is attempted.
- `ExportAsync_WhenWriterIsCancelled_PropagatesCancellationAndForwardsToken`: verifies cancellation from the writer propagates and the caller's token reaches persistence.
- `ExportAsync_WithNullDocument_ThrowsBeforeResolvingRenderer` and `ExportAsync_WithBlankOutputDirectory_ThrowsBeforeRendering`: verify invalid inputs are rejected before downstream components are invoked.

These tests have not been executed in this environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate the package.

## Additional test batch (2026-10-16, YAML control-character escaping)

- `ObsidianRenderer_EscapesControlCharactersInYamlMetadata`: verifies newline, carriage-return, tab, and backslash characters in metadata values are escaped within quoted YAML scalars instead of introducing unintended physical lines or malformed values.
- Updated `ObsidianRenderer.Yaml` to escape `\r`, `\n`, and `\t` after escaping backslashes and quotes.

This regression test and renderer correction were not executed in this editing environment because the .NET SDK is unavailable. Run `dotnet test` locally.

## Additional path and file-name edge cases (MoreTests27)

- **Output folder mapping**: all seven known document types and the unknown-type fallback are checked for both export formats.
- **Stable file names**: metadata and block-content changes do not alter a file name when type and entity ID remain the same; changing the ID changes the file name.
- **Unsafe document-type characters**: path separators and reserved punctuation are sanitized while the stable ID hash remains present.
- **Portable relative paths**: generated relative paths use forward slashes and retain the expected entity folder and `.md` extension.

Validation note: the .NET SDK is not available in the editing environment. Run `dotnet test` locally to validate this test batch.

## Additional test batch (2026-10-16, renderer determinism and format boundaries)

- `Renderer_RenderingSameDocumentTwiceProducesIdenticalPathAndContent`: checks deterministic output for both Obsidian and DokuWiki, including stable paths and a final newline.
- `DokuWikiRenderer_DoesNotEmitObsidianYamlFrontmatter`: ensures metadata is not accidentally serialized as Obsidian YAML in DokuWiki output.
- `ObsidianRenderer_EmitsMetadataWithoutChangingContentBlockOrder`: verifies ordinal metadata ordering and preservation of document block order.
- `DokuWikiRenderer_EscapesPipesAndLineBreaksInTableHeadersAndRows`: verifies table delimiter and line-break escaping for both headers and row cells.

These tests were added but could not be executed in this environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate them.

## Additional test batch (2026-10-16, filesystem writer safety)

- `WriteAsync_CreatesNestedDirectoriesAndWritesUtf8WithoutBom`: verifies nested folder creation, Unicode-preserving UTF-8 output, and the absence of a UTF-8 byte-order mark.
- `WriteAsync_RejectsRelativePathThatEscapesOutputDirectory`: verifies parent-directory traversal is rejected.
- `WriteAsync_RejectsRootedPathOutsideOutputDirectory`: verifies an absolute path outside the configured root is rejected.
- `WriteAsync_RejectsBlankRelativePath`: verifies blank relative output paths are rejected before writing.
- `WriteAsync_PropagatesCancellationBeforeWritingFile`: verifies a pre-cancelled token prevents the target file from being written.

These tests have not been executed in this editing environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate them.

## Additional cross-entity link matrix tests (MoreTests30)

- `LinkResolver_UsesCorrectStableNamespaceForEverySourceAndTargetType`: covers all 49 source/target combinations across Movie, Series, Episode, Book, VideoGame, Person, and Connection, for both Obsidian relative links and DokuWiki namespace links. It also checks extension removal and slash conventions.
- `LinkResolver_UsesTargetTypeAndIdButNeverTargetTitleForStableNames`: verifies that stable link targets change when the target ID or target type changes, but remain stable when unrelated source metadata changes.

These tests have not been executed in this environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate the package.

## Additional persistence reader edge cases (MoreTests31)

- `ConnectionReader_GetAsyncReturnsOnlyDirectChildrenAndDirectWorks`: verifies the single-entity connection read returns only immediate child connections and works assigned directly to that connection, not grandchildren or work assigned to another connection/child.
- `MovieReader_ReadAllHonorsCancellationBetweenBatches`: verifies cancelling after the first item of a one-item batch stops subsequent reads and propagates cancellation.

These tests have not been executed in this editing environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate the package.

## Additional YAML scalar regression tests (MoreTests32)

- `ObsidianRenderer_QuotesYamlScalarsThatAreNotSafePlainStrings`: checks null, safe plain strings, YAML boolean-like/reserved values, numeric-looking strings, whitespace, quotes, backslashes, and embedded newlines.
- `ObsidianRenderer_UsesOneFinalNewlineForEmptyAndPopulatedDocuments`: verifies consistent single-newline termination for empty and populated Obsidian documents.

These tests have not been executed in this editing environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate this test batch.

## All-seven-document-type integration tests (MoreTests33)

- `ExportService_ExportsAllSevenTypesWithLinksToExistingTargetFiles`: runs the real Markdown export service and file writer for both Obsidian and DokuWiki, creates all seven supported document types, and checks the expected output folders and Markdown files.
- Each exported document links to the other six document types. The test verifies each rendered link target against the target file's real path and confirms all referenced files exist, catching mismatches between link resolution, path generation, renderer syntax, and filesystem output.
- The test also checks that exactly seven Markdown files are produced and that each file's contents match the returned rendered result.

These tests have not been executed in this editing environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate them.

## Connection document builder regressions (MoreTests34)

- `Build_IncludesParentAndOnlyProvidedDirectChildrenInStableOrder`: verifies parent links and direct-child links, stable child ordering by display name then ID, and connection target typing.
- `Build_GroupsWorksByTypeAndOrdersEachGroupByLocalizedTitleThenId`: verifies work-type groups are ordered consistently, work links use the requested localized titles, ties are resolved by stable ID, and public details remain present.
- `Build_UsesIdWhenChildDisplayNameIsMissingAndOmitsEmptyParentAndSections`: verifies missing display labels fall back to IDs and blank optional parent/details sections are omitted.

The .NET SDK is not available in the editing environment. Run `dotnet test` locally to compile and execute these tests.

## MoreTests34 test-data correction

The first local test run identified incorrectly ordered constructor arguments in `ConnectionDocumentBuilderRegressionTests`: `LocalizedValue` is declared as `(Original, English, German)`, but the new tests had supplied some values as `(Original, German, English)`. Corrected those test fixtures to match the domain record's declared field order; production localization behavior was not changed. The .NET SDK is not available in this editing environment, so rerun `dotnet test` locally to verify the correction.

## Series/episode relationship edge cases (MoreTests35)

- `SeriesBuilder_UsesIdAsTieBreakerForEpisodesWithSameSeasonAndEpisodeNumber`: verifies stable episode ordering when season and episode numbers match, using episode ID as the final tie-breaker.
- `EpisodeBuilder_OmitsSeriesReferenceWhenSeriesIdIsMissingOrBlank`: covers null, empty, and whitespace-only series IDs and confirms no empty series section/link is emitted while episode details remain available.
- `EpisodeBuilder_UsesSeriesIdAsLinkLabelWhenRelatedSeriesIsUnavailable`: verifies the episode keeps a stable link to its series ID when the related series display data is unavailable, and that missing season/episode values are omitted from the information table.

The .NET SDK is not available in this editing environment. Run `dotnet test` locally to compile and execute this test batch.


## Document title localization consistency (MoreTests36)

- `EveryBuilder_UsesSelectedTitleInHeadingAndMetadata`: parameterized across all seven document types and all three export languages. Confirms the visible first-level heading, metadata `title`, and stable entity ID stay consistent when all localized title variants are present.
- `EveryBuilder_FallsBackToUntitledWhenAllTitleVariantsAreBlank`: parameterized across all seven document types and all three export languages. Confirms null/whitespace-only localized values use the documented `Untitled` fallback consistently in both heading and metadata.

This test batch covers 42 cases without changing production code. The .NET SDK is not available in the editing environment; run `dotnet test` locally to compile and execute the tests.

## MoreTests37 — localized related references

Added `RelatedReferenceLocalizationTests.cs` to cover language selection on names and titles referenced from other documents:

- Movie cast links use the requested language for referenced person names.
- A missing/blank English person name falls back to the original name before German.
- Connection work links use the requested language for referenced work titles.
- A missing/blank English work title falls back to the original title for all requested languages where that is the first available fallback.

These are application-level builder tests using the format-neutral document model; they do not require a database or filesystem. The .NET SDK was not available in the authoring environment, so the suite must be verified with `dotnet test` locally.

## MoreTests38 — localized roles and person relations

Added `LocalizedRolesAndPersonRelationsTests.cs` to cover localized role labels and person-specific relationship sections:

- Movie cast roles select English or German text according to the requested export language, with the original-language request following the current fallback behavior.
- Blank cast-role translations do not produce an empty role paragraph.
- Person family relationships preserve the target Person ID/type and include relationship labels and localized role text.
- Blank requested relationship-role values fall back to the next available supported value.
- Person cause-of-death sections use the language-specific value and are omitted when both translations are blank.

These are application-level builder tests and do not require a database or filesystem. The .NET SDK was unavailable in the authoring environment; run `dotnet test` locally to compile and execute the tests.

## Additional test batch (localized credits and awards)

- `LocalizedCreditAndAwardTests` checks English/German crew-role selection and omission of an empty crew section when the row has no usable person or role.
- Company-credit tests verify localized role labels while preserving department/country values and the stable company reference.
- Award contributor tests verify localized award titles and contributor roles, retain person links when the role label is blank, and cover the `Movie_AwardID` foreign-key naming variant.

The editing environment does not have the .NET SDK, so these tests were not executed here. Run `dotnet test` locally to validate the package.

## MoreTests40 — relationship ordering and incomplete cast rows

- `MovieBuilder_OrdersCastByExplicitOrderThenStableRowId` verifies cast rows sort by their explicit order and use row ID as a deterministic tie-breaker.
- `MovieBuilder_OrdersCastByRowIdWhenOrderValuesAreEqualOrMissing` verifies stable ordering when order values are equal or absent.
- `MovieBuilder_KeepsCharacterAndDubberReferencesWhenActorIsMissing` ensures other person relationships are not lost just because the actor reference is blank.
- `MovieBuilder_DoesNotEmitCastSectionForRowsWithoutAnyUsableRelationshipOrRole` checks that an empty relationship row does not create an empty Cast section.

These application-level regression tests do not require a database or filesystem. The .NET SDK is not available in the authoring environment; run `dotnet test` locally to compile and execute this batch.

## Additional test batch (2026-10-18, relationship isolation and ordering)

- `MovieBuilder_AssignsAwardContributorsOnlyToTheirOwningAward`: ensures contributors are scoped to their parent award and do not appear under another award.
- `MovieBuilder_OrdersAwardsByOrderThenStableId`: verifies deterministic award ordering when explicit order values tie.
- `MovieBuilder_OrdersCompanyCreditsByOrderThenStableId`: verifies company-credit ordering is deterministic across equal order values.
- `PersonBuilder_OrdersFamilyReferencesByOrderThenStableId`: verifies family links follow explicit order and stable row ID tie-breaking.

These tests have been added but could not be executed in this environment because the .NET SDK is unavailable. Run `dotnet test` locally to validate the package.

## Additional tests in MoreTests42 — person relationship edge cases

- Five cases verify that family, employer, position, profession, and species sections are omitted when every target ID is null or whitespace, even if a row contains role text.
- Five cases verify that a valid reference remains while a blank-target relationship row is ignored, and that the corresponding section is present.
- `PersonDocumentBuilder.AddRelationList` now filters rows with blank target IDs before deciding whether a section should be emitted, preventing empty relationship headings.

Validation: not run in this authoring environment because the .NET SDK is unavailable. Run `dotnet test` locally.

## MoreTests43 — repeated references and deterministic ordering

- `PersonBuilder_PreservesMultipleFamilyRelationshipsToSamePerson` checks that two distinct family relationship rows targeting the same person remain separate and retain their own relationship labels.
- `PersonBuilder_ProducesSameRelationshipOrderWhenInputRowsAreReversed` verifies employer links are ordered deterministically regardless of the incoming row order.
- `ConnectionBuilder_PreservesRepeatedWorkReferencesAndOrdersThemByIdWhenTitlesMatch` checks same-title work references use ID as a stable tie-breaker and repeated references are not silently removed.
- `SeriesBuilder_PreservesEpisodeReferencesWithSameTitleAndNumbersButDifferentIds` verifies episodes with identical displayed title and season/episode numbers remain distinct and sort by ID.

These tests specify preservation of distinct relationship records rather than applying blanket de-duplication, since repeated references can carry separate relationship meaning. Tests were not run in the authoring environment because the .NET SDK is unavailable; run `dotnet test` locally.
