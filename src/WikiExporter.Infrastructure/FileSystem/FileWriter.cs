using WikiExporter.Application.Exceptions;
using WikiExporter.Application.Interfaces;

namespace WikiExporter.Infrastructure.FileSystem;

/// <summary>
/// Schreibt Exportdateien auf die Festplatte.
/// </summary>
public sealed class FileWriter
    : IFileWriter
{
    public async Task WriteAsync(
        string folder,
        string fileName,
        string content,
        CancellationToken cancellationToken)
    {
        try
        {
            Directory.CreateDirectory(
                folder);

            var path =
                Path.Combine(
                    folder,
                    fileName);

            await File.WriteAllTextAsync(
                path,
                content,
                cancellationToken);
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new ExportFailedException(
                "No write permission.",
                ex);
        }
        catch (IOException ex)
        {
            throw new ExportFailedException(
                "Error writing export file.",
                ex);
        }
    }
}
