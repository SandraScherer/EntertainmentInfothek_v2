namespace WikiExporter.Export.Markdown;

internal static class MarkdownEscaper
{
    public static string Text(string? value) => value?.Replace("\r\n", "\n").Replace('\r', '\n') ?? string.Empty;
    public static string Table(string? value) => Text(value).Replace("|", "\\|").Replace("\n", "<br>");
    public static string DokuWikiTable(string? value) => Table(value);
}
