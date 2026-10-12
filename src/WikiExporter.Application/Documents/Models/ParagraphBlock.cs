namespace WikiExporter.Application.Documents.Models;

/// <summary>Represents paragraph block.</summary>
public sealed record ParagraphBlock(string Text) : MarkdownBlock;
