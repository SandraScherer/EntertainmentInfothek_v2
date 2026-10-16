using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Regression tests for hierarchy and direct references in connection documents.</summary>
public sealed class ConnectionDocumentBuilderRegressionTests
{
    private readonly ConnectionDocumentBuilder _sut = new(new LocalizedValueSelector());

    [Fact]
    public void Build_IncludesParentAndOnlyProvidedDirectChildrenInStableOrder()
    {
        var data = new ConnectionExportData(
            "universe-1",
            new LocalizedValue("Universe", "Universe EN", "Universum"),
            "parent-1",
            null,
            new[]
            {
                new EntityReference("child-z", "Zeta"),
                new EntityReference("child-b", "Beta"),
                new EntityReference("child-a", "Beta")
            },
            Array.Empty<WorkReference>(),
            Array.Empty<ExportRowData>());

        var document = _sut.Build(data, ExportLanguage.English);
        var links = document.Blocks.OfType<LinkBlock>().ToArray();

        Assert.Equal("Universe EN", Assert.IsType<HeadingBlock>(document.Blocks[0]).Text);
        Assert.Equal(new LinkBlock("parent-1", "Connection", "parent-1"), links[0]);
        Assert.Equal(new[] { "child-a", "child-b", "child-z" }, links.Skip(1).Select(x => x.TargetId));
        Assert.All(links, link => Assert.Equal("Connection", link.TargetType));
        Assert.DoesNotContain(links, link => link.TargetId.Contains("grandchild", StringComparison.Ordinal));
    }

    [Fact]
    public void Build_GroupsWorksByTypeAndOrdersEachGroupByLocalizedTitleThenId()
    {
        var data = new ConnectionExportData(
            "universe-2",
            new LocalizedValue("Universum", "Universe", null),
            null,
            "Public details",
            Array.Empty<EntityReference>(),
            new[]
            {
                new WorkReference("Movie", "movie-z", new LocalizedValue("Zeta", "Zulu", "Zeta DE")),
                new WorkReference("Book", "book-1", new LocalizedValue("Book", "Alpha", "Buch")),
                new WorkReference("Movie", "movie-b", new LocalizedValue("Beta", "Alpha", "Beta DE")),
                new WorkReference("Movie", "movie-a", new LocalizedValue("Alpha", "Alpha", "Alpha DE"))
            },
            Array.Empty<ExportRowData>());

        var document = _sut.Build(data, ExportLanguage.English);
        var links = document.Blocks.OfType<LinkBlock>().ToArray();
        var headings = document.Blocks.OfType<HeadingBlock>().Select(x => x.Text).ToArray();

        Assert.Equal(new[] { "Universe", "Book", "Movie", "Details" }, headings);
        Assert.Equal(new[] { "book-1", "movie-a", "movie-b", "movie-z" }, links.Select(x => x.TargetId));
        Assert.Equal(new[] { "Alpha", "Alpha", "Alpha", "Zulu" }, links.Select(x => x.Text));
        Assert.Contains(document.Blocks.OfType<ParagraphBlock>(), p => p.Text == "Public details");
    }

    [Fact]
    public void Build_UsesIdWhenChildDisplayNameIsMissingAndOmitsEmptyParentAndSections()
    {
        var data = new ConnectionExportData(
            "universe-3",
            new LocalizedValue("Minimal", null, null),
            " ",
            " ",
            new[] { new EntityReference("child-id") },
            Array.Empty<WorkReference>(),
            Array.Empty<ExportRowData>());

        var document = _sut.Build(data, ExportLanguage.Original);
        var link = Assert.Single(document.Blocks.OfType<LinkBlock>());

        Assert.Equal("child-id", link.Text);
        Assert.Equal("child-id", link.TargetId);
        Assert.DoesNotContain(document.Blocks.OfType<HeadingBlock>(), h => h.Text is "Parent Connection" or "Details" or "Movie" or "Book");
    }
}
