using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WikiExporter.Application.Persistence;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.Readers;

namespace WikiExporter.Persistence.DependencyInjection;

public static class PersistenceServiceCollectionExtensions
{
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
