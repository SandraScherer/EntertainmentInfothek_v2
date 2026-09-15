namespace WikiExporter.Export.Markdown;

internal static class MarkdownEscaper
{
    public static string TextEntity(string? value) => value?.Replace("\r\n", "\n").Replace('\r', '\n') ?? string.Empty;
    public static string Table(string? value) => TextEntity(value).Replace("|", "\\|").Replace("\n", "<br>");
    public static string DokuWikiTable(string? value) => Table(value);
}
