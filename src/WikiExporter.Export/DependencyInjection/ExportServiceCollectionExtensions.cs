using Microsoft.Extensions.DependencyInjection;
using WikiExporter.Export.FileNames;
using WikiExporter.Export.FileSystem;
using WikiExporter.Export.Links;
using WikiExporter.Export.Markdown;
using WikiExporter.Export.Markdown.DokuWiki;
using WikiExporter.Export.Markdown.Obsidian;
using WikiExporter.Export.Paths;

namespace WikiExporter.Export.DependencyInjection;

public static class ExportServiceCollectionExtensions
{
    public static IServiceCollection AddWikiExporterExport(this IServiceCollection services)
    {
        services.AddSingleton<IExportFileNameGenerator, ExportFileNameGenerator>();
        services.AddSingleton<IExportPathResolver, ExportPathResolver>();
        services.AddSingleton<IExportLinkResolver, ExportLinkResolver>();
        services.AddSingleton<DokuWikiRenderer>();
        services.AddSingleton<ObsidianRenderer>();
        services.AddSingleton<IMarkdownRendererResolver, MarkdownRendererResolver>();
        services.AddSingleton<IExportFileWriter, FileSystemExportFileWriter>();
        services.AddSingleton<IMarkdownExportService, MarkdownExportService>();
        return services;
    }
}
