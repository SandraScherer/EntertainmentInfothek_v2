using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WikiExporter.Application.DependencyInjection;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Export.DependencyInjection;
using WikiExporter.Export.Markdown;
using WikiExporter.Persistence.DbContext;
using WikiExporter.Persistence.DependencyInjection;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Export.Tests;

/// <summary>Exercises the remaining entity readers, builders, renderers and file writer against SQLite.</summary>
public sealed class RemainingEntityDatabaseIntegrationTests
{
    public static TheoryData<ExportEntityType, string, string> EntityCases => new()
    {
        { ExportEntityType.Series, "series-integration-1", "The Integration Series" },
        { ExportEntityType.Episode, "episode-integration-1", "The Integration Episode" },
        { ExportEntityType.Book, "book-integration-1", "The Integration Book" },
        { ExportEntityType.VideoGame, "game-integration-1", "The Integration Game" },
        { ExportEntityType.Person, "person-integration-1", "Ada Integration" },
        { ExportEntityType.Connection, "connection-integration-1", "Integration Universe" }
    };

    [Theory]
    [MemberData(nameof(EntityCases))]
    public async Task SingleEntityExport_ReadsSqliteBuildsDocumentAndWritesFile(
        ExportEntityType entityType, string entityId, string expectedTitle)
    {
        var root = CreateTemporaryDirectory();
        try
        {
            await using var fixture = await CreateFixtureAsync();
            await SeedEntityAsync(fixture, entityType, entityId);

            var useCase = fixture.Services.GetRequiredService<IExportUseCase>();
            var result = await useCase.ExecuteAsync(new ExportRequest(
                entityType,
                new ExportScope.Single(entityId),
                ExportLanguage.English,
                ExportFormat.Obsidian));

            Assert.Equal(1, result.RequestedItems);
            Assert.Equal(1, result.SuccessfullyBuilt);
            Assert.Equal(0, result.FailedItems);
            var exported = Assert.Single(result.Documents);
            Assert.Equal(entityId, exported.EntityId);
            Assert.Equal(entityId, exported.Document.EntityId);

            var markdown = await fixture.Services.GetRequiredService<IMarkdownExportService>()
                .ExportAsync(exported.Document, ExportFormat.Obsidian, root);
            var fullPath = Path.Combine(root, markdown.RelativePath.Replace('/', Path.DirectorySeparatorChar));
            Assert.True(File.Exists(fullPath), $"Expected file for {entityType} at {fullPath}.");
            var content = await File.ReadAllTextAsync(fullPath);
            Assert.Equal(markdown.Content, content);
            Assert.Contains(expectedTitle, content, StringComparison.OrdinalIgnoreCase);
            Assert.DoesNotContain("PRIVATE-INTEGRATION-NOTE", content);
            Assert.EndsWith("\n", content);
            Assert.DoesNotContain('\r', content);
        }
        finally
        {
            DeleteDirectoryIfExists(root);
        }
    }

    [Theory]
    [MemberData(nameof(EntityCases))]
    public async Task MissingEntity_ReturnsFailureAndDoesNotCreateMarkdownFile(
        ExportEntityType entityType, string entityId, string _)
    {
        var root = CreateTemporaryDirectory();
        try
        {
            await using var fixture = await CreateFixtureAsync();
            var result = await fixture.Services.GetRequiredService<IExportUseCase>().ExecuteAsync(
                new ExportRequest(entityType, new ExportScope.Single(entityId), ExportLanguage.English));

            Assert.Equal(1, result.RequestedItems);
            Assert.Equal(0, result.SuccessfullyBuilt);
            Assert.Equal(1, result.FailedItems);
            Assert.Empty(result.Documents);
            Assert.Equal(entityId, Assert.Single(result.Errors).EntityId);
            Assert.Empty(Directory.GetFiles(root, "*.md", SearchOption.AllDirectories));
        }
        finally
        {
            DeleteDirectoryIfExists(root);
        }
    }

    private static async Task SeedEntityAsync(IntegrationFixture fixture, ExportEntityType type, string id)
    {
        await using var db = fixture.Services
            .GetRequiredService<IDbContextFactory<EntertainmentInfothekDbContext>>()
            .CreateDbContext();

        switch (type)
        {
            case ExportEntityType.Series:
                db.SeriesEntity.Add(new SeriesEntity { Id = id, OriginalTitle = "The Integration Series", EnglishTitle = "The Integration Series", Details = "Series details from SQLite.", Notes = "PRIVATE-INTEGRATION-NOTE" });
                break;
            case ExportEntityType.Episode:
                db.EpisodeEntity.Add(new EpisodeEntity { Id = id, OriginalTitle = "The Integration Episode", EnglishTitle = "The Integration Episode", SeasonNo = "1", EpisodeNo = "2", Details = "Episode details from SQLite.", Notes = "PRIVATE-INTEGRATION-NOTE" });
                break;
            case ExportEntityType.Book:
                db.BookEntity.Add(new BookEntity { Id = id, OriginalTitle = "The Integration Book", EnglishTitle = "The Integration Book", Details = "Book details from SQLite.", Notes = "PRIVATE-INTEGRATION-NOTE" });
                break;
            case ExportEntityType.VideoGame:
                db.VideoGameEntity.Add(new VideoGameEntity { Id = id, OriginalTitle = "The Integration Game", EnglishTitle = "The Integration Game", Details = "Game details from SQLite.", Notes = "PRIVATE-INTEGRATION-NOTE" });
                break;
            case ExportEntityType.Person:
                db.PersonEntity.Add(new PersonEntity { Id = id, FirstName = "Ada", LastName = "Integration", Details = "Person details from SQLite.", Notes = "PRIVATE-INTEGRATION-NOTE" });
                break;
            case ExportEntityType.Connection:
                db.ConnectionEntity.Add(new ConnectionEntity { Id = id, OriginalName = "Integration Universe", Details = "Connection details from SQLite.", Notes = "PRIVATE-INTEGRATION-NOTE" });
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported integration-test entity type.");
        }

        await db.SaveChangesAsync();
    }

    private static async Task<IntegrationFixture> CreateFixtureAsync()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddWikiExporterApplication();
        services.AddWikiExporterPersistence("Data Source=:memory:");
        // Keep the same in-memory SQLite connection alive for every context in this test.
        services.AddPooledDbContextFactory<EntertainmentInfothekDbContext>(options => options.UseSqlite(connection));
        services.AddWikiExporterExport();
        var provider = services.BuildServiceProvider();

        await using (var db = provider.GetRequiredService<IDbContextFactory<EntertainmentInfothekDbContext>>().CreateDbContext())
            await db.Database.EnsureCreatedAsync();

        return new IntegrationFixture(connection, provider);
    }

    private static string CreateTemporaryDirectory()
    {
        var path = Path.Combine(Path.GetTempPath(), "WikiExporterRemainingEntityIntegration", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(path);
        return path;
    }

    private static void DeleteDirectoryIfExists(string path)
    {
        if (Directory.Exists(path)) Directory.Delete(path, recursive: true);
    }

    private sealed class IntegrationFixture(SqliteConnection connection, ServiceProvider services) : IAsyncDisposable
    {
        public ServiceProvider Services { get; } = services;

        public async ValueTask DisposeAsync()
        {
            await Services.DisposeAsync();
            await connection.DisposeAsync();
        }
    }
}
