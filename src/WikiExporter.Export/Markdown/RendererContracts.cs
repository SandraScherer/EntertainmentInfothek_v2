using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Rendered output plus the relative export path selected for the document.</summary>
public sealed record RenderedDocument(string RelativePath, string Content, string ContentType = "text/markdown; charset=utf-8");

/// <summary>Serializes the neutral Markdown document tree into one concrete wiki dialect.</summary>
public interface IMarkdownRenderer
{
    ExportFormat Format { get; }
    RenderedDocument Render(MarkdownDocument document);
}

public interface IMarkdownRendererResolver
{
    IMarkdownRenderer Resolve(ExportFormat format);
}

/// <summary>Resolves stable export paths independently of the Markdown syntax.</summary>
public interface IExportPathResolver
{
    string GetRelativePath(MarkdownDocument document, ExportFormat format);
    string GetDirectory(MarkdownDocument document, ExportFormat format);
}

/// <summary>Creates a deterministic, file-system-safe base file name.</summary>
public interface IExportFileNameGenerator
{
    string Generate(MarkdownDocument document);
}

/// <summary>Resolves links between exported documents. Renderers only ask for the final target string.</summary>
public interface IExportLinkResolver
{
    string Resolve(MarkdownDocument source, string targetType, string targetId, ExportFormat format);
}

public interface IExportFileWriter
{
    Task WriteAsync(RenderedDocument document, string outputDirectory, CancellationToken ct = default);
}
