using System.Text;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown.Obsidian;

/// <summary>Renders the neutral document tree as Markdown with Obsidian YAML frontmatter and wikilinks.</summary>
public sealed class ObsidianRenderer(IExportPathResolver paths, IExportLinkResolver links) : IMarkdownRenderer
{
    public ExportFormat Format => ExportFormat.Obsidian;

    public RenderedDocument Render(MarkdownDocument document)
    {
        var sb = new StringBuilder();
        sb.AppendLine("---");
        foreach (var pair in document.Metadata.OrderBy(x => x.Key, StringComparer.Ordinal))
            sb.AppendLine($"{pair.Key}: {Yaml(pair.Value)}");
        sb.AppendLine("---"); sb.AppendLine();

        foreach (var block in document.Blocks)
        {
            switch (block)
            {
                case HeadingBlock h: sb.AppendLine(new string('#', Math.Clamp(h.Level, 1, 6)) + " " + MarkdownEscaper.Text(h.Text)); sb.AppendLine(); break;
                case ParagraphBlock p: sb.AppendLine(MarkdownEscaper.Text(p.Text)); sb.AppendLine(); break;
                case TableBlock t: RenderTable(sb, t); break;
                case ListBlock l: for (var i = 0; i < l.Items.Count; i++) sb.AppendLine((l.Ordered ? $"{i + 1}. " : "- ") + MarkdownEscaper.Text(l.Items[i])); sb.AppendLine(); break;
                case LinkBlock l: sb.AppendLine($"[[{links.Resolve(document, l.TargetType, l.TargetId, Format)}|{MarkdownEscaper.Text(l.Text)}]]"); sb.AppendLine(); break;
                case ImageBlock i: if (!string.IsNullOrWhiteSpace(i.FileName)) sb.AppendLine($"![{MarkdownEscaper.Text(i.Description)}]({i.FileName})"); sb.AppendLine(); break;
                case CodeBlock c: sb.AppendLine("```" + (c.Language ?? "")); sb.AppendLine(MarkdownEscaper.Text(c.Content)); sb.AppendLine("```"); sb.AppendLine(); break;
                case HorizontalRuleBlock: sb.AppendLine("---"); sb.AppendLine(); break;
            }
        }
        return new(paths.GetRelativePath(document, Format), sb.ToString().TrimEnd() + Environment.NewLine);
    }

    private static void RenderTable(StringBuilder sb, TableBlock table)
    {
        sb.AppendLine("| " + string.Join(" | ", table.Headers.Select(MarkdownEscaper.Table)) + " |");
        sb.AppendLine("| " + string.Join(" | ", Enumerable.Repeat("---", table.Headers.Count)) + " |");
        foreach (var row in table.Rows) sb.AppendLine("| " + string.Join(" | ", row.Select(MarkdownEscaper.Table)) + " |");
        sb.AppendLine();
    }

    private static string Yaml(string? value)
    {
        if (value is null) return "null";
        if (value.Length == 0 || value.Any(char.IsWhiteSpace) || value.Contains(':') || value.Contains('#'))
            return "\"" + value.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
        return value;
    }
}
