using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.Markdown;

namespace WikiExporter.Export.Paths;

/// <summary>Uses one predictable namespace per exported entity type.</summary>
public sealed class ExportPathResolver(IExportFileNameGenerator fileNames) : IExportPathResolver
{
/// <summary>Executes the get relative path operation.</summary>
    public string GetRelativePath(MarkdownDocument document, ExportFormat format)
        => Path.Combine(GetDirectory(document, format), fileNames.Generate(document)).Replace('\\', '/');

/// <summary>Executes the get directory operation.</summary>
    public string GetDirectory(MarkdownDocument document, ExportFormat format) => document.DocumentType switch
    {
        "Movie" => "Movies",
        "Series" => "Series",
        "Episode" => "Episodes",
        "Book" => "Books",
        "VideoGame" => "VideoGames",
        "Person" => "Persons",
        "Connection" => "Connections",
        _ => "Other"
    };
}
