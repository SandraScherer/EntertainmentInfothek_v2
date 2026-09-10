namespace WikiExporter.Application.Documents;

public sealed class ExportMetadata
{
    public string SourceTable { get; init; } = string.Empty;

    public string Status { get; init; } = string.Empty;

    public string LastUpdated { get; init; } = string.Empty;

    public IList<string> Tags { get; init; } = new List<string>();
}
