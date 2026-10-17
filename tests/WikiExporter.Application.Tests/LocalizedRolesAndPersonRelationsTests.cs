using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Regression tests for localized role labels and person relationship sections.</summary>
public sealed class LocalizedRolesAndPersonRelationsTests
{
    private static readonly ILocalizedValueSelector Selector = new LocalizedValueSelector();

    [Theory]
    [InlineData(ExportLanguage.English, "English Role")]
    [InlineData(ExportLanguage.German, "Deutsche Rolle")]
    [InlineData(ExportLanguage.Original, "English Role")]
    public void MovieBuilder_UsesLocalizedCastRole(ExportLanguage language, string expectedRole)
    {
        var cast = new ExportRowData(
            "Movie_Cast",
            "cast-1",
            new Dictionary<string, string?>
            {
                ["EnglishRole"] = "English Role",
                ["GermanRole"] = "Deutsche Rolle"
            },
            new Dictionary<string, string?>());
        var movie = Movie(cast);

        var document = new MovieDocumentBuilder(Selector).Build(movie, language);

        Assert.Contains(document.Blocks.OfType<ParagraphBlock>(), block => block.Text == expectedRole);
    }

    [Fact]
    public void MovieBuilder_OmitsCastRoleWhenBothTranslationsAreBlank()
    {
        var cast = new ExportRowData(
            "Movie_Cast",
            "cast-1",
            new Dictionary<string, string?>
            {
                ["EnglishRole"] = " ",
                ["GermanRole"] = "\t"
            },
            new Dictionary<string, string?>());

        var document = new MovieDocumentBuilder(Selector).Build(Movie(cast), ExportLanguage.English);

        Assert.DoesNotContain(document.Blocks.OfType<ParagraphBlock>(), block =>
            block.Text.Contains("Role", StringComparison.Ordinal) || block.Text.Contains("Rolle", StringComparison.Ordinal));
    }

    [Theory]
    [InlineData(ExportLanguage.English, "English Relationship Role")]
    [InlineData(ExportLanguage.German, "Deutsche Beziehungsrolle")]
    public void PersonBuilder_UsesLocalizedFamilyRelationshipRole(ExportLanguage language, string expectedRole)
    {
        var relation = new ExportRowData(
            "Person_Family",
            "family-link-1",
            new Dictionary<string, string?>
            {
                ["FamilyID"] = "family-person-1",
                ["RelationshipID"] = "Parent",
                ["EnglishRole"] = "English Relationship Role",
                ["GermanRole"] = "Deutsche Beziehungsrolle"
            },
            new Dictionary<string, string?>());
        var relatedPerson = new ExportRowData(
            "Person",
            "family-person-1",
            new Dictionary<string, string?>
            {
                ["EnglishName"] = "English Family Member",
                ["GermanName"] = "Deutsches Familienmitglied"
            },
            new Dictionary<string, string?>());

        var document = new PersonDocumentBuilder(Selector).Build(Person(relation, relatedPerson), language);
        var link = Assert.Single(document.Blocks.OfType<LinkBlock>().Where(x => x.TargetId == "family-person-1"));

        Assert.Equal("Person", link.TargetType);
        Assert.Contains(document.Blocks.OfType<ParagraphBlock>(), block => block.Text == "Relationship: Parent");
        Assert.Contains(document.Blocks.OfType<ParagraphBlock>(), block => block.Text == expectedRole);
    }

    [Theory]
    [InlineData(ExportLanguage.English, "Original Relationship Role")]
    [InlineData(ExportLanguage.German, "Deutsche Beziehungsrolle")]
    public void PersonBuilder_FallsBackWhenRequestedRelationshipRoleIsBlank(ExportLanguage language, string expectedRole)
    {
        var relation = new ExportRowData(
            "Person_Family",
            "family-link-2",
            new Dictionary<string, string?>
            {
                ["FamilyID"] = "family-person-2",
                ["RelationshipID"] = "Sibling",
                ["OriginalName"] = "Original Relationship Role",
                ["EnglishRole"] = " ",
                ["GermanRole"] = "Deutsche Beziehungsrolle"
            },
            new Dictionary<string, string?>());

        var document = new PersonDocumentBuilder(Selector).Build(Person(relation), language);

        Assert.Contains(document.Blocks.OfType<ParagraphBlock>(), block => block.Text == expectedRole);
    }

    [Theory]
    [InlineData(ExportLanguage.English, "English cause")]
    [InlineData(ExportLanguage.German, "Deutsche Ursache")]
    [InlineData(ExportLanguage.Original, "English cause")]
    public void PersonBuilder_UsesLanguageSpecificCauseOfDeath(ExportLanguage language, string expectedCause)
    {
        var person = new PersonExportData(
            "person-cause-1",
            new LocalizedValue("Original Name", "English Name", "Deutscher Name"),
            null, null, null,
            "English cause",
            "Deutsche Ursache",
            null, null, null, null,
            Array.Empty<ExportRowData>());

        var document = new PersonDocumentBuilder(Selector).Build(person, language);

        Assert.Contains(document.Blocks.OfType<HeadingBlock>(), block => block.Text == "Cause of Death");
        Assert.Contains(document.Blocks.OfType<ParagraphBlock>(), block => block.Text == expectedCause);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData(" ", "\t")]
    public void PersonBuilder_OmitsCauseOfDeathSectionWhenBothTranslationsAreBlank(string? englishCause, string? germanCause)
    {
        var person = new PersonExportData(
            "person-cause-2",
            new LocalizedValue("Name", "Name EN", "Name DE"),
            null, null, null,
            englishCause,
            germanCause,
            null, null, null, null,
            Array.Empty<ExportRowData>());

        var document = new PersonDocumentBuilder(Selector).Build(person, ExportLanguage.English);

        Assert.DoesNotContain(document.Blocks.OfType<HeadingBlock>(), block => block.Text == "Cause of Death");
    }

    private static MovieExportData Movie(params ExportRowData[] relatedRows)
        => new(
            "movie-role-1",
            new LocalizedValue("Original Movie", "English Movie", "Deutscher Film"),
            null, null, null, null, null, null,
            relatedRows);

    private static PersonExportData Person(params ExportRowData[] relatedRows)
        => new(
            "person-relations-1",
            new LocalizedValue("Original Person", "English Person", "Deutsche Person"),
            null, null, null, null, null, null, null, null, null,
            relatedRows);
}
