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


    [Fact]
    public async Task SeriesReader_OrdersEpisodeReferencesAndKeepsThemAsLightweightReferences()
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
            db.SeriesEntity.Add(new SeriesEntity { Id = "s-order", OriginalTitle = "Ordered Series" });
            db.EpisodeEntity.AddRange(
                new EpisodeEntity { Id = "e3", SeriesId = "s-order", OriginalTitle = "Second Season", SeasonNo = "2", EpisodeNo = "1", Details = "episode details" },
                new EpisodeEntity { Id = "e2", SeriesId = "s-order", OriginalTitle = "Second Episode", SeasonNo = "1", EpisodeNo = "2" },
                new EpisodeEntity { Id = "e1", SeriesId = "s-order", OriginalTitle = "First Episode", SeasonNo = "1", EpisodeNo = "1" });
            await db.SaveChangesAsync();
        }

        var result = await provider.GetRequiredService<ISeriesExportReader>().GetAsync("s-order");

        Assert.NotNull(result);
        Assert.Equal(new[] { "e1", "e2", "e3" }, result!.Episodes.Select(x => x.Id));
        Assert.Equal(new[] { "First Episode", "Second Episode", "Second Season" }, result.Episodes.Select(x => x.Title.Original));
        Assert.Equal(new[] { "1", "1", "2" }, result.Episodes.Select(x => x.SeasonNo));
    }

    [Fact]
    public async Task EpisodeReader_ReadAllUsesStableBatchesAndExcludesNotesAndTrackingColumns()
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
            db.SeriesEntity.Add(new SeriesEntity { Id = "s-episode", OriginalTitle = "Parent Series" });
            db.EpisodeEntity.AddRange(
                new EpisodeEntity { Id = "e2", SeriesId = "s-episode", OriginalTitle = "Second", SeasonNo = "1", EpisodeNo = "2", Details = "visible details", Notes = "private note", LastUpdated = "2025-01-01" },
                new EpisodeEntity { Id = "e1", SeriesId = "s-episode", OriginalTitle = "First", SeasonNo = "1", EpisodeNo = "1" });
            await db.SaveChangesAsync();
        }

        var actual = new List<EpisodeExportData>();
        await foreach (var item in provider.GetRequiredService<IEpisodeExportReader>().ReadAllAsync(new BatchOptions(1)))
            actual.Add(item);

        Assert.Equal(new[] { "e1", "e2" }, actual.Select(x => x.Id));
        var episode = Assert.Single(actual, x => x.Id == "e2");
        Assert.Equal("s-episode", episode.SeriesId);
        Assert.Equal("visible details", episode.Details);
        var row = Assert.Single(episode.RelatedData, x => x.Table == "Episode");
        Assert.DoesNotContain("Notes", row.Fields.Keys);
        Assert.DoesNotContain("StatusID", row.Fields.Keys);
        Assert.DoesNotContain("LastUpdated", row.Fields.Keys);
    }


    [Fact]
    public async Task AllSevenReaders_ReadAllUseStableIdOrderAcrossSmallBatches()
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
            db.MovieEntity.AddRange(new MovieEntity { Id = "m3", OriginalTitle = "Third" }, new MovieEntity { Id = "m1", OriginalTitle = "First" }, new MovieEntity { Id = "m2", OriginalTitle = "Second" });
            db.SeriesEntity.AddRange(new SeriesEntity { Id = "s3", OriginalTitle = "Third" }, new SeriesEntity { Id = "s1", OriginalTitle = "First" }, new SeriesEntity { Id = "s2", OriginalTitle = "Second" });
            db.EpisodeEntity.AddRange(new EpisodeEntity { Id = "e3", OriginalTitle = "Third" }, new EpisodeEntity { Id = "e1", OriginalTitle = "First" }, new EpisodeEntity { Id = "e2", OriginalTitle = "Second" });
            db.BookEntity.AddRange(new BookEntity { Id = "b3", OriginalTitle = "Third" }, new BookEntity { Id = "b1", OriginalTitle = "First" }, new BookEntity { Id = "b2", OriginalTitle = "Second" });
            db.VideoGameEntity.AddRange(new VideoGameEntity { Id = "g3", OriginalTitle = "Third" }, new VideoGameEntity { Id = "g1", OriginalTitle = "First" }, new VideoGameEntity { Id = "g2", OriginalTitle = "Second" });
            db.PersonEntity.AddRange(new PersonEntity { Id = "p3", FirstName = "Third" }, new PersonEntity { Id = "p1", FirstName = "First" }, new PersonEntity { Id = "p2", FirstName = "Second" });
            db.ConnectionEntity.AddRange(new ConnectionEntity { Id = "c3", OriginalName = "Third" }, new ConnectionEntity { Id = "c1", OriginalName = "First" }, new ConnectionEntity { Id = "c2", OriginalName = "Second" });
            await db.SaveChangesAsync();
        }

        static async Task<string[]> Ids<T>(IAsyncEnumerable<T> stream, Func<T, string> getId)
        {
            var values = new List<string>();
            await foreach (var value in stream) values.Add(getId(value));
            return values.ToArray();
        }

        var batch = new BatchOptions(1);
        Assert.Equal(new[] { "m1", "m2", "m3" }, await Ids(provider.GetRequiredService<IMovieExportReader>().ReadAllAsync(batch), x => x.Id));
        Assert.Equal(new[] { "s1", "s2", "s3" }, await Ids(provider.GetRequiredService<ISeriesExportReader>().ReadAllAsync(batch), x => x.Id));
        Assert.Equal(new[] { "e1", "e2", "e3" }, await Ids(provider.GetRequiredService<IEpisodeExportReader>().ReadAllAsync(batch), x => x.Id));
        Assert.Equal(new[] { "b1", "b2", "b3" }, await Ids(provider.GetRequiredService<IBookExportReader>().ReadAllAsync(batch), x => x.Id));
        Assert.Equal(new[] { "g1", "g2", "g3" }, await Ids(provider.GetRequiredService<IVideoGameExportReader>().ReadAllAsync(batch), x => x.Id));
        Assert.Equal(new[] { "p1", "p2", "p3" }, await Ids(provider.GetRequiredService<IPersonExportReader>().ReadAllAsync(batch), x => x.Id));
        Assert.Equal(new[] { "c1", "c2", "c3" }, await Ids(provider.GetRequiredService<IConnectionExportReader>().ReadAllAsync(batch), x => x.Id));
    }

    [Fact]
    public async Task AllSevenReaders_RespectCancellationBeforeStartingReadAll()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var services = new ServiceCollection();
        services.AddWikiExporterPersistence("Data Source=:memory:");
        services.AddPooledDbContextFactory<EntertainmentInfothekDbContext>(o => o.UseSqlite(connection));
        await using var provider = services.BuildServiceProvider();
        await using (var db = provider.GetRequiredService<IDbContextFactory<EntertainmentInfothekDbContext>>().CreateDbContext())
            await db.Database.EnsureCreatedAsync();

        using var source = new CancellationTokenSource();
        source.Cancel();
        var ct = source.Token;
        static async Task AssertCanceled<T>(IAsyncEnumerable<T> stream, CancellationToken token)
        {
            await using var enumerator = stream.GetAsyncEnumerator(token);
            await Assert.ThrowsAnyAsync<OperationCanceledException>(async () => await enumerator.MoveNextAsync());
        }

        var batch = new BatchOptions(2);
        await AssertCanceled(provider.GetRequiredService<IMovieExportReader>().ReadAllAsync(batch, ct), ct);
        await AssertCanceled(provider.GetRequiredService<ISeriesExportReader>().ReadAllAsync(batch, ct), ct);
        await AssertCanceled(provider.GetRequiredService<IEpisodeExportReader>().ReadAllAsync(batch, ct), ct);
        await AssertCanceled(provider.GetRequiredService<IBookExportReader>().ReadAllAsync(batch, ct), ct);
        await AssertCanceled(provider.GetRequiredService<IVideoGameExportReader>().ReadAllAsync(batch, ct), ct);
        await AssertCanceled(provider.GetRequiredService<IPersonExportReader>().ReadAllAsync(batch, ct), ct);
        await AssertCanceled(provider.GetRequiredService<IConnectionExportReader>().ReadAllAsync(batch, ct), ct);
    }


    [Fact]
    public async Task MovieReader_ScopesRootAndRelatedRowsToEachMovieWhenBatchContainsMultipleMovies()
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
                new MovieEntity { Id = "m1", OriginalTitle = "Movie One", Notes = "private one" },
                new MovieEntity { Id = "m2", OriginalTitle = "Movie Two", Notes = "private two" });
            db.GenreEntity.AddRange(
                new GenreEntity { Id = "genre1", EnglishName = "Drama" },
                new GenreEntity { Id = "genre2", EnglishName = "Comedy" });
            db.MovieGenreEntity.AddRange(
                new MovieGenreEntity { Id = "mg1", MovieId = "m1", GenreId = "genre1", Details = "first relationship" },
                new MovieGenreEntity { Id = "mg2", MovieId = "m2", GenreId = "genre2", Details = "second relationship" });
            await db.SaveChangesAsync();
        }

        var movies = new List<MovieExportData>();
        await foreach (var movie in provider.GetRequiredService<IMovieExportReader>().ReadAllAsync(new BatchOptions(2)))
            movies.Add(movie);

        var first = Assert.Single(movies, x => x.Id == "m1");
        Assert.Equal("Movie One", first.Title.Original);
        Assert.DoesNotContain(first.RelatedData, x => x.Table == "Movie" && x.Id == "m2");
        var firstGenre = Assert.Single(first.RelatedData, x => x.Table == "Movie_Genre");
        Assert.Equal("mg1", firstGenre.Id);
        Assert.Equal("first relationship", firstGenre.Fields["Details"]);
        Assert.DoesNotContain("Notes", firstGenre.Fields.Keys);

        var second = Assert.Single(movies, x => x.Id == "m2");
        Assert.Equal("Movie Two", second.Title.Original);
        Assert.DoesNotContain(second.RelatedData, x => x.Table == "Movie" && x.Id == "m1");
        var secondGenre = Assert.Single(second.RelatedData, x => x.Table == "Movie_Genre");
        Assert.Equal("mg2", secondGenre.Id);
        Assert.Equal("second relationship", secondGenre.Fields["Details"]);
    }

    [Fact]
    public async Task VideoGameReader_ScopesTechnicalSpecificationsToTheirOwningGameAcrossBatch()
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
            db.VideoGameEntity.AddRange(
                new VideoGameEntity { Id = "g1", OriginalTitle = "Game One" },
                new VideoGameEntity { Id = "g2", OriginalTitle = "Game Two" });
            db.TechnicalSpecificationEntity.AddRange(
                new TechnicalSpecificationEntity { Id = "spec1", VideoGameId = "g1", NoOfPlayersOffline = "1" },
                new TechnicalSpecificationEntity { Id = "spec2", VideoGameId = "g2", NoOfPlayersOffline = "4" });
            await db.SaveChangesAsync();
        }

        var games = new List<VideoGameExportData>();
        await foreach (var game in provider.GetRequiredService<IVideoGameExportReader>().ReadAllAsync(new BatchOptions(2)))
            games.Add(game);

        var first = Assert.Single(games, x => x.Id == "g1");
        var firstSpec = Assert.Single(first.RelatedData, x => x.Table == "TechnicalSpecification");
        Assert.Equal("spec1", firstSpec.Id);
        Assert.Equal("1", firstSpec.Fields["NoOfPlayersOffline"]);

        var second = Assert.Single(games, x => x.Id == "g2");
        var secondSpec = Assert.Single(second.RelatedData, x => x.Table == "TechnicalSpecification");
        Assert.Equal("spec2", secondSpec.Id);
        Assert.Equal("4", secondSpec.Fields["NoOfPlayersOffline"]);
    }

}
