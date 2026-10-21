namespace WikiExporter.Export.Markdown;

/// <summary>Represents markdown escaper.</summary>
internal static class MarkdownEscaper
{
/// <summary>Performs the text operation.</summary>
    public static string NormalizeLineEndings(string? value) =>
        value?.Replace("\\r\\n", "\\n", StringComparison.Ordinal).Replace('\\r', '\\n') ?? string.Empty;

/// <summary>Normalizes line endings in text.</summary>
    public static string Text(string? value) => NormalizeLineEndings(value);
/// <summary>Performs the table operation.</summary>
    public static string Table(string? value) => Text(value).Replace("|", "\\|").Replace("\n", "<br>");
/// <summary>Performs the doku wiki table operation.</summary>
    public static string DokuWikiTable(string? value) => Table(value);
}
