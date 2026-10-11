namespace WikiExporter.Application.Documents.Models;

/// <summary>Defines the table block type.</summary>
public sealed record TableBlock(IReadOnlyList<string> Headers, IReadOnlyList<IReadOnlyList<string>> Rows) : MarkdownBlock;
