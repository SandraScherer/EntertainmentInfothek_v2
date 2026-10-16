using System.Text;
using WikiExporter.Export.FileSystem;
using WikiExporter.Export.Markdown;

namespace WikiExporter.Export.Tests;

/// <summary>Checks filesystem writer encoding, directory creation, and path containment.</summary>
public sealed class FileSystemExportFileWriterSecurityTests
{
    [Fact]
    public async Task WriteAsync_CreatesNestedDirectoriesAndWritesUtf8WithoutBom()
    {
        var root = CreateTemporaryDirectory();
        try
        {
            var writer = new FileSystemExportFileWriter();
            const string content = "# Äther und 日本語 🎬\nZweite Zeile\n";
            var document = new RenderedDocument("Movies/Nested/movie-1.md", content);

            await writer.WriteAsync(document, root);

            var path = Path.Combine(root, "Movies", "Nested", "movie-1.md");
            Assert.True(File.Exists(path));
            var bytes = await File.ReadAllBytesAsync(path);
            Assert.False(bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF);
            Assert.Equal(content, Encoding.UTF8.GetString(bytes));
        }
        finally
        {
            DeleteTemporaryDirectory(root);
        }
    }

    [Theory]
    [InlineData("../outside.md")]
    [InlineData("Movies/../../outside.md")]
    public async Task WriteAsync_RejectsRelativePathThatEscapesOutputDirectory(string relativePath)
    {
        var root = CreateTemporaryDirectory();
        try
        {
            var writer = new FileSystemExportFileWriter();

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                writer.WriteAsync(new RenderedDocument(relativePath, "must not be written"), root));

            Assert.False(File.Exists(Path.GetFullPath(Path.Combine(root, relativePath))));
        }
        finally
        {
            DeleteTemporaryDirectory(root);
        }
    }

    [Fact]
    public async Task WriteAsync_RejectsRootedPathOutsideOutputDirectory()
    {
        var root = CreateTemporaryDirectory();
        var outsidePath = Path.Combine(Path.GetTempPath(), $"wikiexporter-outside-{Guid.NewGuid():N}.md");
        try
        {
            var writer = new FileSystemExportFileWriter();

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                writer.WriteAsync(new RenderedDocument(outsidePath, "must not be written"), root));

            Assert.False(File.Exists(outsidePath));
        }
        finally
        {
            DeleteTemporaryDirectory(root);
            if (File.Exists(outsidePath)) File.Delete(outsidePath);
        }
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public async Task WriteAsync_RejectsBlankRelativePath(string relativePath)
    {
        var writer = new FileSystemExportFileWriter();
        var root = CreateTemporaryDirectory();
        try
        {
            await Assert.ThrowsAsync<ArgumentException>(() =>
                writer.WriteAsync(new RenderedDocument(relativePath, "content"), root));
        }
        finally
        {
            DeleteTemporaryDirectory(root);
        }
    }

    [Fact]
    public async Task WriteAsync_PropagatesCancellationBeforeWritingFile()
    {
        var root = CreateTemporaryDirectory();
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();
        try
        {
            var writer = new FileSystemExportFileWriter();
            await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
                writer.WriteAsync(new RenderedDocument("Movies/cancelled.md", "content"), root, cancellation.Token));
            var target = Path.Combine(root, "Movies", "cancelled.md");
            Assert.True(!File.Exists(target) || new FileInfo(target).Length == 0);
        }
        finally
        {
            DeleteTemporaryDirectory(root);
        }
    }

    private static string CreateTemporaryDirectory()
    {
        var path = Path.Combine(Path.GetTempPath(), "WikiExporterWriterTests", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(path);
        return path;
    }

    private static void DeleteTemporaryDirectory(string path)
    {
        if (Directory.Exists(path)) Directory.Delete(path, recursive: true);
    }
}
