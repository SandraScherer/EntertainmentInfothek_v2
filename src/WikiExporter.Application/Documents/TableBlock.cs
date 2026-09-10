namespace WikiExporter.Application.Documents;

public sealed class TableBlock
    : ExportBlock
{
    public override ExportBlockType BlockType => ExportBlockType.Table;

    public IList<string> Headers { get; init; } = new List<string>();

    public IList<IList<string>> Rows { get; init; } = new List<IList<string>>();
}
