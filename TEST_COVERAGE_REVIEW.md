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
