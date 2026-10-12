namespace WikiExporter.Application.Documents.Models;

/// <summary>Represents image block.</summary>
public sealed record ImageBlock(string? FileName, string? Description, string? TargetId = null) : MarkdownBlock;
