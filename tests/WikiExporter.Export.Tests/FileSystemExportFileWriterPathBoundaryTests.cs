using WikiExporter.Export.FileSystem;
using WikiExporter.Export.Markdown;

namespace WikiExporter.Export.Tests;

/// <summary>Exercises path-boundary cases that are easy to miss in ordinary traversal tests.</summary>
public sealed class FileSystemExportFileWriterPathBoundaryTests
{
    [Fact]
    public async Task WriteAsync_RejectsSiblingPathThatSharesOutputRootPrefix()
    {
        var parent = CreateTemporaryDirectory();
        var root = Path.Combine(parent, "export");
        var sibling = Path.Combine(parent, "export-evil");
        Directory.CreateDirectory(root);
        try
        {
            var writer = new FileSystemExportFileWriter();

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                writer.WriteAsync(new RenderedDocument("../export-evil/escaped.md", "must not be written"), root));

            Assert.False(File.Exists(Path.Combine(sibling, "escaped.md")));
        }
        finally
        {
            DeleteTemporaryDirectory(parent);
        }
    }

    [Fact]
    public async Task WriteAsync_AcceptsOutputRootWithTrailingDirectorySeparator()
    {
        var root = CreateTemporaryDirectory();
        try
        {
            var writer = new FileSystemExportFileWriter();
            var rootWithSeparator = root + Path.DirectorySeparatorChar;

            await writer.WriteAsync(new RenderedDocument("Movies/movie-9.md", "content"), rootWithSeparator);

            Assert.Equal("content", await File.ReadAllTextAsync(Path.Combine(root, "Movies", "movie-9.md")));
        }
        finally
        {
            DeleteTemporaryDirectory(root);
        }
    }

    [Fact]
    public async Task WriteAsync_RejectsNullCharacterInRelativePathWithoutWritingFile()
    {
        var root = CreateTemporaryDirectory();
        try
        {
            var writer = new FileSystemExportFileWriter();

            await Assert.ThrowsAsync<ArgumentException>(() =>
                writer.WriteAsync(new RenderedDocument("Movies/bad\0name.md", "must not be written"), root));

            Assert.Empty(Directory.GetFiles(root, "*", SearchOption.AllDirectories));
        }
        finally
        {
            DeleteTemporaryDirectory(root);
        }
    }

    private static string CreateTemporaryDirectory()
    {
        var path = Path.Combine(Path.GetTempPath(), "WikiExporterPathBoundaryTests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(path);
        return path;
    }

    private static void DeleteTemporaryDirectory(string path)
    {
        if (Directory.Exists(path)) Directory.Delete(path, recursive: true);
    }
}
