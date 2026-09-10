namespace WikiExporter.Application.Documents;

public abstract class ExportBlock
{
    public abstract ExportBlockType BlockType { get; }

    public int Order { get; init; }
}
