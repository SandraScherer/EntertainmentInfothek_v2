using System.Text;
using WikiExporter.Application.Documents;

namespace WikiExporter.Markdown.Rendering;

public sealed class DokuWikiBlockRenderer
    : IBlockRenderer
{
    public string Render(
        ExportBlock block)
    {
        return block switch
        {
            TextBlock b => RenderText(b),
            ListBlock b => RenderList(b),
            TableBlock b => RenderTable(b),
            ImageBlock b => RenderImage(b),
            LinkBlock b => RenderLink(b),
            _ => string.Empty
        };
    }

    private static string RenderText(
        TextBlock block)
    {
        return block.Text + Environment.NewLine;
    }

    private static string RenderList(
        ListBlock block)
    {
        var sb = new StringBuilder();

        foreach (var item in block.Items)
        {
            sb.AppendLine($"  * {item}");
        }

        return sb.ToString();
    }

    private static string RenderImage(
        ImageBlock block)
    {
        return
            $"{{{{{block.FileName}|{block.Caption}}}}}" +
            Environment.NewLine;
    }

    private static string RenderLink(
        LinkBlock block)
    {
        return
            $"[[{block.Url}|{block.Text}]]" +
            Environment.NewLine;
    }

    private static string RenderTable(
        TableBlock block)
    {
        var sb = new StringBuilder();

        sb.Append('^');

        foreach (var h in block.Headers)
        {
            sb.Append($" {h} ^");
        }

        sb.AppendLine();

        foreach (var row in block.Rows)
        {
            sb.Append('|');

            foreach (var value in row)
            {
                sb.Append($" {value} |");
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }
}
