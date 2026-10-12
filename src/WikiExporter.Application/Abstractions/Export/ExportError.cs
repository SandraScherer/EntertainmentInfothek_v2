using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Represents export error.</summary>
public sealed record ExportError(string? EntityId, string Message, Exception? Exception = null);
