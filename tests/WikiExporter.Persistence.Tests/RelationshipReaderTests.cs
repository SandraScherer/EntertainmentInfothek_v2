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


    [Fact]
    public async Task ConnectionReader_KeepsChildAndWorkReferencesScopedToEachConnection()
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
            db.ConnectionEntity.AddRange(
                new ConnectionEntity { Id = "c1", OriginalName = "Universe One", Details = "first details" },
                new ConnectionEntity { Id = "c2", OriginalName = "Universe Two", Details = "second details" },
                new ConnectionEntity { Id = "c1-child", OriginalName = "Child Universe", ConnectionId = "c1" });
            db.MovieEntity.AddRange(
                new MovieEntity { Id = "m1", OriginalTitle = "Movie One", ConnectionId = "c1" },
                new MovieEntity { Id = "m2", OriginalTitle = "Movie Two", ConnectionId = "c2" });
            db.BookEntity.Add(new BookEntity { Id = "b1", OriginalTitle = "Book One", ConnectionId = "c1" });
            db.SaveChanges();
        }

        var reader = provider.GetRequiredService<IConnectionExportReader>();
        var results = new List<ConnectionExportData>();
        await foreach (var item in reader.ReadAllAsync(new BatchOptions(10))) results.Add(item);

        var first = Assert.Single(results, x => x.Id == "c1");
        Assert.Equal("first details", first.Details);
        Assert.Equal("c1-child", Assert.Single(first.Children).Id);
        Assert.Equal(new[] { "b1", "m1" }, first.Works.Select(x => x.Id));

        var second = Assert.Single(results, x => x.Id == "c2");
        Assert.Empty(second.Children);
        Assert.Equal(new[] { "m2" }, second.Works.Select(x => x.Id));
    }

    [Fact]
    public async Task BookReader_IncludesPublicationRowsButExcludesPrivateAndTrackingColumns()
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
            db.BookEntity.Add(new BookEntity { Id = "b1", OriginalTitle = "Original Book", Details = "book details", Notes = "do not export", LastUpdated = "2025-01-01" });
            db.PublicationEntity.Add(new PublicationEntity { Id = "pub1", BookId = "b1", EnglishTitle = "English Edition", ISBN13 = "9780000000000", Details = "publication details", Notes = "private publication note" });
            await db.SaveChangesAsync();
        }

        var result = await provider.GetRequiredService<IBookExportReader>().GetAsync("b1");

        Assert.NotNull(result);
        Assert.Equal("Original Book", result!.Title.Original);
        Assert.Equal("book details", result.Details);
        var publication = Assert.Single(result.RelatedData, row => row.Table == "Publication");
        Assert.Equal("pub1", publication.Id);
        Assert.Equal("English Edition", publication.Fields["EnglishTitle"]);
        Assert.Equal("9780000000000", publication.Fields["ISBN13"]);
        Assert.DoesNotContain("Notes", publication.Fields.Keys);
        Assert.DoesNotContain("LastUpdated", publication.Fields.Keys);
        Assert.DoesNotContain("StatusID", publication.Fields.Keys);
        var bookRow = Assert.Single(result.RelatedData, row => row.Table == "Book");
        Assert.DoesNotContain("Notes", bookRow.Fields.Keys);
        Assert.DoesNotContain("LastUpdated", bookRow.Fields.Keys);
        Assert.DoesNotContain("StatusID", bookRow.Fields.Keys);
    }

    [Fact]
    public async Task VideoGameReader_IncludesTechnicalSpecificationAsRows()
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
            db.VideoGameEntity.Add(new VideoGameEntity { Id = "g1", OriginalTitle = "Game", Details = "game details" });
            db.TechnicalSpecificationEntity.Add(new TechnicalSpecificationEntity { Id = "spec1", VideoGameId = "g1", NoOfPlayersOffline = "2", GermanAnnotation = "Lokaler Mehrspieler", Notes = "private note" });
            await db.SaveChangesAsync();
        }

        var result = await provider.GetRequiredService<IVideoGameExportReader>().GetAsync("g1");

        Assert.NotNull(result);
        Assert.Equal("game details", result!.Details);
        var specification = Assert.Single(result.RelatedData, row => row.Table == "TechnicalSpecification");
        Assert.Equal("spec1", specification.Id);
        Assert.Equal("2", specification.Fields["NoOfPlayersOffline"]);
        Assert.Equal("Lokaler Mehrspieler", specification.Fields["GermanAnnotation"]);
        Assert.DoesNotContain("Notes", specification.Fields.Keys);
    }

    [Fact]
    public async Task PersonReader_MapsNameAndDetailsAndDoesNotExportNotes()
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
            db.PersonEntity.Add(new PersonEntity { Id = "p1", FirstName = "Ada", LastName = "Lovelace", BirthName = "Augusta Ada King", Details = "mathematician", Notes = "private note" });
            await db.SaveChangesAsync();
        }

        var result = await provider.GetRequiredService<IPersonExportReader>().GetAsync("p1");

        Assert.NotNull(result);
        Assert.Equal("Ada Lovelace", result!.Name.Original);
        Assert.Equal("Augusta Ada King", result.BirthName);
        Assert.Equal("mathematician", result.Details);
        var personRow = Assert.Single(result.RelatedData, row => row.Table == "Person");
        Assert.DoesNotContain("Notes", personRow.Fields.Keys);
        Assert.DoesNotContain("LastUpdated", personRow.Fields.Keys);
        Assert.DoesNotContain("StatusID", personRow.Fields.Keys);
    }

}
