using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Regression tests for localized crew, company-credit, and award-contributor roles.</summary>
public sealed class LocalizedCreditAndAwardTests
{
    private static readonly ILocalizedValueSelector Selector = new LocalizedValueSelector();

    [Theory]
    [InlineData(ExportLanguage.English, "Director")]
    [InlineData(ExportLanguage.German, "Regie")]
    public void MovieBuilder_UsesLocalizedCrewRole(ExportLanguage language, string expectedRole)
    {
        var crew = Row("Movie_Crew", "crew-1",
            ("PersonID", "person-1"), ("EnglishRole", "Director"), ("GermanRole", "Regie"));
        var person = Row("Person", "person-1",
            ("EnglishName", "Alex Example"), ("GermanName", "Alex Beispiel"));

        var document = BuildMovie(crew, person, language);

        Assert.Contains(document.Blocks.OfType<HeadingBlock>(), x => x.Text == "Crew");
        Assert.Contains(document.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Person" && x.TargetId == "person-1");
        Assert.Contains(document.Blocks.OfType<ParagraphBlock>(), x => x.Text == expectedRole);
    }

    [Fact]
    public void MovieBuilder_OmitsBlankCrewRoleButKeepsDepartment()
    {
        var crew = Row("Movie_Crew", "crew-empty",
            ("EnglishRole", " "), ("GermanRole", "\t"), ("DepartmentID", "Editing"));

        var document = BuildMovie(crew, ExportLanguage.English);

        Assert.Contains(document.Blocks.OfType<HeadingBlock>(), x => x.Text == "Crew");
        Assert.Contains(document.Blocks.OfType<ParagraphBlock>(), x => x.Text == "Department: Editing");
        Assert.DoesNotContain(document.Blocks.OfType<ParagraphBlock>(), x => x.Text.Contains("Role", StringComparison.Ordinal));
    }

    [Theory]
    [InlineData(ExportLanguage.English, "Publisher")]
    [InlineData(ExportLanguage.German, "Verlag")]
    public void MovieBuilder_UsesLocalizedCompanyCreditRole(ExportLanguage language, string expectedRole)
    {
        var credit = Row("Movie_CompanyCredits", "company-credit-1",
            ("CompanyID", "company-1"), ("EnglishRole", "Publisher"), ("GermanRole", "Verlag"),
            ("DepartmentID", "Publishing"), ("CountryID", "DE"));
        var company = Row("Company", "company-1",
            ("EnglishName", "Example Company"), ("GermanName", "Beispielfirma"));

        var document = BuildMovie(credit, company, language);

        Assert.Contains(document.Blocks.OfType<HeadingBlock>(), x => x.Text == "Company Credits");
        Assert.Contains(document.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Company" && x.TargetId == "company-1");
        Assert.Contains(document.Blocks.OfType<ParagraphBlock>(), x =>
            x.Text.Contains(expectedRole, StringComparison.Ordinal) &&
            x.Text.Contains("Department: Publishing", StringComparison.Ordinal) &&
            x.Text.Contains("Country: DE", StringComparison.Ordinal));
    }

    [Theory]
    [InlineData(ExportLanguage.English, "Nominee")]
    [InlineData(ExportLanguage.German, "Nominierte Person")]
    public void MovieBuilder_UsesLocalizedAwardContributorRole(ExportLanguage language, string expectedRole)
    {
        var award = Row("Movie_Award", "movie-award-1",
            ("AwardID", "award-1"), ("Category", "Best Film"), ("Date", "2025"), ("Winner", "true"));
        var awardName = Row("Award", "award-1",
            ("EnglishName", "Example Award"), ("GermanName", "Beispielpreis"));
        var contributor = Row("Movie_Award_Person", "award-person-1",
            ("Movie_AwardID", "movie-award-1"), ("PersonID", "person-1"),
            ("EnglishRole", "Nominee"), ("GermanRole", "Nominierte Person"));
        var person = Row("Person", "person-1",
            ("EnglishName", "Alex Example"), ("GermanName", "Alex Beispiel"));

        var document = BuildMovie(award, awardName, contributor, person, language);

        Assert.Contains(document.Blocks.OfType<HeadingBlock>(), x => x.Text == "Awards");
        Assert.Contains(document.Blocks.OfType<HeadingBlock>(), x => x.Text == (language == ExportLanguage.German ? "Beispielpreis" : "Example Award"));
        Assert.Contains(document.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Person" && x.TargetId == "person-1");
        Assert.Contains(document.Blocks.OfType<ParagraphBlock>(), x => x.Text == expectedRole);
    }

    [Fact]
    public void MovieBuilder_OmitsBlankAwardContributorRoleButKeepsPersonReference()
    {
        var award = Row("Movie_Award", "movie-award-2", ("AwardID", "award-2"));
        var contributor = Row("Movie_Award_Person", "award-person-2",
            ("Movie_AwardID", "movie-award-2"), ("PersonID", "person-2"),
            ("EnglishRole", " "), ("GermanRole", "\t"));
        var person = Row("Person", "person-2", ("EnglishName", "Taylor Example"));

        var document = BuildMovie(award, contributor, person, ExportLanguage.English);

        Assert.Contains(document.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Person" && x.TargetId == "person-2");
        Assert.DoesNotContain(document.Blocks.OfType<ParagraphBlock>(), x => x.Text == " ");
        Assert.DoesNotContain(document.Blocks.OfType<ParagraphBlock>(), x => x.Text == "\t");
    }

    private static MarkdownDocument BuildMovie(ExportRowData row, ExportLanguage language)
        => BuildMovie(new[] { row }, language);

    private static MarkdownDocument BuildMovie(ExportRowData row1, ExportRowData row2, ExportLanguage language)
        => BuildMovie(new[] { row1, row2 }, language);

    private static MarkdownDocument BuildMovie(ExportRowData row1, ExportRowData row2, ExportRowData row3, ExportLanguage language)
        => BuildMovie(new[] { row1, row2, row3 }, language);

    private static MarkdownDocument BuildMovie(ExportRowData row1, ExportRowData row2, ExportRowData row3, ExportRowData row4, ExportLanguage language)
        => BuildMovie(new[] { row1, row2, row3, row4 }, language);

    private static MarkdownDocument BuildMovie(IReadOnlyList<ExportRowData> rows, ExportLanguage language)
    {
        var movie = new MovieExportData(
            "movie-credits-1",
            new LocalizedValue("Original Movie", "English Movie", "Deutscher Film"),
            null, null, null, null, null, null,
            rows);
        return new MovieDocumentBuilder(Selector).Build(movie, language);
    }

    private static ExportRowData Row(string table, string id, params (string Key, string? Value)[] fields)
        => new(table, id,
            fields.ToDictionary(x => x.Key, x => x.Value, StringComparer.Ordinal),
            new Dictionary<string, string?>());
}
