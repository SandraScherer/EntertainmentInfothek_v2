namespace WikiExporter.Application.Documents.Models;

/// <summary>Format-neutral document tree; renderers decide how headings, links and metadata are serialized.</summary>
/// <param name="DocumentType">The exported entity's document type.</param>
/// <param name="EntityId">Stable identifier of the exported entity.</param>
/// <param name="Metadata">Metadata to be emitted by the target renderer.</param>
/// <param name="Blocks">Ordered content blocks for the document.</param>
public sealed record MarkdownDocument(
    string DocumentType,
    string EntityId,
    IReadOnlyDictionary<string, string?> Metadata,
    IReadOnlyList<MarkdownBlock> Blocks);
