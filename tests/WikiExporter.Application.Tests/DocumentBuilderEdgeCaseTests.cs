using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Checks document-builder behavior for missing and incomplete optional data.</summary>
public sealed class DocumentBuilderEdgeCaseTests
{
    private static readonly ILocalizedValueSelector Selector = new LocalizedValueSelector();
    private static readonly IReadOnlyList<ExportRowData> NoRows = Array.Empty<ExportRowData>();

    [Fact]
    public void AllBuilders_UseUntitledWhenEveryTitleVariantIsMissing()
    {
        var emptyTitle = new LocalizedValue(null, " ", null);
        var documents = new MarkdownDocument[]
        {
            new MovieDocumentBuilder(Selector).Build(new MovieExportData("m1", emptyTitle, null, null, null, null, null, null, NoRows), ExportLanguage.German),
            new SeriesDocumentBuilder(Selector).Build(new SeriesExportData("s1", emptyTitle, null, null, null, null, null, Array.Empty<EpisodeReference>(), NoRows), ExportLanguage.German),
            new EpisodeDocumentBuilder(Selector).Build(new EpisodeExportData("e1", emptyTitle, null, null, null, null, NoRows), ExportLanguage.German),
            new BookDocumentBuilder(Selector).Build(new BookExportData("b1", emptyTitle, null, null, null, NoRows), ExportLanguage.German),
            new VideoGameDocumentBuilder(Selector).Build(new VideoGameExportData("v1", emptyTitle, null, null, null, null, null, null, NoRows), ExportLanguage.German),
            new PersonDocumentBuilder(Selector).Build(new PersonExportData("p1", emptyTitle, null, null, null, null, null, null, null, null, null, NoRows), ExportLanguage.German),
            new ConnectionDocumentBuilder(Selector).Build(new ConnectionExportData("c1", emptyTitle, null, null, Array.Empty<EntityReference>(), Array.Empty<WorkReference>(), NoRows), ExportLanguage.German)
        };

        Assert.All(documents, document =>
        {
            Assert.Equal("Untitled", Assert.IsType<HeadingBlock>(document.Blocks[0]).Text);
            Assert.Equal("Untitled", document.Metadata["title"]);
            Assert.DoesNotContain(document.Blocks.OfType<HeadingBlock>(), heading => heading.Text == "Details");
        });
    }

    [Fact]
    public void MovieBuilder_UsesOriginalTitleWhenRequestedLanguageIsBlank()
    {
        var data = new MovieExportData("m1", new LocalizedValue("Original Name", null, " "), null, null, null, null, null, null, NoRows);

        var document = new MovieDocumentBuilder(Selector).Build(data, ExportLanguage.German);

        Assert.Equal("Original Name", Assert.IsType<HeadingBlock>(document.Blocks[0]).Text);
        Assert.Equal("Original Name", document.Metadata["title"]);
    }

    [Fact]
    public void MovieBuilder_UsesMissingConnectionIdAsReferenceLabel()
    {
        var data = new MovieExportData("m1", new LocalizedValue("Movie", null, null), null, null, null, null, "connection-missing", null, NoRows);

        var document = new MovieDocumentBuilder(Selector).Build(data, ExportLanguage.English);

        var link = Assert.Single(document.Blocks.OfType<LinkBlock>());
        Assert.Equal("connection-missing", link.Text);
        Assert.Equal("Connection", link.TargetType);
        Assert.Equal("connection-missing", link.TargetId);
    }

    [Fact]
    public void BookBuilder_IncludesOnlyPublicationTextRowsLinkedToAnIncludedPublication()
    {
        var rows = new ExportRowData[]
        {
            Row("Publication", "pub1", fields: new Dictionary<string, string?> { ["EnglishTitle"] = "First edition" }),
            Row("Text", "text1", fields: new Dictionary<string, string?> { ["Content"] = "Publication text that belongs here" }),
            Row("Text", "text2", fields: new Dictionary<string, string?> { ["Content"] = "Orphan publication text" }),
            Row("Publication_Text", "pt1", foreignKeys: new Dictionary<string, string?> { ["PublicationID"] = "pub1", ["TextID"] = "text1" }),
            Row("Publication_Text", "pt2", foreignKeys: new Dictionary<string, string?> { ["PublicationID"] = "missing-publication", ["TextID"] = "text2" })
        };
        var data = new BookExportData("b1", new LocalizedValue("Book", null, null), null, null, null, rows);

        var document = new BookDocumentBuilder(Selector).Build(data, ExportLanguage.English);
        var paragraphs = document.Blocks.OfType<ParagraphBlock>().Select(x => x.Text).ToArray();

        Assert.Contains("Publication text that belongs here", paragraphs);
        Assert.DoesNotContain("Orphan publication text", paragraphs);
        Assert.Contains(document.Blocks.OfType<HeadingBlock>(), heading => heading.Text == "First edition");
    }

    [Fact]
    public void VideoGameBuilder_IgnoresTechnicalSpecificationChildrenForAnotherSpecification()
    {
        var rows = new ExportRowData[]
        {
            Row("TechnicalSpecification", "spec1", fields: new Dictionary<string, string?> { ["EnglishAnnotation"] = "Primary specification" }),
            Row("TechnicalSpecification_Feature", "feature1", foreignKeys: new Dictionary<string, string?> { ["TechnicalSpecificationID"] = "spec1", ["FeatureID"] = "feature-kept" }),
            Row("TechnicalSpecification_Feature", "feature2", foreignKeys: new Dictionary<string, string?> { ["TechnicalSpecificationID"] = "other-spec", ["FeatureID"] = "feature-must-not-leak" })
        };
        var data = new VideoGameExportData("v1", new LocalizedValue("Game", null, null), null, null, null, null, null, null, rows);

        var document = new VideoGameDocumentBuilder(Selector).Build(data, ExportLanguage.English);
        var featureLists = document.Blocks.OfType<ListBlock>().ToArray();

        var featureList = Assert.Single(featureLists);
        Assert.Contains("feature-kept", featureList.Items);
        Assert.DoesNotContain("feature-must-not-leak", featureList.Items);
    }

    private static ExportRowData Row(
        string table,
        string id,
        IReadOnlyDictionary<string, string?>? fields = null,
        IReadOnlyDictionary<string, string?>? foreignKeys = null)
        => new(table, id, fields ?? new Dictionary<string, string?>(), foreignKeys ?? new Dictionary<string, string?>());
}
