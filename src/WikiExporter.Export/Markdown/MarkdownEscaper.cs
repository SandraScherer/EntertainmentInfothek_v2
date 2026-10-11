namespace WikiExporter.Export.Markdown;

/// <summary>Defines the markdown escaper type.</summary>
internal static class MarkdownEscaper
{
/// <summary>Executes the text operation.</summary>
    public static string Text(string? value) => value?.Replace("\r\n", "\n").Replace('\r', '\n') ?? string.Empty;
/// <summary>Executes the table operation.</summary>
    public static string Table(string? value) => Text(value).Replace("|", "\\|").Replace("\n", "<br>");
/// <summary>Executes the doku wiki table operation.</summary>
    public static string DokuWikiTable(string? value) => Table(value);
}
