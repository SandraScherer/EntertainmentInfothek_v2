namespace WikiExporter.Application.Documents.Models;

/// <summary>Defines the code block type.</summary>
public sealed record CodeBlock(string Content, string? Language = null) : MarkdownBlock;
