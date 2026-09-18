using System.Text;
using WikiExporter.Export.Markdown;

namespace WikiExporter.Export.FileSystem;

/// <summary>Writes UTF-8 Markdown beneath the caller-selected export directory.</summary>
public sealed class FileSystemExportFileWriter : IExportFileWriter
{
    public async Task WriteAsync(RenderedDocument document, string outputDirectory, CancellationToken ct = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(outputDirectory);
        ArgumentException.ThrowIfNullOrWhiteSpace(document.RelativePath);

        var root = Path.GetFullPath(outputDirectory);
        var path = Path.GetFullPath(Path.Combine(root, document.RelativePath.Replace('/', Path.DirectorySeparatorChar)));
        if (!path.StartsWith(root.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("The resolved export path escapes the configured output directory.");

        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        await File.WriteAllTextAsync(path, document.Content, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false), ct);
    }
}
