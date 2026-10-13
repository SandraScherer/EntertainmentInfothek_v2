using System.Text;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown.Obsidian;

/// <summary>Renders the neutral document tree as Markdown with Obsidian YAML frontmatter and wikilinks.</summary>
public sealed class ObsidianRenderer(IExportPathResolver paths, IExportLinkResolver links) : IMarkdownRenderer
{
/// <summary>Stores format for use by this component.</summary>
    public ExportFormat Format => ExportFormat.Obsidian;

/// <summary>Performs the render operation.</summary>
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

/// <summary>Performs the render table operation.</summary>
    private static void RenderTable(StringBuilder sb, TableBlock table)
    {
        sb.AppendLine("| " + string.Join(" | ", table.Headers.Select(MarkdownEscaper.Table)) + " |");
        sb.AppendLine("| " + string.Join(" | ", Enumerable.Repeat("---", table.Headers.Count)) + " |");
        foreach (var row in table.Rows) sb.AppendLine("| " + string.Join(" | ", row.Select(MarkdownEscaper.Table)) + " |");
        sb.AppendLine();
    }

/// <summary>Performs the yaml operation.</summary>
    private static string Yaml(string? value)
    {
        if (value is null) return "null";

        // Keep simple human-readable strings unquoted, but quote values that YAML could
        // interpret as another scalar type or that require escaping.
        var reserved = value.Equals("null", StringComparison.OrdinalIgnoreCase)
            || value.Equals("true", StringComparison.OrdinalIgnoreCase)
            || value.Equals("false", StringComparison.OrdinalIgnoreCase)
            || value.Equals("yes", StringComparison.OrdinalIgnoreCase)
            || value.Equals("no", StringComparison.OrdinalIgnoreCase)
            || value.Equals("on", StringComparison.OrdinalIgnoreCase)
            || value.Equals("off", StringComparison.OrdinalIgnoreCase)
            || value == "~";
        var simplePlainScalar = value.Length > 0
            && (char.IsAsciiLetter(value[0]) || value[0] == '_')
            && value.All(c => char.IsAsciiLetterOrDigit(c) || c is '_' or '-');

        if (simplePlainScalar && !reserved) return value;
        return "\"" + value.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
    }
}
