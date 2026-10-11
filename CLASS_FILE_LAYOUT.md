# Class and type file layout

The source has been reorganized so each top-level class, record, struct, interface, and enum is defined in its own `.cs` file named after the type. This includes the export data records, Markdown block records, renderer contracts, document builders, test classes, and command-line types.

Nested `ExportScope.Single` and `ExportScope.All` remain nested to preserve the existing public API, but their declarations are in separate files using a partial `ExportScope` declaration. Reader adapters have been extracted from `ExportReaderResolver` into individual files without changing their resolver-facing behavior.

No intentional functional changes were made. Please run `dotnet test` after extracting the archive; this environment does not have the .NET SDK available to verify the build locally.
