namespace WikiExporter.Application.Documents.Models;

/// <summary>Defines the paragraph block type.</summary>
public sealed record ParagraphBlock(string Text) : MarkdownBlock;
