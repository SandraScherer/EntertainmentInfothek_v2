using FluentAssertions;
using WikiExporter.Application.Documents;
using WikiExporter.Application.Models;
using WikiExporter.Markdown.Renderers;
using WikiExporter.Markdown.Rendering;
using Xunit;

public sealed class ObsidianRendererTests
{
    [Fact]
    public void Should_Render_Title()
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
    public void Should_Render_Table()
    {
        var renderer =
            new ObsidianBlockRenderer();

        var block =
            new TableBlock
            {
                Headers =
                {
                    "Feld",
                    "Wert"
                },
                Rows = new List<IList<string>>
                {
                    new List<string>
                    {
                        "Status",
                        "Aktiv"
                    }
                }
            };

        var result =
            renderer.Render(block);

        result.Should()
            .Contain("| Feld | Wert |");

        result.Should()
            .Contain("| Status | Aktiv |");
    }
}
