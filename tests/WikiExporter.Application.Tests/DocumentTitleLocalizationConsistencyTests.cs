using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Regression tests ensuring every document builder uses the same localized title in its heading and metadata.</summary>
public sealed class DocumentTitleLocalizationConsistencyTests
{
    private static readonly ILocalizedValueSelector Selector = new LocalizedValueSelector();
    private static readonly IReadOnlyList<ExportRowData> NoRows = Array.Empty<ExportRowData>();

    [Theory]
    [InlineData(ExportEntityType.Movie, ExportLanguage.Original, "Original title")]
    [InlineData(ExportEntityType.Movie, ExportLanguage.English, "English title")]
    [InlineData(ExportEntityType.Movie, ExportLanguage.German, "German title")]
    [InlineData(ExportEntityType.Series, ExportLanguage.Original, "Original title")]
    [InlineData(ExportEntityType.Series, ExportLanguage.English, "English title")]
    [InlineData(ExportEntityType.Series, ExportLanguage.German, "German title")]
    [InlineData(ExportEntityType.Episode, ExportLanguage.Original, "Original title")]
    [InlineData(ExportEntityType.Episode, ExportLanguage.English, "English title")]
    [InlineData(ExportEntityType.Episode, ExportLanguage.German, "German title")]
    [InlineData(ExportEntityType.Book, ExportLanguage.Original, "Original title")]
    [InlineData(ExportEntityType.Book, ExportLanguage.English, "English title")]
    [InlineData(ExportEntityType.Book, ExportLanguage.German, "German title")]
    [InlineData(ExportEntityType.VideoGame, ExportLanguage.Original, "Original title")]
    [InlineData(ExportEntityType.VideoGame, ExportLanguage.English, "English title")]
    [InlineData(ExportEntityType.VideoGame, ExportLanguage.German, "German title")]
    [InlineData(ExportEntityType.Person, ExportLanguage.Original, "Original title")]
    [InlineData(ExportEntityType.Person, ExportLanguage.English, "English title")]
    [InlineData(ExportEntityType.Person, ExportLanguage.German, "German title")]
    [InlineData(ExportEntityType.Connection, ExportLanguage.Original, "Original title")]
    [InlineData(ExportEntityType.Connection, ExportLanguage.English, "English title")]
    [InlineData(ExportEntityType.Connection, ExportLanguage.German, "German title")]
    public void EveryBuilder_UsesSelectedTitleInHeadingAndMetadata(ExportEntityType type, ExportLanguage language, string expected)
    {
        var data = CreateData(type, new LocalizedValue("Original title", "English title", "German title"));
        var document = CreateBuilder(type).Build(data, language);

        Assert.Equal(expected, Assert.IsType<HeadingBlock>(document.Blocks[0]).Text);
        Assert.Equal(expected, document.Metadata["title"]);
        Assert.Equal(data.Id, document.EntityId);
    }

    [Theory]
    [InlineData(ExportEntityType.Movie, ExportLanguage.Original)]
    [InlineData(ExportEntityType.Movie, ExportLanguage.English)]
    [InlineData(ExportEntityType.Movie, ExportLanguage.German)]
    [InlineData(ExportEntityType.Series, ExportLanguage.Original)]
    [InlineData(ExportEntityType.Series, ExportLanguage.English)]
    [InlineData(ExportEntityType.Series, ExportLanguage.German)]
    [InlineData(ExportEntityType.Episode, ExportLanguage.Original)]
    [InlineData(ExportEntityType.Episode, ExportLanguage.English)]
    [InlineData(ExportEntityType.Episode, ExportLanguage.German)]
    [InlineData(ExportEntityType.Book, ExportLanguage.Original)]
    [InlineData(ExportEntityType.Book, ExportLanguage.English)]
    [InlineData(ExportEntityType.Book, ExportLanguage.German)]
    [InlineData(ExportEntityType.VideoGame, ExportLanguage.Original)]
    [InlineData(ExportEntityType.VideoGame, ExportLanguage.English)]
    [InlineData(ExportEntityType.VideoGame, ExportLanguage.German)]
    [InlineData(ExportEntityType.Person, ExportLanguage.Original)]
    [InlineData(ExportEntityType.Person, ExportLanguage.English)]
    [InlineData(ExportEntityType.Person, ExportLanguage.German)]
    [InlineData(ExportEntityType.Connection, ExportLanguage.Original)]
    [InlineData(ExportEntityType.Connection, ExportLanguage.English)]
    [InlineData(ExportEntityType.Connection, ExportLanguage.German)]
    public void EveryBuilder_FallsBackToUntitledWhenAllTitleVariantsAreBlank(ExportEntityType type, ExportLanguage language)
    {
        var data = CreateData(type, new LocalizedValue(null, "  ", "\t"));
        var builder = CreateBuilder(type);

        var document = builder.Build(data, language);

        Assert.Equal("Untitled", Assert.IsType<HeadingBlock>(document.Blocks[0]).Text);
        Assert.Equal("Untitled", document.Metadata["title"]);
    }

    private static IDocumentBuilder CreateBuilder(ExportEntityType type) => type switch
    {
        ExportEntityType.Movie => new MovieDocumentBuilder(Selector),
        ExportEntityType.Series => new SeriesDocumentBuilder(Selector),
        ExportEntityType.Episode => new EpisodeDocumentBuilder(Selector),
        ExportEntityType.Book => new BookDocumentBuilder(Selector),
        ExportEntityType.VideoGame => new VideoGameDocumentBuilder(Selector),
        ExportEntityType.Person => new PersonDocumentBuilder(Selector),
        ExportEntityType.Connection => new ConnectionDocumentBuilder(Selector),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };

    private static ExportDataBase CreateData(ExportEntityType type, LocalizedValue title) => type switch
    {
        ExportEntityType.Movie => new MovieExportData("id-1", title, null, null, null, null, null, null, NoRows),
        ExportEntityType.Series => new SeriesExportData("id-1", title, null, null, null, null, null, Array.Empty<EpisodeReference>(), NoRows),
        ExportEntityType.Episode => new EpisodeExportData("id-1", title, null, null, null, null, NoRows),
        ExportEntityType.Book => new BookExportData("id-1", title, null, null, null, NoRows),
        ExportEntityType.VideoGame => new VideoGameExportData("id-1", title, null, null, null, null, null, null, NoRows),
        ExportEntityType.Person => new PersonExportData("id-1", title, null, null, null, null, null, null, null, null, null, NoRows),
        ExportEntityType.Connection => new ConnectionExportData("id-1", title, null, null, Array.Empty<EntityReference>(), Array.Empty<WorkReference>(), NoRows),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };
}
