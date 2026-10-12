namespace WikiExporter.Application.Documents.Models;

/// <summary>Represents link block.</summary>
public sealed record LinkBlock(string Text, string TargetType, string TargetId) : MarkdownBlock;
