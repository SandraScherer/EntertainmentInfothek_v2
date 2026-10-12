using WikiExporter.Application.Export;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Tests;

/// <summary>Verifies every step of the documented localized-value fallback order.</summary>
public sealed class LocalizedValueSelectorFallbackMatrixTests
{
    private readonly ILocalizedValueSelector _selector = new LocalizedValueSelector();

    [Theory]
    [InlineData(ExportLanguage.German, new string?[] { null, "English", "Deutsch" }, "Deutsch")]
    [InlineData(ExportLanguage.German, new string?[] { "Original", "English", null }, "Original")]
    [InlineData(ExportLanguage.German, new string?[] { null, "English", null }, "English")]
    [InlineData(ExportLanguage.English, new string?[] { null, "English", "Deutsch" }, "English")]
    [InlineData(ExportLanguage.English, new string?[] { "Original", null, "Deutsch" }, "Original")]
    [InlineData(ExportLanguage.English, new string?[] { null, null, "Deutsch" }, "Deutsch")]
    [InlineData(ExportLanguage.Original, new string?[] { "Original", "English", "Deutsch" }, "Original")]
    [InlineData(ExportLanguage.Original, new string?[] { null, "English", "Deutsch" }, "English")]
    [InlineData(ExportLanguage.Original, new string?[] { null, null, "Deutsch" }, "Deutsch")]
    public void Select_UsesDocumentedFallbackOrder(ExportLanguage language, string?[] values, string expected)
    {
        var value = new LocalizedValue(values[0], values[1], values[2]);

        Assert.Equal(expected, _selector.Select(value, language));
    }

    [Theory]
    [InlineData(ExportLanguage.German)]
    [InlineData(ExportLanguage.English)]
    [InlineData(ExportLanguage.Original)]
    public void Select_ReturnsNullWhenAllValuesAreWhitespace(ExportLanguage language)
    {
        var value = new LocalizedValue(" ", "\t", "\r\n");

        Assert.Null(_selector.Select(value, language));
    }
}
