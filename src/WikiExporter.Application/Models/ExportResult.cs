namespace WikiExporter.Application.Models;

public sealed class ExportResult
{
    public bool Success { get; init; }

    public string FilePath { get; init; } = string.Empty;

    public IReadOnlyCollection<string> Warnings { get; init; } = [];

    public IReadOnlyCollection<string> Errors { get; init; } = [];
}
