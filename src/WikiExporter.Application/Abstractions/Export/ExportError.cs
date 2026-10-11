using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Defines the export error type.</summary>
public sealed record ExportError(string? EntityId, string Message, Exception? Exception = null);
