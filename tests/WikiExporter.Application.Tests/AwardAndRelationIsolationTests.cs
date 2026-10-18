using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Regression tests for relationship scoping and deterministic ordering.</summary>
public sealed class AwardAndRelationIsolationTests
{
    private static readonly ILocalizedValueSelector Selector = new LocalizedValueSelector();

    [Fact]
    public void MovieBuilder_AssignsAwardContributorsOnlyToTheirOwningAward()
    {
        var rows = new[]
        {
            Row("Movie_Award", "award-b", ("AwardID", "award-name-b"), ("Category", "Category B")),
            Row("Movie_Award", "award-a", ("AwardID", "award-name-a"), ("Category", "Category A")),
            Row("Award", "award-name-a", ("EnglishName", "Alpha Award")),
            Row("Award", "award-name-b", ("EnglishName", "Beta Award")),
            Row("Movie_Award_Person", "contrib-a", ("Movie_AwardID", "award-a"), ("PersonID", "person-a")),
            Row("Movie_Award_Person", "contrib-b", ("Movie_AwardID", "award-b"), ("PersonID", "person-b")),
            Row("Person", "person-a", ("EnglishName", "Person A")),
            Row("Person", "person-b", ("EnglishName", "Person B"))
        };

        var document = BuildMovie(rows);
        var blocks = document.Blocks;
        var alphaIndex = IndexOfHeading(blocks, 3, "Alpha Award");
        var betaIndex = IndexOfHeading(blocks, 3, "Beta Award");
        var personAIndex = IndexOfLink(blocks, "person-a");
        var personBIndex = IndexOfLink(blocks, "person-b");

        Assert.True(alphaIndex >= 0 && betaIndex >= 0);
        Assert.True(alphaIndex < personAIndex && personAIndex < betaIndex);
        Assert.True(betaIndex < personBIndex);
    }

    [Fact]
    public void MovieBuilder_OrdersAwardsByOrderThenStableId()
    {
        var rows = new[]
        {
            OrderedRow("Movie_Award", "award-z", "2", ("AwardID", "award-z-name")),
            OrderedRow("Movie_Award", "award-b", "1", ("AwardID", "award-b-name")),
            OrderedRow("Movie_Award", "award-a", "1", ("AwardID", "award-a-name")),
            Row("Award", "award-z-name", ("EnglishName", "Zeta")),
            Row("Award", "award-b-name", ("EnglishName", "Bravo")),
            Row("Award", "award-a-name", ("EnglishName", "Alpha"))
        };

        var headings = BuildMovie(rows).Blocks.OfType<HeadingBlock>()
            .Where(x => x.Level == 3).Select(x => x.Text).ToArray();

        Assert.Equal(new[] { "Alpha", "Bravo", "Zeta" }, headings);
    }

    [Fact]
    public void MovieBuilder_OrdersCompanyCreditsByOrderThenStableId()
    {
        var rows = new[]
        {
            OrderedRow("Movie_CompanyCredits", "credit-z", "2", ("CompanyID", "company-z")),
            OrderedRow("Movie_CompanyCredits", "credit-b", "1", ("CompanyID", "company-b")),
            OrderedRow("Movie_CompanyCredits", "credit-a", "1", ("CompanyID", "company-a")),
            Row("Company", "company-z", ("EnglishName", "Zeta Company")),
            Row("Company", "company-b", ("EnglishName", "Bravo Company")),
            Row("Company", "company-a", ("EnglishName", "Alpha Company"))
        };

        var links = BuildMovie(rows).Blocks.OfType<LinkBlock>()
            .Where(x => x.TargetType == "Company").Select(x => x.TargetId).ToArray();

        Assert.Equal(new[] { "company-a", "company-b", "company-z" }, links);
    }

    [Fact]
    public void PersonBuilder_OrdersFamilyReferencesByOrderThenStableId()
    {
        var rows = new[]
        {
            OrderedRow("Person_Family", "relation-z", "2", ("FamilyID", "person-z")),
            OrderedRow("Person_Family", "relation-b", "1", ("FamilyID", "person-b")),
            OrderedRow("Person_Family", "relation-a", "1", ("FamilyID", "person-a")),
            Row("Person", "person-z", ("EnglishName", "Zed")),
            Row("Person", "person-b", ("EnglishName", "Bee")),
            Row("Person", "person-a", ("EnglishName", "Aye"))
        };
        var person = new PersonExportData("person-root",
            new LocalizedValue("Root", "Root", "Root"), null, null, null, null, null,
            null, null, null, null, rows);

        var links = new PersonDocumentBuilder(Selector).Build(person, ExportLanguage.English)
            .Blocks.OfType<LinkBlock>().Where(x => x.TargetType == "Person")
            .Select(x => x.TargetId).ToArray();

        Assert.Equal(new[] { "person-a", "person-b", "person-z" }, links);
    }

    private static MarkdownDocument BuildMovie(IReadOnlyList<ExportRowData> rows)
    {
        var movie = new MovieExportData("movie-award-isolation",
            new LocalizedValue("Original Movie", "English Movie", "Deutscher Film"),
            null, null, null, null, null, null, rows);
        return new MovieDocumentBuilder(Selector).Build(movie, ExportLanguage.English);
    }

    private static int IndexOfHeading(IReadOnlyList<MarkdownBlock> blocks, int level, string text)
    {
        for (var i = 0; i < blocks.Count; i++)
            if (blocks[i] is HeadingBlock heading && heading.Level == level && heading.Text == text) return i;
        return -1;
    }

    private static int IndexOfLink(IReadOnlyList<MarkdownBlock> blocks, string targetId)
    {
        for (var i = 0; i < blocks.Count; i++)
            if (blocks[i] is LinkBlock link && link.TargetType == "Person" && link.TargetId == targetId) return i;
        return -1;
    }

    private static ExportRowData Row(string table, string id, params (string Key, string? Value)[] fields)
        => OrderedRow(table, id, null, fields);

    private static ExportRowData OrderedRow(string table, string id, string? order, params (string Key, string? Value)[] fields)
        => new(table, id,
            fields.ToDictionary(x => x.Key, x => x.Value, StringComparer.Ordinal),
            new Dictionary<string, string?>(), order);
}
