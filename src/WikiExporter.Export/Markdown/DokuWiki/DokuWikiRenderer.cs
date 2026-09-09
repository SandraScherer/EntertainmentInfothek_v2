using System.Text;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Export.Markdown.DokuWiki;

/// <summary>Renders the neutral document tree using DokuWiki syntax.</summary>
public sealed class DokuWikiRenderer(IExportPathResolver paths, IExportLinkResolver links) : IMarkdownRenderer
{
    public ExportFormat Format => ExportFormat.DokuWiki;

    public RenderedDocument Render(MarkdownDocument document)
    {
        var sb = new StringBuilder();
        foreach (var block in document.Blocks)
        {
            switch (block)
            {
                case HeadingBlock h: sb.AppendLine(new string('=', Math.Clamp(7 - h.Level, 1, 6)) + " " + MarkdownEscaper.Text(h.Text) + " " + new string('=', Math.Clamp(7 - h.Level, 1, 6))); sb.AppendLine(); break;
                case ParagraphBlock p: sb.AppendLine(MarkdownEscaper.Text(p.Text)); sb.AppendLine(); break;
                case TableBlock t: RenderTable(sb, t); break;
                case ListBlock l: foreach (var item in l.Items) sb.AppendLine((l.Ordered ? "  - " : "  * ") + MarkdownEscaper.Text(item)); sb.AppendLine(); break;
                case LinkBlock l: sb.AppendLine($"[[{links.Resolve(document, l.TargetType, l.TargetId, Format)}|{MarkdownEscaper.Text(l.Text)}]]"); sb.AppendLine(); break;
                case ImageBlock i: if (!string.IsNullOrWhiteSpace(i.FileName)) sb.AppendLine($"{{{{{i.FileName}|{MarkdownEscaper.Text(i.Description)}}}}"); sb.AppendLine(); break;
                case CodeBlock c: sb.AppendLine($"<code {c.Language ?? ""}>".TrimEnd() + "\n" + MarkdownEscaper.Text(c.Content) + "\n</code>"); sb.AppendLine(); break;
                case HorizontalRuleBlock: sb.AppendLine("----"); sb.AppendLine(); break;
            }
        }
        return new(paths.GetRelativePath(document, Format), sb.ToString().TrimEnd() + Environment.NewLine);
    }

    private static void RenderTable(StringBuilder sb, TableBlock table)
    {
        sb.AppendLine("^ " + string.Join(" ^ ", table.Headers.Select(MarkdownEscaper.DokuWikiTable)) + " ^");
        foreach (var row in table.Rows) sb.AppendLine("| " + string.Join(" | ", row.Select(MarkdownEscaper.DokuWikiTable)) + " |");
        sb.AppendLine();
    }
}
