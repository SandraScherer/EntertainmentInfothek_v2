namespace WikiExporter.Application.Documents.Models;

/// <summary>Represents code block.</summary>
public sealed record CodeBlock(string Content, string? Language = null) : MarkdownBlock;
