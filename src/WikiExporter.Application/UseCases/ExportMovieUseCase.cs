using Microsoft.Extensions.Logging;

using WikiExporter.Application.Exceptions;
using WikiExporter.Application.Interfaces;
using WikiExporter.Application.Models;
using WikiExporter.Application.Validation;

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
        ExportRequestValidator.Validate(
            request);

        _logger.LogInformation(
            "Movie export started for {MovieId}",
            request.RecordId);

        try
        {
            // 1. Movie laden
            _logger.LogDebug(
                "Loading movie.");

            var dto =
                await _repository.GetForExportAsync(
                    request.RecordId,
                    cancellationToken);

            cancellationToken
                .ThrowIfCancellationRequested();

            // 2. ExportDocument erzeugen
            _logger.LogDebug(
                "Building export document.");

            var document =
                _builder.Build(
                    dto,
                    request.Language);

            cancellationToken
                .ThrowIfCancellationRequested();

            // 3. Renderer auswählen
            _logger.LogDebug(
                "Rendering markdown.");

            var renderer =
                _rendererFactory.Create(
                    request.Format);

            cancellationToken
                .ThrowIfCancellationRequested();

            // 4. Markdown rendern
            var markdown =
                 renderer.Render(document);

            cancellationToken
                .ThrowIfCancellationRequested();

            // 5. Dateiendung bestimmen
            _logger.LogDebug(
                "Writing output file.");

            var extension =
                request.Format switch
                {
                    ExportFormat.Obsidian => ".md",
                    ExportFormat.DokuWiki => ".txt",
                    _ => throw new NotSupportedException(
                        $"Unsupported format: {request.Format}")
                };

            cancellationToken
                .ThrowIfCancellationRequested();

            // 6. Dateiname erzeugen
            var fileName =
                document.Slug + extension;

            cancellationToken
                .ThrowIfCancellationRequested();

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
        catch (ValidationException ex)
        {
            _logger.LogWarning(
                ex,
                "Validation failed.");

            return new ExportResult
            {
                Success = false,
                Errors =
                [
                    ex.Message
                ]
            };
        }
        catch (MovieNotFoundException ex)
        {
            _logger.LogWarning(
                ex,
                "Movie not found.");

            return new ExportResult
            {
                Success = false,
                Errors =
                [
                    ex.Message
                ]
            };
        }
        catch (ExportFailedException ex)
        {
            _logger.LogError(
                ex,
                "Export failed.");

            return new ExportResult
            {
                Success = false,
                Errors =
                [
                    ex.Message
                ]
            };
        }
        catch (Exception ex)
        {
            _logger.LogCritical(
                ex,
                "Unexpected export failure.");

            return new ExportResult
            {
                Success = false,
                Errors =
                [
                    "Unexpected error occurred."
                ]
            };
        }
    }
}
