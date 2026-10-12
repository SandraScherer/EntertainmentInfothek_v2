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

    [Fact]
    public async Task AllSevenExportReaders_ReturnNullForMissingIds()
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
        }

        Assert.Null(await provider.GetRequiredService<IMovieExportReader>().GetAsync("missing"));
        Assert.Null(await provider.GetRequiredService<ISeriesExportReader>().GetAsync("missing"));
        Assert.Null(await provider.GetRequiredService<IEpisodeExportReader>().GetAsync("missing"));
        Assert.Null(await provider.GetRequiredService<IBookExportReader>().GetAsync("missing"));
        Assert.Null(await provider.GetRequiredService<IVideoGameExportReader>().GetAsync("missing"));
        Assert.Null(await provider.GetRequiredService<IPersonExportReader>().GetAsync("missing"));
        Assert.Null(await provider.GetRequiredService<IConnectionExportReader>().GetAsync("missing"));
    }


    [Fact]
    public async Task MovieReader_ReadAllReturnsStableIdOrderAcrossSingleItemBatches()
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
            db.MovieEntity.AddRange(
                new MovieEntity { Id = "m3", OriginalTitle = "Third" },
                new MovieEntity { Id = "m1", OriginalTitle = "First" },
                new MovieEntity { Id = "m2", OriginalTitle = "Second" });
            await db.SaveChangesAsync();
        }

        var reader = provider.GetRequiredService<IMovieExportReader>();
        var actual = new List<MovieExportData>();
        await foreach (var item in reader.ReadAllAsync(new BatchOptions(1)))
        {
            actual.Add(item);
        }

        Assert.Equal(new[] { "m1", "m2", "m3" }, actual.Select(item => item.Id));
        Assert.Equal(new[] { "First", "Second", "Third" }, actual.Select(item => item.Title.Original));
    }

}
