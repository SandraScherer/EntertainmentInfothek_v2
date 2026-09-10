using FluentAssertions;

using WikiExporter.Application.Documents;
using WikiExporter.Application.Models;

using WikiExporter.Markdown.Rendering;
using WikiExporter.Markdown.Renderers;

using Xunit;

public sealed class RenderIntegrationTests
{
    [Fact]
    public void Should_Render_Obsidian()
    {
        var renderer =
            new ObsidianRenderer(
                new ObsidianBlockRenderer());

        var document =
            new ExportDocument
            {
                Id = "1",
                Title = "The Matrix",
                Slug = "the-matrix",
                Language = "de",
                EntityType =
                    ExportEntityType.Movie,
                Metadata =
                    new ExportMetadata()
            };

        var markdown =
            renderer.Render(document);

        markdown.Should()
            .Contain("# The Matrix");
    }

    [Fact]
    public void Should_Render_DokuWiki()
    {
        var renderer =
            new DokuWikiRenderer(
                new DokuWikiBlockRenderer());

        var document =
            new ExportDocument
            {
                Id = "1",
                Title = "The Matrix",
                Slug = "the-matrix",
                Language = "de",
                EntityType =
                    ExportEntityType.Movie,
                Metadata =
                    new ExportMetadata()
            };

        var markdown =
            renderer.Render(document);

        markdown.Should()
            .Contain(
                "====== The Matrix ======");
    }
}
