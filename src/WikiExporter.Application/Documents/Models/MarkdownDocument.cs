namespace WikiExporter.Application.Documents.Models;

/// <summary>Format-neutral document tree. Concrete renderers decide how headings, links and metadata are serialized.</summary>
public sealed record MarkdownDocument(
    string DocumentType,
    string EntityId,
    IReadOnlyDictionary<string,string?> Metadata,
    IReadOnlyList<MarkdownBlock> Blocks);

/// <summary>Defines the markdown block type.</summary>
public abstract record MarkdownBlock;
/// <summary>Defines the heading block type.</summary>
public sealed record HeadingBlock(int Level, string Text) : MarkdownBlock;
/// <summary>Defines the paragraph block type.</summary>
public sealed record ParagraphBlock(string Text) : MarkdownBlock;
/// <summary>Defines the table block type.</summary>
public sealed record TableBlock(IReadOnlyList<string> Headers, IReadOnlyList<IReadOnlyList<string>> Rows) : MarkdownBlock;
/// <summary>Defines the list block type.</summary>
public sealed record ListBlock(IReadOnlyList<string> Items, bool Ordered = false) : MarkdownBlock;
/// <summary>Defines the link block type.</summary>
public sealed record LinkBlock(string Text, string TargetType, string TargetId) : MarkdownBlock;
/// <summary>Defines the image block type.</summary>
public sealed record ImageBlock(string? FileName, string? Description, string? TargetId = null) : MarkdownBlock;
/// <summary>Defines the code block type.</summary>
public sealed record CodeBlock(string Content, string? Language = null) : MarkdownBlock;
/// <summary>Defines the horizontal rule block type.</summary>
public sealed record HorizontalRuleBlock() : MarkdownBlock;
