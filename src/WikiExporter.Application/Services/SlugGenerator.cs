using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace WikiExporter.Application.Services;

/// <summary>
/// Erzeugt Datei- und Wiki-Slugs.
/// </summary>
public static class SlugGenerator
{
    public static string Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "unknown";
        }

        value = value.Trim();

        value = value
            .Replace("ä", "ae")
            .Replace("ö", "oe")
            .Replace("ü", "ue")
            .Replace("Ä", "Ae")
            .Replace("Ö", "Oe")
            .Replace("Ü", "Ue")
            .Replace("ß", "ss");

        var normalized = value.Normalize(NormalizationForm.FormD);

        var builder = new StringBuilder();

        foreach (var c in normalized)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory(c);

            if (category != UnicodeCategory.NonSpacingMark)
            {
                builder.Append(c);
            }
        }

        var result = builder.ToString();

        result = Regex.Replace(
            result,
            @"[^a-zA-Z0-9]+",
            "-");

        result = result
            .Trim('-')
            .ToLowerInvariant();

        return result;
    }
}
