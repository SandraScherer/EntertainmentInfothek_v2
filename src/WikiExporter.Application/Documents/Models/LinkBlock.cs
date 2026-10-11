namespace WikiExporter.Application.Documents.Models;

/// <summary>Defines the link block type.</summary>
public sealed record LinkBlock(string Text, string TargetType, string TargetId) : MarkdownBlock;
