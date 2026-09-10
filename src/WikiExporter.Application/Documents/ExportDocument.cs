using WikiExporter.Application.Models;

namespace WikiExporter.Application.Documents;

public sealed class ExportDocument
{
    public required string Id { get; init; }

    public required string Title { get; init; }

    public required string Slug { get; init; }

    public required string Language { get; init; }

    public required ExportEntityType EntityType { get; init; }

    public required ExportMetadata Metadata { get; init; }

    public IList<ExportSection> Sections { get; init; } = new List<ExportSection>();
}
