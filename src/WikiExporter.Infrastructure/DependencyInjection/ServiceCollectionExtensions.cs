using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WikiExporter.Application.Builders;
using WikiExporter.Application.Interfaces;
using WikiExporter.Application.UseCases;

using WikiExporter.Infrastructure.FileSystem;
using WikiExporter.Infrastructure.Persistence.DbContext;
using WikiExporter.Infrastructure.Persistence.Repositories;

using WikiExporter.Markdown.Factories;
using WikiExporter.Markdown.Renderers;
using WikiExporter.Markdown.Rendering;

namespace WikiExporter.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection
        AddWikiExporter(
            this IServiceCollection services,
            IConfiguration configuration)
    {
        services.AddDbContext<
            EntertainmentInfothekDbContext>(
            options =>
                options.UseSqlite(
                    configuration.GetConnectionString(
                        "EntertainmentInfothek")));

        services.AddScoped<
            IMovieRepository,
            MovieRepository>();

        services.AddScoped<
            IMovieExportDocumentBuilder,
            MovieExportDocumentBuilder>();

        services.AddScoped<
            IFileWriter,
            FileWriter>();

        services.AddScoped<
            ObsidianBlockRenderer>();

        services.AddScoped<
            DokuWikiBlockRenderer>();

        services.AddScoped<
            ObsidianRenderer>();

        services.AddScoped<
            DokuWikiRenderer>();
    
        services.AddScoped<
            IMarkdownRendererFactory,
            MarkdownRendererFactory>();

        services.AddScoped<
            ExportMovieUseCase>();

        return services;
    }
}
