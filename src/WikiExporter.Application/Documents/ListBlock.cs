namespace WikiExporter.Application.Documents;

public sealed class ListBlock
    : ExportBlock
{
    public override ExportBlockType BlockType => ExportBlockType.List;

    public IList<string> Items { get; init; } = new List<string>();
}
