using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Defines the i export use case type.</summary>
public interface IExportUseCase
{
    Task<ExportResult> ExecuteAsync(ExportRequest request, CancellationToken ct = default);
}

/// <summary>Defines the i export reader resolver type.</summary>
public interface IExportReaderResolver
{
    IExportReaderAdapter Resolve(ExportEntityType type);
}

/// <summary>Defines the i export reader adapter type.</summary>
public interface IExportReaderAdapter
{
    Task<ExportDataBase?> GetAsync(string id, CancellationToken ct);
    IAsyncEnumerable<ExportDataBase> ReadAllAsync(Persistence.BatchOptions options, CancellationToken ct);
}

/// <summary>Defines the i document builder resolver type.</summary>
public interface IDocumentBuilderResolver
{
    IDocumentBuilder Resolve(ExportEntityType type);
}

/// <summary>Defines the i document builder type.</summary>
public interface IDocumentBuilder
{
    ExportEntityType EntityType { get; }
    MarkdownDocument Build(ExportDataBase data, ExportLanguage language);
}

/// <summary>Defines the i localized value selector type.</summary>
public interface ILocalizedValueSelector
{
    string? Select(LocalizedValue value, ExportLanguage language);
}

/// <summary>Defines the export result type.</summary>
public sealed record ExportResult(
    ExportEntityType EntityType,
    int RequestedItems,
    int SuccessfullyBuilt,
    int FailedItems,
    IReadOnlyList<ExportedDocument> Documents,
    IReadOnlyList<ExportError> Errors);

/// <summary>Defines the exported document type.</summary>
public sealed record ExportedDocument(string EntityId, ExportEntityType EntityType, MarkdownDocument Document);
/// <summary>Defines the export error type.</summary>
public sealed record ExportError(string? EntityId, string Message, Exception? Exception = null);
