using System.Security.Cryptography;
using System.Text;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.FileNames;
using WikiExporter.Export.Links;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Tests;

/// <summary>Checks stable and format-specific links between exported documents.</summary>
public sealed class ExportLinkResolverTests
{
    private static MarkdownDocument Source(string type = "Movie", string id = "source") =>
        new(type, id, new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());

    [Fact]
    public void ObsidianLink_UsesRelativePathAcrossEntityFoldersAndStableTargetId()
    {
        var resolver = CreateResolver();
        var expectedFile = StableFileName("Person", "person-42");

        var first = resolver.Resolve(Source(), "Person", "person-42", ExportFormat.Obsidian);
        var second = resolver.Resolve(Source(), "Person", "person-42", ExportFormat.Obsidian);

        Assert.Equal($"../Persons/{Path.GetFileNameWithoutExtension(expectedFile)}", first);
        Assert.Equal(first, second);
        Assert.DoesNotContain(".md", first, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void ObsidianLink_ToSameFolderDoesNotAddUnnecessaryParentTraversal()
    {
        var resolver = CreateResolver();

        var link = resolver.Resolve(Source("Movie"), "Movie", "movie-target", ExportFormat.Obsidian);

        Assert.Equal(Path.GetFileNameWithoutExtension(StableFileName("Movie", "movie-target")), link);
        Assert.DoesNotContain("../", link);
    }

    [Fact]
    public void DokuWikiLink_UsesColonNamespacesAndStableIdBasedNames()
    {
        var resolver = CreateResolver();

        var link = resolver.Resolve(Source(), "Person", "person-42", ExportFormat.DokuWiki);

        Assert.Equal($"Persons:{Path.GetFileNameWithoutExtension(StableFileName("Person", "person-42"))}", link);
        Assert.DoesNotContain("/", link);
        Assert.DoesNotContain(".md", link, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void LinkToUnknownEntityTypeUsesOtherFolder()
    {
        var resolver = CreateResolver();

        var link = resolver.Resolve(Source(), "FutureType", "future-1", ExportFormat.Obsidian);

        Assert.StartsWith("../Other/FutureType-", link);
    }

    [Fact]
    public void LinksWithPathLikeEntityIdsRemainInsideStableTargetNamespace()
    {
        var resolver = CreateResolver();
        const string hostileId = "../../escape\\nested\u2603";
        var expectedName = Path.GetFileNameWithoutExtension(StableFileName("Person", hostileId));

        var obsidian = resolver.Resolve(Source(), "Person", hostileId, ExportFormat.Obsidian);
        var dokuWiki = resolver.Resolve(Source(), "Person", hostileId, ExportFormat.DokuWiki);

        Assert.Equal($"../Persons/{expectedName}", obsidian);
        Assert.Equal($"Persons:{expectedName}", dokuWiki);
        Assert.DoesNotContain("escape", obsidian, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("\\", obsidian);
        Assert.DoesNotContain("/../", obsidian);
        Assert.DoesNotContain("/", dokuWiki);
    }

    [Fact]
    public void StableTargetNameSupportsUnicodeAndEmptyEntityIds()
    {
        var resolver = CreateResolver();
        var unicodeLink = resolver.Resolve(Source(), "Person", "人物-Äda-🎬", ExportFormat.DokuWiki);
        var emptyIdLink = resolver.Resolve(Source(), "Person", string.Empty, ExportFormat.DokuWiki);

        Assert.Equal($"Persons:{Path.GetFileNameWithoutExtension(StableFileName("Person", "人物-Äda-🎬"))}", unicodeLink);
        Assert.Equal($"Persons:{Path.GetFileNameWithoutExtension(StableFileName("Person", string.Empty))}", emptyIdLink);
        Assert.DoesNotContain("人物", unicodeLink);
        Assert.DoesNotContain("/", emptyIdLink);
    }

    private static ExportLinkResolver CreateResolver() =>
        new(new ExportPathResolver(new ExportFileNameGenerator()));

    private static string StableFileName(string type, string id)
    {
        var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(id))).ToLowerInvariant()[..8];
        return $"{type}-{hash}.md";
    }
}
