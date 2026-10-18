using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Regression tests for stable ordering and incomplete relationship rows.</summary>
public sealed class RelationshipOrderingRegressionTests
{
    private static readonly ILocalizedValueSelector Selector = new LocalizedValueSelector();

    [Fact]
    public void MovieBuilder_OrdersCastByExplicitOrderThenStableRowId()
    {
        var rows = new ExportRowData[]
        {
            OrderedRow("Movie_Cast", "cast-z", "2", ("ActorID", "person-z")),
            OrderedRow("Movie_Cast", "cast-b", "1", ("ActorID", "person-b")),
            OrderedRow("Movie_Cast", "cast-a", "1", ("ActorID", "person-a")),
            Row("Person", "person-z", ("EnglishName", "Zed")),
            Row("Person", "person-b", ("EnglishName", "Bee")),
            Row("Person", "person-a", ("EnglishName", "Aye"))
        };

        var document = BuildMovie(rows);
        var castLinks = document.Blocks.OfType<LinkBlock>().Where(x => x.TargetType == "Person").ToArray();

        Assert.Equal(new[] { "person-a", "person-b", "person-z" }, castLinks.Select(x => x.TargetId));
    }

    [Fact]
    public void MovieBuilder_OrdersCastByRowIdWhenOrderValuesAreEqualOrMissing()
    {
        var rows = new ExportRowData[]
        {
            OrderedRow("Movie_Cast", "cast-c", "1", ("ActorID", "person-c")),
            OrderedRow("Movie_Cast", "cast-b", "1", ("ActorID", "person-b")),
            Row("Movie_Cast", "cast-a", ("ActorID", "person-a")),
            Row("Person", "person-a", ("EnglishName", "A")),
            Row("Person", "person-b", ("EnglishName", "B")),
            Row("Person", "person-c", ("EnglishName", "C"))
        };

        var document = BuildMovie(rows);
        var castLinks = document.Blocks.OfType<LinkBlock>().Where(x => x.TargetType == "Person").ToArray();

        Assert.Equal(new[] { "person-a", "person-b", "person-c" }, castLinks.Select(x => x.TargetId));
    }

    [Fact]
    public void MovieBuilder_KeepsCharacterAndDubberReferencesWhenActorIsMissing()
    {
        var rows = new ExportRowData[]
        {
            Row("Movie_Cast", "cast-1", ("ActorID", " "), ("CharacterID", "character-1"),
                ("EnglishDubberID", "dubber-en"), ("GermanDubberID", "dubber-de")),
            Row("Person", "character-1", ("EnglishName", "Character")),
            Row("Person", "dubber-en", ("EnglishName", "English Dubber")),
            Row("Person", "dubber-de", ("EnglishName", "German Dubber"))
        };

        var document = BuildMovie(rows);
        var links = document.Blocks.OfType<LinkBlock>().Where(x => x.TargetType == "Person").ToArray();

        Assert.Equal(new[] { "character-1", "dubber-en", "dubber-de" }, links.Select(x => x.TargetId));
        Assert.Contains(links, x => x.Text == "Character: Character");
        Assert.Contains(links, x => x.Text == "English dubber: English Dubber");
        Assert.Contains(links, x => x.Text == "German dubber: German Dubber");
    }

    [Fact]
    public void MovieBuilder_DoesNotEmitCastSectionForRowsWithoutAnyUsableRelationshipOrRole()
    {
        var rows = new[]
        {
            Row("Movie_Cast", "cast-1", ("ActorID", " "), ("CharacterID", null),
                ("EnglishDubberID", ""), ("GermanDubberID", "\t"), ("EnglishRole", " "), ("GermanRole", "\t"))
        };

        var document = BuildMovie(rows);

        Assert.DoesNotContain(document.Blocks.OfType<HeadingBlock>(), x => x.Text == "Cast");
        Assert.DoesNotContain(document.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Person");
    }

    private static MarkdownDocument BuildMovie(IReadOnlyList<ExportRowData> rows)
    {
        var data = new MovieExportData("movie-ordering-1",
            new LocalizedValue("Original Movie", "English Movie", "Deutscher Film"),
            null, null, null, null, null, null, rows);
        return new MovieDocumentBuilder(Selector).Build(data, ExportLanguage.English);
    }

    private static ExportRowData Row(string table, string id, params (string Key, string? Value)[] fields)
        => OrderedRow(table, id, null, fields);

    private static ExportRowData OrderedRow(string table, string id, string? order, params (string Key, string? Value)[] fields)
        => new(table, id,
            fields.ToDictionary(x => x.Key, x => x.Value, StringComparer.Ordinal),
            new Dictionary<string, string?>(), order);
}
