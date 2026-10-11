namespace WikiExporter.Application.Documents.Models;

/// <summary>Defines the image block type.</summary>
public sealed record ImageBlock(string? FileName, string? Description, string? TargetId = null) : MarkdownBlock;
