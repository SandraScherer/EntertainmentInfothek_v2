using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.Markdown;

namespace WikiExporter.Export.Tests;

/// <summary>Checks orchestration between renderer selection and file persistence.</summary>
public sealed class MarkdownExportServiceTests
{
    [Theory]
    [InlineData(ExportFormat.Obsidian)]
    [InlineData(ExportFormat.DokuWiki)]
    public async Task ExportAsync_ResolvesRequestedFormat_WritesRenderedDocumentAndReturnsIt(ExportFormat format)
    {
        var document = new MarkdownDocument("Movie", "movie-42", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());
        var rendered = new RenderedDocument("Movies/Movie-movie-42.md", "# Title\n");
        var renderer = new StubRenderer(format, rendered);
        var resolver = new RecordingRendererResolver(renderer);
        var writer = new RecordingWriter();
        var sut = new MarkdownExportService(resolver, writer);

        var result = await sut.ExportAsync(document, format, "target-output");

        Assert.Same(rendered, result);
        Assert.Equal(format, resolver.RequestedFormat);
        Assert.Same(document, renderer.LastDocument);
        Assert.Same(rendered, writer.LastDocument);
        Assert.Equal("target-output", writer.OutputDirectory);
    }

    [Fact]
    public async Task ExportAsync_WhenRendererThrows_DoesNotCallWriter()
    {
        var document = new MarkdownDocument("Movie", "movie-render-fail", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());
        var expected = new InvalidOperationException("render failed");
        var renderer = new StubRenderer(ExportFormat.Obsidian, exception: expected);
        var writer = new RecordingWriter();
        var sut = new MarkdownExportService(new RecordingRendererResolver(renderer), writer);

        var actual = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            sut.ExportAsync(document, ExportFormat.Obsidian, "target-output"));

        Assert.Same(expected, actual);
        Assert.Null(writer.LastDocument);
        Assert.Null(writer.OutputDirectory);
    }

    [Fact]
    public async Task ExportAsync_WhenWriterFails_PropagatesOriginalExceptionAfterRendering()
    {
        var document = new MarkdownDocument("Movie", "movie-write-fail", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());
        var rendered = new RenderedDocument("Movies/movie-write-fail.md", "content");
        var expected = new IOException("disk unavailable");
        var renderer = new StubRenderer(ExportFormat.Obsidian, rendered);
        var writer = new RecordingWriter(expected);
        var sut = new MarkdownExportService(new RecordingRendererResolver(renderer), writer);

        var actual = await Assert.ThrowsAsync<IOException>(() =>
            sut.ExportAsync(document, ExportFormat.Obsidian, "target-output"));

        Assert.Same(expected, actual);
        Assert.Same(document, renderer.LastDocument);
        Assert.Same(rendered, writer.LastDocument);
        Assert.Equal("target-output", writer.OutputDirectory);
    }

    [Fact]
    public async Task ExportAsync_WhenWriterIsCancelled_PropagatesCancellationAndForwardsToken()
    {
        using var cancellation = new CancellationTokenSource();
        var token = cancellation.Token;
        var document = new MarkdownDocument("Movie", "movie-cancel", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());
        var rendered = new RenderedDocument("Movies/movie-cancel.md", "content");
        var writer = new RecordingWriter(new OperationCanceledException(token));
        var sut = new MarkdownExportService(
            new RecordingRendererResolver(new StubRenderer(ExportFormat.DokuWiki, rendered)), writer);

        var exception = await Assert.ThrowsAnyAsync<OperationCanceledException>(() =>
            sut.ExportAsync(document, ExportFormat.DokuWiki, "target-output", token));

        Assert.Equal(token, writer.CapturedToken);
        Assert.Equal(token, exception.CancellationToken);
        Assert.Same(rendered, writer.LastDocument);
    }

    [Fact]
    public async Task ExportAsync_WithNullDocument_ThrowsBeforeResolvingRenderer()
    {
        var resolver = new RecordingRendererResolver(new StubRenderer(ExportFormat.Obsidian, new("x.md", "x")));
        var writer = new RecordingWriter();
        var sut = new MarkdownExportService(resolver, writer);

        await Assert.ThrowsAsync<ArgumentNullException>(() =>
            sut.ExportAsync(null!, ExportFormat.Obsidian, "target-output"));

        Assert.Null(resolver.RequestedFormat);
        Assert.Null(writer.LastDocument);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ExportAsync_WithBlankOutputDirectory_ThrowsBeforeRendering(string outputDirectory)
    {
        var resolver = new RecordingRendererResolver(new StubRenderer(ExportFormat.Obsidian, new("x.md", "x")));
        var writer = new RecordingWriter();
        var sut = new MarkdownExportService(resolver, writer);
        var document = new MarkdownDocument("Movie", "movie-1", new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());

        await Assert.ThrowsAsync<ArgumentException>(() =>
            sut.ExportAsync(document, ExportFormat.Obsidian, outputDirectory));

        Assert.Null(resolver.RequestedFormat);
        Assert.Null(writer.LastDocument);
    }

    private sealed class RecordingRendererResolver(IMarkdownRenderer renderer) : IMarkdownRendererResolver
    {
        public ExportFormat? RequestedFormat { get; private set; }

        public IMarkdownRenderer Resolve(ExportFormat format)
        {
            RequestedFormat = format;
            return renderer;
        }
    }

    private sealed class StubRenderer(ExportFormat format, RenderedDocument? rendered = null, Exception? exception = null) : IMarkdownRenderer
    {
        public ExportFormat Format { get; } = format;
        public MarkdownDocument? LastDocument { get; private set; }

        public RenderedDocument Render(MarkdownDocument document)
        {
            LastDocument = document;
            if (exception is not null)
                throw exception;
            return rendered ?? new RenderedDocument("default.md", string.Empty);
        }
    }

    private sealed class RecordingWriter(Exception? exception = null) : IExportFileWriter
    {
        public RenderedDocument? LastDocument { get; private set; }
        public string? OutputDirectory { get; private set; }
        public CancellationToken CapturedToken { get; private set; }

        public Task WriteAsync(RenderedDocument document, string outputDirectory, CancellationToken ct = default)
        {
            LastDocument = document;
            OutputDirectory = outputDirectory;
            CapturedToken = ct;
            return exception is null ? Task.CompletedTask : Task.FromException(exception);
        }
    }
}
