using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Rendered output plus the relative export path selected for the document.</summary>
public sealed record RenderedDocument(string RelativePath, string Content, string ContentType = "text/markdown; charset=utf-8");
