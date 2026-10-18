using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Regression coverage for empty person relationship rows.</summary>
public sealed class PersonRelationEmptyRowsRegressionTests
{
    private static readonly PersonDocumentBuilder Builder = new(new LocalizedValueSelector());

    [Theory]
    [InlineData("Person_Family", "FamilyID", "Family")]
    [InlineData("Person_Employer", "EmployerID", "Employers")]
    [InlineData("Person_Position", "PositionID", "Positions")]
    [InlineData("Person_Profession", "ProfessionID", "Professions")]
    [InlineData("Person_Species", "SpeciesID", "Species")]
    public void Build_OmitsRelationSectionWhenAllTargetIdsAreBlank(string table, string targetField, string heading)
    {
        var rows = new[]
        {
            Row(table, "relation-1", (targetField, null), ("EnglishRole", "Role")),
            Row(table, "relation-2", (targetField, " "), ("GermanRole", "Rolle"))
        };

        var document = Builder.Build(Person(rows), ExportLanguage.English);

        Assert.DoesNotContain(document.Blocks.OfType<HeadingBlock>(), x => x.Text == heading);
        Assert.DoesNotContain(document.Blocks.OfType<LinkBlock>(), x => x.TargetType is "Person" or "Employer" or "Position" or "Profession" or "Species");
    }

    [Theory]
    [InlineData("Person_Family", "FamilyID", "Family", "Person", "family-person")]
    [InlineData("Person_Employer", "EmployerID", "Employers", "Employer", "employer-1")]
    [InlineData("Person_Position", "PositionID", "Positions", "Position", "position-1")]
    [InlineData("Person_Profession", "ProfessionID", "Professions", "Profession", "profession-1")]
    [InlineData("Person_Species", "SpeciesID", "Species", "Species", "species-1")]
    public void Build_IgnoresBlankTargetRowsButKeepsValidRelationships(
        string table, string targetField, string heading, string targetType, string targetId)
    {
        var rows = new[]
        {
            Row(table, "blank-relation", (targetField, " ")),
            Row(table, "valid-relation", (targetField, targetId))
        };

        var document = Builder.Build(Person(rows), ExportLanguage.English);
        var link = Assert.Single(document.Blocks.OfType<LinkBlock>().Where(x => x.TargetType == targetType));

        Assert.Contains(document.Blocks.OfType<HeadingBlock>(), x => x.Text == heading);
        Assert.Equal(targetId, link.TargetId);
    }

    private static PersonExportData Person(IReadOnlyList<ExportRowData> rows) => new(
        "person-root", new LocalizedValue("Original", "English", "Deutsch"),
        null, null, null, null, null, null, null, null, null, rows);

    private static ExportRowData Row(string table, string id, params (string Key, string? Value)[] fields)
        => new(table, id,
            fields.ToDictionary(x => x.Key, x => x.Value, StringComparer.Ordinal),
            new Dictionary<string, string?>());
}
