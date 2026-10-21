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

/// <summary>Integration coverage from a real SQLite schema through application builders to rendered files.</summary>
public sealed class DatabaseToFileExportIntegrationTests
{
    [Theory]
    [InlineData(ExportFormat.Obsidian, "# The Integration Film")]
    [InlineData(ExportFormat.DokuWiki, "====== The Integration Film ======")]
    public async Task SingleMovieExport_ReadsDatabaseBuildsDocumentAndWritesRenderedFile(
        ExportFormat format, string expectedHeading)
    {
        var root = CreateTemporaryDirectory();
        try
        {
            await using var fixture = await CreateFixtureAsync(root);
            await SeedMoviesAsync(fixture, new MovieEntity
            {
                Id = "movie-integration-1",
                OriginalTitle = "The Integration Film",
                EnglishTitle = "The Integration Film",
                GermanTitle = "Der Integrationstest-Film",
                Details = "A description from SQLite.",
                Notes = "This private note must not be exported.",
                LastUpdated = "2025-01-01"
            });

            var useCase = fixture.Services.GetRequiredService<IExportUseCase>();
            var result = await useCase.ExecuteAsync(new ExportRequest(
                ExportEntityType.Movie,
                new ExportScope.Single("movie-integration-1"),
                ExportLanguage.English,
                format));

            Assert.Equal(1, result.RequestedItems);
            Assert.Equal(1, result.SuccessfullyBuilt);
            Assert.Equal(0, result.FailedItems);
            var document = Assert.Single(result.Documents).Document;
            Assert.Equal("movie-integration-1", document.EntityId);

            var exporter = fixture.Services.GetRequiredService<IMarkdownExportService>();
            var rendered = await exporter.ExportAsync(document, format, root);
            var filePath = Path.Combine(root, rendered.RelativePath.Replace('/', Path.DirectorySeparatorChar));
            Assert.True(File.Exists(filePath));
            var fileContent = await File.ReadAllTextAsync(filePath);
            Assert.Equal(rendered.Content, fileContent);
            Assert.Contains(expectedHeading, fileContent);
            Assert.Contains("A description from SQLite.", fileContent);
            Assert.DoesNotContain("This private note must not be exported.", fileContent);
            Assert.EndsWith("\n", fileContent);
            Assert.DoesNotContain('\r', fileContent);
        }
        finally
        {
            DeleteDirectoryIfExists(root);
        }
    }

    [Fact]
    public async Task ExportAllMovies_UsesStableBatchesAndWritesEveryDocument()
    {
        var root = CreateTemporaryDirectory();
        try
        {
            await using var fixture = await CreateFixtureAsync(root);
            await SeedMoviesAsync(fixture,
                new MovieEntity { Id = "movie-c", OriginalTitle = "Third Film", EnglishTitle = "Third Film" },
                new MovieEntity { Id = "movie-a", OriginalTitle = "First Film", EnglishTitle = "First Film" },
                new MovieEntity { Id = "movie-b", OriginalTitle = "Second Film", EnglishTitle = "Second Film" });

            var useCase = fixture.Services.GetRequiredService<IExportUseCase>();
            var result = await useCase.ExecuteAsync(new ExportRequest(
                ExportEntityType.Movie,
                new ExportScope.All(BatchSize: 1),
                ExportLanguage.English,
                ExportFormat.Obsidian));

            Assert.Equal(3, result.RequestedItems);
            Assert.Equal(3, result.SuccessfullyBuilt);
            Assert.Equal(0, result.FailedItems);
            Assert.Equal(new[] { "movie-a", "movie-b", "movie-c" }, result.Documents.Select(x => x.EntityId));

            var exporter = fixture.Services.GetRequiredService<IMarkdownExportService>();
            var paths = new List<string>();
            foreach (var exported in result.Documents)
            {
                var rendered = await exporter.ExportAsync(exported.Document, ExportFormat.Obsidian, root);
                paths.Add(rendered.RelativePath);
                var fullPath = Path.Combine(root, rendered.RelativePath.Replace('/', Path.DirectorySeparatorChar));
                Assert.True(File.Exists(fullPath));
                Assert.Equal(rendered.Content, await File.ReadAllTextAsync(fullPath));
            }

            Assert.Equal(3, paths.Distinct(StringComparer.Ordinal).Count());
            Assert.Equal(3, Directory.GetFiles(root, "*.md", SearchOption.AllDirectories).Length);
        }
        finally
        {
            DeleteDirectoryIfExists(root);
        }
    }

    [Fact]
    public async Task SingleMovieExport_ReportsMissingDatabaseEntityWithoutWritingFile()
    {
        var root = CreateTemporaryDirectory();
        try
        {
            await using var fixture = await CreateFixtureAsync(root);
            var result = await fixture.Services.GetRequiredService<IExportUseCase>().ExecuteAsync(
                new ExportRequest(ExportEntityType.Movie, new ExportScope.Single("missing-id"), ExportLanguage.Original));

            Assert.Equal(1, result.RequestedItems);
            Assert.Equal(0, result.SuccessfullyBuilt);
            Assert.Equal(1, result.FailedItems);
            Assert.Empty(result.Documents);
            Assert.Equal("missing-id", Assert.Single(result.Errors).EntityId);
            Assert.Empty(Directory.GetFiles(root, "*.md", SearchOption.AllDirectories));
        }
        finally
        {
            DeleteDirectoryIfExists(root);
        }
    }

    private static async Task<IntegrationFixture> CreateFixtureAsync(string outputDirectory)
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddWikiExporterApplication();
        services.AddWikiExporterPersistence("Data Source=:memory:");
        // Keep the in-memory database alive and shared by all contexts for the fixture lifetime.
        services.AddPooledDbContextFactory<EntertainmentInfothekDbContext>(options => options.UseSqlite(connection));
        services.AddWikiExporterExport();
        var provider = services.BuildServiceProvider();

        await using (var db = provider.GetRequiredService<IDbContextFactory<EntertainmentInfothekDbContext>>().CreateDbContext())
        {
            await db.Database.EnsureCreatedAsync();
        }

        return new IntegrationFixture(connection, provider);
    }

    private static async Task SeedMoviesAsync(IntegrationFixture fixture, params MovieEntity[] movies)
    {
        await using var db = fixture.Services
            .GetRequiredService<IDbContextFactory<EntertainmentInfothekDbContext>>()
            .CreateDbContext();
        db.MovieEntity.AddRange(movies);
        await db.SaveChangesAsync();
    }

    private static string CreateTemporaryDirectory()
    {
        var path = Path.Combine(Path.GetTempPath(), "WikiExporterDbIntegration", Guid.NewGuid().ToString("N"));
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
