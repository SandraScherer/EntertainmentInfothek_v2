namespace WikiExporter.Application.Documents.Models;

/// <summary>Represents table block.</summary>
public sealed record TableBlock(IReadOnlyList<string> Headers, IReadOnlyList<IReadOnlyList<string>> Rows) : MarkdownBlock;
