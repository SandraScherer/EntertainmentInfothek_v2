using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Represents exported document.</summary>
public sealed record ExportedDocument(string EntityId, ExportEntityType EntityType, MarkdownDocument Document);
