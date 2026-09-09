using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

public interface IExportUseCase
{
    Task<ExportResult> ExecuteAsync(ExportRequest request, CancellationToken ct = default);
}

public interface IExportReaderResolver
{
    IExportReaderAdapter Resolve(ExportEntityType type);
}

public interface IExportReaderAdapter
{
    Task<ExportDataBase?> GetAsync(string id, CancellationToken ct);
    IAsyncEnumerable<ExportDataBase> ReadAllAsync(Persistence.BatchOptions options, CancellationToken ct);
}

public interface IDocumentBuilderResolver
{
    IDocumentBuilder Resolve(ExportEntityType type);
}

public interface IDocumentBuilder
{
    ExportEntityType EntityType { get; }
    MarkdownDocument Build(ExportDataBase data, ExportLanguage language);
}

public interface ILocalizedValueSelector
{
    string? Select(LocalizedValue value, ExportLanguage language);
}

public sealed record ExportResult(
    ExportEntityType EntityType,
    int RequestedItems,
    int SuccessfullyBuilt,
    int FailedItems,
    IReadOnlyList<ExportedDocument> Documents,
    IReadOnlyList<ExportError> Errors);

public sealed record ExportedDocument(string EntityId, ExportEntityType EntityType, MarkdownDocument Document);
public sealed record ExportError(string? EntityId, string Message, Exception? Exception = null);
