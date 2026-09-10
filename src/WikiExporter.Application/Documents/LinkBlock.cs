namespace WikiExporter.Application.Documents;

public sealed class LinkBlock
    : ExportBlock
{
    public override ExportBlockType BlockType => ExportBlockType.Link;

    public required string Text { get; init; }

    public required string Url { get; init; }
}
