using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Localization;

/// <summary>Applies the agreed language fallback: requested language, Original, then the remaining languages.</summary>
public sealed class LocalizedValueSelector : ILocalizedValueSelector
{
    public string? Select(LocalizedValue value, ExportLanguage language) => language switch
    {
        ExportLanguage.German => First(value.German, value.Original, value.English),
        ExportLanguage.English => First(value.English, value.Original, value.German),
        _ => First(value.Original, value.English, value.German)
    };

    private static string? First(params string?[] values) => values.FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));
}
