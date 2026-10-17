using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Additional regression tests for stable series/episode references and optional episode data.</summary>
public sealed class SeriesEpisodeRelationshipEdgeCaseTests
{
    private static readonly ILocalizedValueSelector Selector = new LocalizedValueSelector();
    private static readonly IReadOnlyList<ExportRowData> NoRows = Array.Empty<ExportRowData>();

    [Fact]
    public void SeriesBuilder_UsesIdAsTieBreakerForEpisodesWithSameSeasonAndEpisodeNumber()
    {
        var data = new SeriesExportData(
            "series-1",
            new LocalizedValue("Series", "Series EN", "Serie DE"),
            null,
            "1",
            "2",
            null,
            null,
            new[]
            {
                new EpisodeReference("episode-z", new LocalizedValue("Zulu", "Zulu", "Zulu"), "1", "1"),
                new EpisodeReference("episode-a", new LocalizedValue("Alpha", "Alpha", "Alpha"), "1", "1"),
                new EpisodeReference("episode-b", new LocalizedValue("Beta", "Beta", "Beta"), "1", "2")
            },
            NoRows);

        var document = new SeriesDocumentBuilder(Selector).Build(data, ExportLanguage.English);
        var episodeLinks = document.Blocks.OfType<LinkBlock>().Where(link => link.TargetType == "Episode").ToArray();

        Assert.Equal(new[] { "episode-a", "episode-z", "episode-b" }, episodeLinks.Select(link => link.TargetId));
        Assert.Equal(new[] { "Alpha (1/1)", "Zulu (1/1)", "Beta (1/2)" }, episodeLinks.Select(link => link.Text));
        Assert.Equal(3, episodeLinks.Length);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void EpisodeBuilder_OmitsSeriesReferenceWhenSeriesIdIsMissingOrBlank(string? seriesId)
    {
        var data = new EpisodeExportData(
            "episode-1",
            new LocalizedValue("Original Episode", "Episode EN", "Folge DE"),
            seriesId,
            "1",
            "2",
            "Episode details",
            NoRows);

        var document = new EpisodeDocumentBuilder(Selector).Build(data, ExportLanguage.English);

        Assert.DoesNotContain(document.Blocks.OfType<LinkBlock>(), link => link.TargetType == "Series");
        Assert.DoesNotContain(document.Blocks.OfType<HeadingBlock>(), heading => heading.Text == "Series");
        Assert.Contains(document.Blocks.OfType<ParagraphBlock>(), paragraph => paragraph.Text == "Episode details");
        Assert.Equal("Episode EN", Assert.IsType<HeadingBlock>(document.Blocks[0]).Text);
    }

    [Fact]
    public void EpisodeBuilder_UsesSeriesIdAsLinkLabelWhenRelatedSeriesIsUnavailable()
    {
        var data = new EpisodeExportData(
            "episode-2",
            new LocalizedValue("Episode", "Episode EN", "Folge DE"),
            "series-missing",
            null,
            null,
            null,
            NoRows);

        var document = new EpisodeDocumentBuilder(Selector).Build(data, ExportLanguage.English);
        var seriesLink = Assert.Single(document.Blocks.OfType<LinkBlock>().Where(link => link.TargetType == "Series"));

        Assert.Equal("series-missing", seriesLink.TargetId);
        Assert.Equal("series-missing", seriesLink.Text);
        Assert.DoesNotContain(document.Blocks.OfType<TableBlock>().SelectMany(table => table.Rows), row => row.Contains("Season") || row.Contains("Episode"));
    }
}
