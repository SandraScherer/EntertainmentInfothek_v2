using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WikiExporter.Application.Persistence;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.DependencyInjection;

namespace WikiExporter.Persistence.Tests;

public sealed class EfModelAndReaderTests
{
    [Fact]
    public void Model_ContainsAllSchemaTablesAndForeignKeys()
    {
        var options = new DbContextOptionsBuilder<EntertainmentInfothekDbContext>()
            .UseSqlite("Data Source=:memory:").Options;
        using var db = new EntertainmentInfothekDbContext(options);
        var tables = db.Model.GetEntityTypes().Select(x => x.GetTableName()).Where(x => x is not null).Distinct(StringComparer.Ordinal).ToArray();
        var foreignKeys = db.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()).Count();

        Assert.Equal(196, tables.Length);
        Assert.Equal(542, foreignKeys);
    }

    [Fact]
    public async Task MovieReader_LoadsRootWithoutRequiringLookupRows()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var services = new ServiceCollection();
        services.AddWikiExporterPersistence("Data Source=:memory:");
        // The production registration creates its own connection. For a stable in-memory test
        // we instead register a factory bound to the connection opened above.
        services.AddPooledDbContextFactory<EntertainmentInfothekDbContext>(o => o.UseSqlite(connection));
        await using var provider = services.BuildServiceProvider();
        await using (var db = provider.GetRequiredService<IDbContextFactory<EntertainmentInfothekDbContext>>().CreateDbContext())
        {
            await db.Database.EnsureCreatedAsync();
            db.Movie.Add(new Persistence.Entities.Movie { Id = "m1", OriginalTitle = "Original", EnglishTitle = "English", GermanTitle = "Deutsch", Details = "Details" });
            await db.SaveChangesAsync();
        }

        var reader = provider.GetRequiredService<IMovieExportReader>();
        var result = await reader.GetAsync("m1");

        Assert.NotNull(result);
        Assert.Equal("m1", result!.Id);
        Assert.Equal("English", result.Title.English);
    }
}

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
            db.Series.Add(new Persistence.Entities.Series { Id = "s1", OriginalTitle = "Series" });
            db.Episode.Add(new Persistence.Entities.Episode { Id = "e1", SeriesId = "s1", OriginalTitle = "Pilot", SeasonNo = "1", EpisodeNo = "1" });
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
