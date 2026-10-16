using System.Security.Cryptography;
using System.Text;
using WikiExporter.Export.Links;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Tests;

/// <summary>Exercises link naming and relative-folder rules across the complete export type matrix.</summary>
public sealed class CrossEntityLinkMatrixTests
{
    private static readonly (string Type, string Folder)[] EntityTypes =
    {
        ("Movie", "Movies"),
        ("Series", "Series"),
        ("Episode", "Episodes"),
        ("Book", "Books"),
        ("VideoGame", "VideoGames"),
        ("Person", "Persons"),
        ("Connection", "Connections")
    };

    [Fact]
    public void LinkResolver_UsesCorrectStableNamespaceForEverySourceAndTargetType()
    {
        var resolver = new ExportLinkResolver(new ExportPathResolver(new ExportFileNameGenerator()));
        const string targetId = "target-Ä-人物-🎬";

        foreach (var source in EntityTypes)
        {
            var sourceDocument = Document(source.Type, "source-id");
            foreach (var target in EntityTypes)
            {
                var targetStem = StableStem(target.Type, targetId);
                var expectedObsidian = source.Folder == target.Folder
                    ? targetStem
                    : $"../{target.Folder}/{targetStem}";
                var obsidian = resolver.Resolve(sourceDocument, target.Type, targetId, ExportFormat.Obsidian);
                var dokuWiki = resolver.Resolve(sourceDocument, target.Type, targetId, ExportFormat.DokuWiki);

                Assert.Equal(expectedObsidian, obsidian);
                Assert.Equal($"{target.Folder}:{targetStem}", dokuWiki);
                Assert.DoesNotContain(".md", obsidian, StringComparison.OrdinalIgnoreCase);
                Assert.DoesNotContain(".md", dokuWiki, StringComparison.OrdinalIgnoreCase);
                Assert.DoesNotContain('\\', obsidian);
                Assert.DoesNotContain('/', dokuWiki);
            }
        }

    }

    [Fact]
    public void LinkResolver_UsesTargetTypeAndIdButNeverTargetTitleForStableNames()
    {
        var resolver = new ExportLinkResolver(new ExportPathResolver(new ExportFileNameGenerator()));
        var source = Document("Movie", "movie-source");

        var first = resolver.Resolve(source, "Person", "person-1", ExportFormat.Obsidian);
        var sameIdDifferentSourceMetadata = resolver.Resolve(
            new MarkdownDocument("Movie", "movie-source", new Dictionary<string, string?> { ["title"] = "Renamed movie" }, Array.Empty<MarkdownBlock>()),
            "Person", "person-1", ExportFormat.Obsidian);
        var differentId = resolver.Resolve(source, "Person", "person-2", ExportFormat.Obsidian);
        var differentType = resolver.Resolve(source, "Connection", "person-1", ExportFormat.Obsidian);

        Assert.Equal(first, sameIdDifferentSourceMetadata);
        Assert.NotEqual(first, differentId);
        Assert.NotEqual(first, differentType);
    }

    private static MarkdownDocument Document(string type, string id) =>
        new(type, id, new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());

    private static string StableStem(string type, string id)
    {
        var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(id))).ToLowerInvariant()[..8];
        return $"{type}-{hash}";
    }
}
