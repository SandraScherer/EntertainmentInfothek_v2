namespace WikiExporter.Application.Models;

public sealed class ExportRequest
{
    public required string RecordId { get; init; }

    public required string Language { get; init; }

    public required ExportFormat Format { get; init; }

    public required string OutputFolder { get; init; }
}
