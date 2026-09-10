using Microsoft.Extensions.Logging;

using WikiExporter.Application.Interfaces;
using WikiExporter.Application.Models;

namespace WikiExporter.Application.UseCases;

/// <summary>
/// Führt den vollständigen Movie-Export aus.
///
/// Ablauf:
///
/// Repository
///     ↓
/// MovieExportDto
///     ↓
/// Builder
///     ↓
/// ExportDocument
///     ↓
/// RendererFactory
///     ↓
/// Obsidian/DokuWiki Renderer
///     ↓
/// Markdown
///     ↓
/// FileWriter
/// </summary>
public sealed class ExportMovieUseCase
{
    private readonly IMovieRepository _repository;

    private readonly IMovieExportDocumentBuilder _builder;

    private readonly IMarkdownRendererFactory _rendererFactory;

    private readonly IFileWriter _fileWriter;

    private readonly ILogger<ExportMovieUseCase> _logger;

    public ExportMovieUseCase(
        IMovieRepository repository,
        IMovieExportDocumentBuilder builder,
        IMarkdownRendererFactory rendererFactory,
        IFileWriter fileWriter,
        ILogger<ExportMovieUseCase> logger)
    {
        _repository = repository;
        _builder = builder;
        _rendererFactory = rendererFactory;
        _fileWriter = fileWriter;
        _logger = logger;
    }

    /// <summary>
    /// Exportiert einen Movie-Datensatz.
    /// </summary>
    public async Task<ExportResult> ExecuteAsync(
        ExportRequest request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        _logger.LogInformation(
            "Movie export started for {MovieId}",
            request.RecordId);

        try
        {
            // 1. Movie laden
            var dto =
                await _repository.GetForExportAsync(
                    request.RecordId,
                    cancellationToken);

            // 2. ExportDocument erzeugen
            var document =
                _builder.Build(
                    dto,
                    request.Language);

            // 3. Renderer auswählen
            var renderer =
                _rendererFactory.Create(
                    request.Format);

            // 4. Markdown rendern
            var markdown =
                 renderer.Render(document);

            // 5. Dateiendung bestimmen
            var extension =
                request.Format switch
                {
                    ExportFormat.Obsidian => ".md",
                    ExportFormat.DokuWiki => ".txt",
                    _ => throw new NotSupportedException(
                        $"Unsupported format: {request.Format}")
                };

            // 6. Dateiname erzeugen
            var fileName =
                document.Slug + extension;

            // 7. Datei schreiben
            await _fileWriter.WriteAsync(
                request.OutputFolder,
                fileName,
                markdown,
                cancellationToken);

            var filePath =
                Path.Combine(
                    request.OutputFolder,
                    fileName);

            _logger.LogInformation(
                "Movie export completed successfully: {Path}",
                filePath);

            return new ExportResult
            {
                Success = true,
                FilePath = filePath,
                Warnings = Array.Empty<string>(),
                Errors = Array.Empty<string>()
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "Movie export failed for {MovieId}",
                request.RecordId);

            return new ExportResult
            {
                Success = false,
                FilePath = string.Empty,
                Warnings = Array.Empty<string>(),
                Errors = new[]
                {
                    ex.Message
                }
            };
        }
    }
}
