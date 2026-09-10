namespace WikiExporter.Application.Documents;

public sealed class ExportSection
{
    public required string Title { get; init; }

    public int Order { get; init; }

    public IList<ExportBlock> Blocks { get; init; } = new List<ExportBlock>();
}
