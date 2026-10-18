using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Regression coverage for repeated references and deterministic relationship ordering.</summary>
public sealed class RelationshipMultiplicityAndDeterminismTests
{
    private static readonly LocalizedValueSelector Selector = new();

    [Fact]
    public void PersonBuilder_PreservesMultipleFamilyRelationshipsToSamePerson()
    {
        var rows = new[]
        {
            Row("Person_Family", "family-b", ("FamilyID", "person-related"), ("RelationshipID", "Sibling")),
            Row("Person_Family", "family-a", ("FamilyID", "person-related"), ("RelationshipID", "Parent")),
            Row("Person", "person-related", ("EnglishName", "Related Person"))
        };

        var document = new PersonDocumentBuilder(Selector).Build(Person(rows), ExportLanguage.English);
        var links = document.Blocks.OfType<LinkBlock>().Where(x => x.TargetType == "Person").ToArray();
        var relationships = document.Blocks.OfType<ParagraphBlock>().Where(x => x.Text.StartsWith("Relationship:", StringComparison.Ordinal)).ToArray();

        Assert.Equal(new[] { "person-related", "person-related" }, links.Select(x => x.TargetId));
        Assert.Equal(new[] { "Relationship: Parent", "Relationship: Sibling" }, relationships.Select(x => x.Text));
    }

    [Fact]
    public void PersonBuilder_ProducesSameRelationshipOrderWhenInputRowsAreReversed()
    {
        var rows = new[]
        {
            Row("Person_Employer", "employer-z", ("EmployerID", "employer-z")),
            Row("Person_Employer", "employer-a", ("EmployerID", "employer-a")),
            Row("Person_Employer", "employer-m", ("EmployerID", "employer-m"))
        };

        var forward = new PersonDocumentBuilder(Selector).Build(Person(rows), ExportLanguage.English);
        var reverse = new PersonDocumentBuilder(Selector).Build(Person(rows.Reverse().ToArray()), ExportLanguage.English);
        var forwardIds = forward.Blocks.OfType<LinkBlock>().Select(x => x.TargetId).ToArray();
        var reverseIds = reverse.Blocks.OfType<LinkBlock>().Select(x => x.TargetId).ToArray();

        Assert.Equal(new[] { "employer-a", "employer-m", "employer-z" }, forwardIds);
        Assert.Equal(forwardIds, reverseIds);
    }

    [Fact]
    public void ConnectionBuilder_PreservesRepeatedWorkReferencesAndOrdersThemByIdWhenTitlesMatch()
    {
        var data = new ConnectionExportData(
            "connection-1",
            new LocalizedValue("Universe", "Universe", "Universum"),
            null,
            null,
            Array.Empty<EntityReference>(),
            new[]
            {
                new WorkReference("Movie", "movie-z", new LocalizedValue("Shared", "Shared", "Gemeinsam")),
                new WorkReference("Movie", "movie-a", new LocalizedValue("Shared", "Shared", "Gemeinsam")),
                new WorkReference("Movie", "movie-a", new LocalizedValue("Shared", "Shared", "Gemeinsam"))
            },
            Array.Empty<ExportRowData>());

        var document = new ConnectionDocumentBuilder(Selector).Build(data, ExportLanguage.English);
        var links = document.Blocks.OfType<LinkBlock>().Where(x => x.TargetType == "Movie").ToArray();

        Assert.Equal(new[] { "movie-a", "movie-a", "movie-z" }, links.Select(x => x.TargetId));
        Assert.All(links, link => Assert.Equal("Shared", link.Text));
    }

    [Fact]
    public void SeriesBuilder_PreservesEpisodeReferencesWithSameTitleAndNumbersButDifferentIds()
    {
        var data = new SeriesExportData(
            "series-1",
            new LocalizedValue("Series", "Series", "Serie"),
            null,
            "1",
            "2",
            null,
            null,
            new[]
            {
                new EpisodeReference("episode-z", new LocalizedValue("Same", "Same", "Gleich"), "1", "1"),
                new EpisodeReference("episode-a", new LocalizedValue("Same", "Same", "Gleich"), "1", "1")
            },
            Array.Empty<ExportRowData>());

        var document = new SeriesDocumentBuilder(Selector).Build(data, ExportLanguage.English);
        var links = document.Blocks.OfType<LinkBlock>().Where(x => x.TargetType == "Episode").ToArray();

        Assert.Equal(new[] { "episode-a", "episode-z" }, links.Select(x => x.TargetId));
        Assert.Equal(new[] { "Same (1/1)", "Same (1/1)" }, links.Select(x => x.Text));
    }

    private static PersonExportData Person(IReadOnlyList<ExportRowData> rows) => new(
        "person-root", new LocalizedValue("Original", "English", "Deutsch"),
        null, null, null, null, null, null, null, null, null, rows);

    private static ExportRowData Row(string table, string id, params (string Key, string? Value)[] fields)
        => new(table, id,
            fields.ToDictionary(x => x.Key, x => x.Value, StringComparer.Ordinal),
            new Dictionary<string, string?>());
}
