using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WikiExporter.Application.Persistence;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.DependencyInjection;

namespace WikiExporter.Persistence.Tests;

/// <summary>Represents relationship reader tests.</summary>
public sealed class RelationshipReaderTests
{
    [Fact]
    public async Task SeriesReader_LoadsEpisodeReferencesWithoutEmbeddingFullEpisodes()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var services = new ServiceCollection();
        services.AddWikiExporterPersistence("Data Source=:memory:");
        services.AddPooledDbContextFactory<EntertainmentInfothekDbContext>(o => o.UseSqlite(connection));
        await using var provider = services.BuildServiceProvider();
        await using (var db = provider.GetRequiredService<IDbContextFactory<EntertainmentInfothekDbContext>>().CreateDbContext())
        {
            await db.Database.EnsureCreatedAsync();
            db.SeriesEntity.Add(new Persistence.Entities.SeriesEntity { Id = "s1", OriginalTitle = "Series" });
            db.EpisodeEntity.Add(new Persistence.Entities.EpisodeEntity { Id = "e1", SeriesId = "s1", OriginalTitle = "Pilot", SeasonNo = "1", EpisodeNo = "1" });
            await db.SaveChangesAsync();
        }

        var reader = provider.GetRequiredService<ISeriesExportReader>();
        var result = await reader.GetAsync("s1");

        Assert.NotNull(result);
        var episode = Assert.Single(result!.Episodes);
        Assert.Equal("e1", episode.Id);
        Assert.Equal("1", episode.SeasonNo);
        Assert.Equal("1", episode.EpisodeNo);
    }
}
