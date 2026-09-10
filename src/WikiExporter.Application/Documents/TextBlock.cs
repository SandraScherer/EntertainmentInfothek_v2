namespace WikiExporter.Application.Documents;

public sealed class TextBlock
    : ExportBlock
{
    public override ExportBlockType BlockType => ExportBlockType.Text;

    public required string Text { get; init; }
}
