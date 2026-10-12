namespace WikiExporter.Export.Markdown;

/// <summary>Represents markdown escaper.</summary>
internal static class MarkdownEscaper
{
/// <summary>Performs the text operation.</summary>
    public static string Text(string? value) => value?.Replace("\r\n", "\n").Replace('\r', '\n') ?? string.Empty;
/// <summary>Performs the table operation.</summary>
    public static string Table(string? value) => Text(value).Replace("|", "\\|").Replace("\n", "<br>");
/// <summary>Performs the doku wiki table operation.</summary>
    public static string DokuWikiTable(string? value) => Table(value);
}
