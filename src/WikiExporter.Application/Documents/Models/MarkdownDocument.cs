namespace WikiExporter.Application.Documents.Models;

/// <summary>Format-neutral document tree. Concrete renderers decide how headings, links and metadata are serialized.</summary>
public sealed record MarkdownDocument(
    string DocumentType,
    string EntityId,
    IReadOnlyDictionary<string,string?> Metadata,
    IReadOnlyList<MarkdownBlock> Blocks);

public abstract record MarkdownBlock;
public sealed record HeadingBlock(int Level, string Text) : MarkdownBlock;
public sealed record ParagraphBlock(string Text) : MarkdownBlock;
public sealed record TableBlock(IReadOnlyList<string> Headers, IReadOnlyList<IReadOnlyList<string>> Rows) : MarkdownBlock;
public sealed record ListBlock(IReadOnlyList<string> Items, bool Ordered = false) : MarkdownBlock;
public sealed record LinkBlock(string Text, string TargetType, string TargetId) : MarkdownBlock;
public sealed record ImageBlock(string? FileName, string? Description, string? TargetId = null) : MarkdownBlock;
public sealed record CodeBlock(string Content, string? Language = null) : MarkdownBlock;
public sealed record HorizontalRuleBlock() : MarkdownBlock;
