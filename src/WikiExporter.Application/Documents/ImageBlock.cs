namespace WikiExporter.Application.Documents;

public sealed class ImageBlock
    : ExportBlock
{
    public override ExportBlockType BlockType => ExportBlockType.Image;

    public required string FileName { get; init; }

    public string Caption { get; init; } = string.Empty;
}
