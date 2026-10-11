namespace WikiExporter.Application.Documents.Models;

/// <summary>Defines the heading block type.</summary>
public sealed record HeadingBlock(int Level, string Text) : MarkdownBlock;
