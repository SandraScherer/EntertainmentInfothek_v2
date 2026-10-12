namespace WikiExporter.Application.Documents.Models;

/// <summary>Represents heading block.</summary>
public sealed record HeadingBlock(int Level, string Text) : MarkdownBlock;
