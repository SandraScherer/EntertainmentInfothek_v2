using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Renders a format-neutral document and persists the rendered output.</summary>
public sealed class MarkdownExportService(IMarkdownRendererResolver renderers, IExportFileWriter writer) : IMarkdownExportService
{
    /// <inheritdoc />
    public async Task<RenderedDocument> ExportAsync(MarkdownDocument document, ExportFormat format, string outputDirectory, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(document);
        ArgumentException.ThrowIfNullOrWhiteSpace(outputDirectory);

        var rendered = renderers.Resolve(format).Render(document);
        await writer.WriteAsync(rendered, outputDirectory, ct);
        return rendered;
    }
}
