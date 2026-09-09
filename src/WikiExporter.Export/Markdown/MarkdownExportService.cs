using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Convenience service used by the composition root: render a neutral document and persist it.</summary>
public interface IMarkdownExportService
{
    Task<RenderedDocument> ExportAsync(MarkdownDocument document, ExportFormat format, string outputDirectory, CancellationToken ct = default);
}

public sealed class MarkdownExportService(IMarkdownRendererResolver renderers, IExportFileWriter writer) : IMarkdownExportService
{
    public async Task<RenderedDocument> ExportAsync(MarkdownDocument document, ExportFormat format, string outputDirectory, CancellationToken ct = default)
    {
        var rendered = renderers.Resolve(format).Render(document);
        await writer.WriteAsync(rendered, outputDirectory, ct);
        return rendered;
    }
}
