using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown;

/// <summary>Exports a neutral Markdown document by rendering it and writing the result to disk.</summary>
public interface IMarkdownExportService
{
    /// <summary>Renders and writes a document using the selected format.</summary>
    /// <param name="document">The format-neutral document to export.</param>
    /// <param name="format">The target Markdown format.</param>
    /// <param name="outputDirectory">The directory where the rendered document is written.</param>
    /// <param name="ct">A cancellation token.</param>
    /// <returns>The rendered document, including its output path and content.</returns>
    Task<RenderedDocument> ExportAsync(MarkdownDocument document, ExportFormat format, string outputDirectory, CancellationToken ct = default);
}
