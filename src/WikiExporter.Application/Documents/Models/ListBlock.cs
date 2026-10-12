namespace WikiExporter.Application.Documents.Models;

/// <summary>Represents list block.</summary>
public sealed record ListBlock(IReadOnlyList<string> Items, bool Ordered = false) : MarkdownBlock;
