using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Regression tests for relationship references emitted by series and connection builders.</summary>
public sealed class ConnectionAndSeriesBuilderRegressionTests
{
    private static readonly ILocalizedValueSelector Selector = new LocalizedValueSelector();
    private static readonly IReadOnlyList<ExportRowData> NoRows = Array.Empty<ExportRowData>();

    [Fact]
    public void ConnectionBuilder_EmitsParentChildrenAndWorksAsSortedReferences()
    {
        var data = new ConnectionExportData(
            "connection-1",
            new LocalizedValue("Universe", "Universe EN", "Universum DE"),
            "parent-1",
            null,
            new[]
            {
                new EntityReference("child-b", "Beta"),
                new EntityReference("child-c", null),
                new EntityReference("child-a", "Alpha")
            },
            new[]
            {
                new WorkReference("Movie", "movie-1", new LocalizedValue("Film", "Movie Z", "Film Z")),
                new WorkReference("Book", "book-1", new LocalizedValue("Buch", "Book A", "Buch A")),
                new WorkReference("Movie", "movie-2", new LocalizedValue("Film", "Movie A", "Film A"))
            },
            NoRows);

        var document = new ConnectionDocumentBuilder(Selector).Build(data, ExportLanguage.English);
        var links = document.Blocks.OfType<LinkBlock>().ToArray();

        Assert.Equal("Universe EN", Assert.IsType<HeadingBlock>(document.Blocks[0]).Text);
        Assert.Collection(links,
            link => Assert.Equal(("Connection", "parent-1", "parent-1"), (link.TargetType, link.TargetId, link.Text)),
            link => Assert.Equal(("Connection", "child-a", "Alpha"), (link.TargetType, link.TargetId, link.Text)),
            link => Assert.Equal(("Connection", "child-b", "Beta"), (link.TargetType, link.TargetId, link.Text)),
            link => Assert.Equal(("Connection", "child-c", "child-c"), (link.TargetType, link.TargetId, link.Text)),
            link => Assert.Equal(("Book", "book-1", "Book A"), (link.TargetType, link.TargetId, link.Text)),
            link => Assert.Equal(("Movie", "movie-2", "Movie A"), (link.TargetType, link.TargetId, link.Text)),
            link => Assert.Equal(("Movie", "movie-1", "Movie Z"), (link.TargetType, link.TargetId, link.Text)));

    }

    [Fact]
    public void SeriesBuilder_OrdersEpisodesBySeasonThenEpisodeAndKeepsThemAsLinks()
    {
        var data = new SeriesExportData(
            "series-1",
            new LocalizedValue("Original Series", "English Series", "Deutsche Serie"),
            null,
            "2",
            "3",
            null,
            null,
            new[]
            {
                new EpisodeReference("e-3", new LocalizedValue("Episode Three", "Episode Three EN", "Folge Drei"), "2", "1"),
                new EpisodeReference("e-2", new LocalizedValue("Episode Two", "Episode Two EN", "Folge Zwei"), "1", "2"),
                new EpisodeReference("e-1", new LocalizedValue("Episode One", "Episode One EN", "Folge Eins"), "1", "1")
            },
            NoRows);

        var document = new SeriesDocumentBuilder(Selector).Build(data, ExportLanguage.German);
        var episodeLinks = document.Blocks.OfType<LinkBlock>().Where(link => link.TargetType == "Episode").ToArray();

        Assert.Equal(new[] { "e-1", "e-2", "e-3" }, episodeLinks.Select(link => link.TargetId));
        Assert.Equal(new[] { "Folge Eins (1/1)", "Folge Zwei (1/2)", "Folge Drei (2/1)" }, episodeLinks.Select(link => link.Text));
        Assert.All(episodeLinks, link => Assert.Equal("Episode", link.TargetType));
    }
}
