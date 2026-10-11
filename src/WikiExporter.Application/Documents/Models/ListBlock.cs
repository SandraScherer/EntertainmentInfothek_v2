namespace WikiExporter.Application.Documents.Models;

/// <summary>Defines the list block type.</summary>
public sealed record ListBlock(IReadOnlyList<string> Items, bool Ordered = false) : MarkdownBlock;
