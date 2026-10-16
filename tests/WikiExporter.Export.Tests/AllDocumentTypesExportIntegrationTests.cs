using WikiExporter.Application.Documents.Models;

namespace WikiExporter.Export.Tests;

/// <summary>Checks all supported document types together through rendering and real file output.</summary>
public sealed class AllDocumentTypesExportIntegrationTests
{
    private static readonly (string Type, string Id, string Folder)[] Entities =
    [
        ("Movie", "movie-integration-1", "Movies"),
        ("Series", "series-integration-2", "Series"),
        ("Episode", "episode-integration-3", "Episodes"),
        ("Book", "book-integration-4", "Books"),
        ("VideoGame", "game-integration-5", "VideoGames"),
        ("Person", "person-integration-6", "Persons"),
        ("Connection", "connection-integration-7", "Connections")
    ];

    [Theory]
    [InlineData(ExportFormat.Obsidian)]
    [InlineData(ExportFormat.DokuWiki)]
    public async Task ExportService_ExportsAllSevenTypesWithLinksToExistingTargetFiles(ExportFormat format)
    {
        var root = Path.Combine(Path.GetTempPath(), "WikiExporterAllTypes", Guid.NewGuid().ToString("N"));
        try
        {
            var service = CreateService();
            var documents = Entities.ToDictionary(
                entity => entity.Type,
                entity => new MarkdownDocument(
                    entity.Type,
                    entity.Id,
                    new Dictionary<string, string?>
                    {
                        ["id"] = entity.Id,
                        ["title"] = $"Title for {entity.Type}"
                    },
                    new MarkdownBlock[] { new HeadingBlock(1, $"Title for {entity.Type}") }
                        .Concat(Entities.Where(target => target.Type != entity.Type)
                            .Select(target => (MarkdownBlock)new LinkBlock($"Title for {target.Type}", target.Type, target.Id)))
                        .ToArray()));

            var results = new Dictionary<string, RenderedDocument>();
            foreach (var entity in Entities)
                results.Add(entity.Type, await service.ExportAsync(documents[entity.Type], format, root));

            Assert.Equal(7, results.Count);
            foreach (var entity in Entities)
            {
                var result = results[entity.Type];
                Assert.StartsWith(entity.Folder + "/", result.RelativePath);
                Assert.EndsWith(".md", result.RelativePath);
                var fullPath = ToFullPath(root, result.RelativePath);
                Assert.True(File.Exists(fullPath), $"Expected exported file for {entity.Type} at {fullPath}.");
                Assert.Equal(result.Content, await File.ReadAllTextAsync(fullPath));
                Assert.Contains($"Title for {entity.Type}", result.Content);

                foreach (var target in Entities.Where(target => target.Type != entity.Type))
                {
                    var targetPath = results[target.Type].RelativePath;
                    var expectedTarget = format == ExportFormat.DokuWiki
                        ? targetPath.Replace('/', ':')[..^3]
                        : GetObsidianTarget(root, result.RelativePath, targetPath);
                    Assert.Contains($"[[{expectedTarget}|Title for {target.Type}]]", result.Content);
                    Assert.True(File.Exists(ToFullPath(root, targetPath)), $"Link target for {target.Type} must exist.");
                }
            }

            var markdownFiles = Directory.GetFiles(root, "*.md", SearchOption.AllDirectories);
            Assert.Equal(7, markdownFiles.Length);
        }
        finally
        {
            if (Directory.Exists(root)) Directory.Delete(root, recursive: true);
        }
    }

    private static MarkdownExportService CreateService()
    {
        var names = new ExportFileNameGenerator();
        var paths = new ExportPathResolver(names);
        var links = new ExportLinkResolver(paths);
        var obsidian = new ObsidianRenderer(paths, links);
        var dokuWiki = new DokuWikiRenderer(paths, links);
        var resolver = new MarkdownRendererResolver(dokuWiki, obsidian);
        return new MarkdownExportService(resolver, new FileSystemExportFileWriter());
    }

    private static string GetObsidianTarget(string root, string sourceRelativePath, string targetRelativePath)
    {
        var sourceDirectory = Path.GetDirectoryName(ToFullPath(root, sourceRelativePath))!;
        var targetFullPath = ToFullPath(root, targetRelativePath);
        return Path.GetRelativePath(sourceDirectory, targetFullPath)
            .Replace('\\', '/')
            .Replace(".md", string.Empty, StringComparison.OrdinalIgnoreCase);
    }

    private static string ToFullPath(string root, string relativePath)
        => Path.Combine(root, relativePath.Replace('/', Path.DirectorySeparatorChar));
}
