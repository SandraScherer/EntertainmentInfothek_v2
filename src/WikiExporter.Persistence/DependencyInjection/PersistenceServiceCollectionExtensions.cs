using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WikiExporter.Application.Persistence;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.Readers;

namespace WikiExporter.Persistence.DependencyInjection;

/// <summary>Represents persistence service collection extensions.</summary>
public static class PersistenceServiceCollectionExtensions
{
/// <summary>Performs the add wiki exporter persistence operation.</summary>
    public static IServiceCollection AddWikiExporterPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddPooledDbContextFactory<EntertainmentInfothekDbContext>(o => o.UseSqlite(connectionString));
        services.AddScoped<IMovieExportReader, MovieExportReader>();
        services.AddScoped<ISeriesExportReader, SeriesExportReader>();
        services.AddScoped<IEpisodeExportReader, EpisodeExportReader>();
        services.AddScoped<IBookExportReader, BookExportReader>();
        services.AddScoped<IVideoGameExportReader, VideoGameExportReader>();
        services.AddScoped<IPersonExportReader, PersonExportReader>();
        services.AddScoped<IConnectionExportReader, ConnectionExportReader>();
        return services;
    }
}
