using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Regression tests for language selection on names and titles referenced by other documents.</summary>
public sealed class RelatedReferenceLocalizationTests
{
    private static readonly ILocalizedValueSelector Selector = new LocalizedValueSelector();

    [Theory]
    [InlineData(ExportLanguage.Original, "Original Person")]
    [InlineData(ExportLanguage.English, "English Person")]
    [InlineData(ExportLanguage.German, "Deutsche Person")]
    public void MovieBuilder_UsesRequestedLanguageForCastPersonNames(ExportLanguage language, string expectedName)
    {
        var data = MovieWithCastPerson(
            originalName: "Original Person",
            englishName: "English Person",
            germanName: "Deutsche Person");

        var document = new MovieDocumentBuilder(Selector).Build(data, language);
        var link = Assert.Single(document.Blocks.OfType<LinkBlock>().Where(x => x.TargetType == "Person"));

        Assert.Equal("person-1", link.TargetId);
        Assert.Equal($"Actor: {expectedName}", link.Text);
    }

    [Theory]
    [InlineData(ExportLanguage.Original, "Original Person")]
    [InlineData(ExportLanguage.English, "Original Person")]
    [InlineData(ExportLanguage.German, "Deutsche Person")]
    public void MovieBuilder_FallsBackToOriginalPersonNameBeforeOtherLanguage(ExportLanguage language, string expectedName)
    {
        var data = MovieWithCastPerson(
            originalName: "Original Person",
            englishName: "   ",
            germanName: "Deutsche Person");

        var document = new MovieDocumentBuilder(Selector).Build(data, language);
        var link = Assert.Single(document.Blocks.OfType<LinkBlock>().Where(x => x.TargetType == "Person"));

        Assert.Equal($"Actor: {expectedName}", link.Text);
    }

    [Theory]
    [InlineData(ExportLanguage.Original, "Original Work")]
    [InlineData(ExportLanguage.English, "English Work")]
    [InlineData(ExportLanguage.German, "Deutsches Werk")]
    public void ConnectionBuilder_UsesRequestedLanguageForReferencedWorkTitles(ExportLanguage language, string expectedTitle)
    {
        var data = new ConnectionExportData(
            "connection-1",
            new LocalizedValue("Original Universe", "English Universe", "Deutsches Universum"),
            null,
            null,
            Array.Empty<EntityReference>(),
            new[]
            {
                new WorkReference("Movie", "movie-1", new LocalizedValue("Original Work", "English Work", "Deutsches Werk"))
            },
            Array.Empty<ExportRowData>());

        var document = new ConnectionDocumentBuilder(Selector).Build(data, language);
        var link = Assert.Single(document.Blocks.OfType<LinkBlock>().Where(x => x.TargetType == "Movie"));

        Assert.Equal("movie-1", link.TargetId);
        Assert.Equal(expectedTitle, link.Text);
    }

    [Theory]
    [InlineData(ExportLanguage.Original, "Original Work")]
    [InlineData(ExportLanguage.English, "Original Work")]
    [InlineData(ExportLanguage.German, "Deutsches Werk")]
    public void ConnectionBuilder_FallsBackToOriginalTitleForReferencedWork(ExportLanguage language, string expectedTitle)
    {
        var data = new ConnectionExportData(
            "connection-2",
            new LocalizedValue("Universe", "Universe EN", "Universum DE"),
            null,
            null,
            Array.Empty<EntityReference>(),
            new[]
            {
                new WorkReference("Book", "book-1", new LocalizedValue("Original Work", " ", "Deutsches Werk"))
            },
            Array.Empty<ExportRowData>());

        var document = new ConnectionDocumentBuilder(Selector).Build(data, language);
        var link = Assert.Single(document.Blocks.OfType<LinkBlock>().Where(x => x.TargetType == "Book"));

        Assert.Equal(expectedTitle, link.Text);
    }

    private static MovieExportData MovieWithCastPerson(string? originalName, string? englishName, string? germanName)
    {
        var cast = new ExportRowData(
            "Movie_Cast",
            "cast-1",
            new Dictionary<string, string?> { ["ActorID"] = "person-1" },
            new Dictionary<string, string?>());
        var person = new ExportRowData(
            "Person",
            "person-1",
            new Dictionary<string, string?>
            {
                ["OriginalName"] = originalName,
                ["EnglishName"] = englishName,
                ["GermanName"] = germanName
            },
            new Dictionary<string, string?>());

        return new MovieExportData(
            "movie-1",
            new LocalizedValue("Original Movie", "English Movie", "Deutscher Film"),
            null,
            null,
            null,
            null,
            null,
            null,
            new[] { cast, person });
    }
}
