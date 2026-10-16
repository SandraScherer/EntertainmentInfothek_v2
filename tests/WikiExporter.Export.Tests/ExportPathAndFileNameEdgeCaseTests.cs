using System.Security.Cryptography;
using System.Text;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.FileNames;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Tests;

/// <summary>Checks stable file naming and path resolution for edge cases.</summary>
public sealed class ExportPathAndFileNameEdgeCaseTests
{
    [Theory]
    [InlineData("Movie", "Movies")]
    [InlineData("Series", "Series")]
    [InlineData("Episode", "Episodes")]
    [InlineData("Book", "Books")]
    [InlineData("VideoGame", "VideoGames")]
    [InlineData("Person", "Persons")]
    [InlineData("Connection", "Connections")]
    [InlineData("UnknownType", "Other")]
    public void PathResolver_UsesExpectedFolderForDocumentType(string type, string folder)
    {
        var resolver = new ExportPathResolver(new ExportFileNameGenerator());
        var document = CreateDocument(type, "id-1");

        Assert.Equal(folder, resolver.GetDirectory(document, ExportFormat.Obsidian));
        Assert.Equal(folder, resolver.GetDirectory(document, ExportFormat.DokuWiki));
    }

    [Fact]
    public void FileNameGenerator_IsStableAcrossMetadataAndBlockChanges()
    {
        var generator = new ExportFileNameGenerator();
        var first = new MarkdownDocument("Movie", "same-id", new Dictionary<string, string?> { ["title"] = "First" }, Array.Empty<MarkdownBlock>());
        var second = new MarkdownDocument("Movie", "same-id", new Dictionary<string, string?> { ["title"] = "Changed" }, new MarkdownBlock[] { new ParagraphBlock("body") });

        Assert.Equal(generator.Generate(first), generator.Generate(second));
    }

    [Fact]
    public void FileNameGenerator_ChangesWhenEntityIdChanges()
    {
        var generator = new ExportFileNameGenerator();

        Assert.NotEqual(generator.Generate(CreateDocument("Movie", "id-a")), generator.Generate(CreateDocument("Movie", "id-b")));
    }

    [Fact]
    public void FileNameGenerator_SanitizesDocumentTypeAndRetainsStableIdHash()
    {
        const string id = "movie/with:path";
        var document = CreateDocument("../Movie:Special", id);
        var actual = new ExportFileNameGenerator().Generate(document);
        var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(id))).ToLowerInvariant()[..8];

        Assert.Equal($"_Movie_Special-{hash}.md", actual);
        Assert.DoesNotContain('/', actual);
        Assert.DoesNotContain('\\', actual);
        Assert.DoesNotContain(':', actual);
    }

    [Fact]
    public void PathResolver_UsesForwardSlashesInRelativePaths()
    {
        var resolver = new ExportPathResolver(new ExportFileNameGenerator());
        var document = CreateDocument("VideoGame", "game-1");

        var path = resolver.GetRelativePath(document, ExportFormat.Obsidian);

        Assert.StartsWith("VideoGames/", path);
        Assert.EndsWith(".md", path);
        Assert.DoesNotContain('\\', path);
    }

    private static MarkdownDocument CreateDocument(string type, string id) =>
        new(type, id, new Dictionary<string, string?>(), Array.Empty<MarkdownBlock>());
}
