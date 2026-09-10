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
        Directory.CreateDirectory(folder);

        var path =
            Path.Combine(folder, fileName);

        await File.WriteAllTextAsync(
            path,
            content,
            cancellationToken);
    }
}
