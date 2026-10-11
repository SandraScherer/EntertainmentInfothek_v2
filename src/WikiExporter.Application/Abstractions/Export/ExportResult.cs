using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Defines the export result type.</summary>
public sealed record ExportResult(
    ExportEntityType EntityType,
    int RequestedItems,
    int SuccessfullyBuilt,
    int FailedItems,
    IReadOnlyList<ExportedDocument> Documents,
    IReadOnlyList<ExportError> Errors);
