using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.Links;

/// <summary>
/// Central link policy. The same target path is used by both renderers, while each dialect gets its own syntax.
/// </summary>
public sealed class ExportLinkResolver(IExportPathResolver paths) : IExportLinkResolver
{
    public string Resolve(MarkdownDocument source, string targetType, string targetId, ExportFormat format)
    {
        // A full target document is not available here, therefore use the canonical ID file name.
        // Titles are intentionally not required for links; the stable ID-based stem avoids broken links when titles change.
        var target = CanonicalTargetPath(targetType, targetId);
        var sourceDirectory = paths.GetDirectory(source, format);
        var relative = RelativePath(sourceDirectory, target);
        return format switch
        {
            ExportFormat.DokuWiki => DokuWikiTarget(target),
            ExportFormat.Obsidian => ObsidianTarget(relative),
            _ => relative
        };
    }

    private static string CanonicalTargetPath(string type, string id)
        => $"{Folder(type)}/{StableIdFileName(type, id)}";

    private static string Folder(string type) => type switch
    {
        "Movie" => "Movies", "Series" => "Series", "Episode" => "Episodes", "Book" => "Books",
        "VideoGame" => "VideoGames", "Person" => "Persons", "Connection" => "Connections", _ => "Other"
    };

    private static string StableIdFileName(string type, string id)
    {
        var bytes = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(id));
        return $"{type}-{Convert.ToHexString(bytes).ToLowerInvariant()[..8]}.md";
    }

    private static string RelativePath(string sourceDirectory, string target)
    {
        var from = sourceDirectory.Replace('\\', '/').TrimEnd('/');
        var targetParts = target.Replace('\\', '/').Split('/', StringSplitOptions.RemoveEmptyEntries);
        var fromParts = from.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var common = 0;
        while (common < fromParts.Length && common < targetParts.Length &&
               string.Equals(fromParts[common], targetParts[common], StringComparison.OrdinalIgnoreCase)) common++;
        var parts = Enumerable.Repeat("..", fromParts.Length - common).Concat(targetParts.Skip(common));
        return string.Join('/', parts);
    }

    private static string DokuWikiTarget(string target) => ":" + target.Replace('/', ':').Replace(".md", "", StringComparison.OrdinalIgnoreCase);
    private static string ObsidianTarget(string relative) => relative.EndsWith(".md", StringComparison.OrdinalIgnoreCase) ? relative[..^3] : relative;
}
