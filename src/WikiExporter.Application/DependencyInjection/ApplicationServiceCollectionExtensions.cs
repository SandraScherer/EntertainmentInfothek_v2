using Microsoft.Extensions.DependencyInjection;
using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Services;
using WikiExporter.Application.Localization;

namespace WikiExporter.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddWikiExporterApplication(this IServiceCollection services)
    {
        services.AddSingleton<ILocalizedValueSelector,LocalizedValueSelector>();
        services.AddScoped<IExportReaderResolver,ExportReaderResolver>();
        services.AddScoped<IDocumentBuilderResolver,DocumentBuilderResolver>();
        services.AddScoped<IExportUseCase,ExportUseCase>();
        services.AddScoped<MovieDocumentBuilder>(); services.AddScoped<SeriesDocumentBuilder>(); services.AddScoped<EpisodeDocumentBuilder>();
        services.AddScoped<BookDocumentBuilder>(); services.AddScoped<VideoGameDocumentBuilder>(); services.AddScoped<PersonDocumentBuilder>(); services.AddScoped<ConnectionDocumentBuilder>();
        return services;
    }
}
