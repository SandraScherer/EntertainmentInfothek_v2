using WikiExporter.Application.Export;
using WikiExporter.Application.Localization;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

public sealed class LocalizationTests
{
    private readonly ILocalizedValueSelector _selector = new LocalizedValueSelector();

    [Theory]
    [InlineData(ExportLanguage.German, "Deutsch")]
    [InlineData(ExportLanguage.English, "English")]
    [InlineData(ExportLanguage.Original, "Original")]
    public void Select_PrefersRequestedLanguage(ExportLanguage language, string expected)
        => Assert.Equal(expected, _selector.Select(new("Original", "English", "Deutsch"), language));

    [Fact]
    public void Select_GermanFallsBackToOriginalThenEnglish()
        => Assert.Equal("Original", _selector.Select(new("Original", "English", null), ExportLanguage.German));

    [Fact]
    public void Select_EnglishFallsBackToOriginalThenGerman()
        => Assert.Equal("Deutsch", _selector.Select(new(null, null, "Deutsch"), ExportLanguage.English));
}
