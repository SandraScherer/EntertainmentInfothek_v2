using FluentAssertions;
using WikiExporter.Application.Documents;
using WikiExporter.Application.Models;
using WikiExporter.Markdown.Renderers;
using WikiExporter.Markdown.Rendering;
using Xunit;

public sealed class DokuWikiRendererTests
{
    [Fact]
    public void Should_Render_Title()
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

        var markup =
            renderer.Render(document);

        markup.Should()
            .Contain(
                "====== The Matrix ======");
    }
}
