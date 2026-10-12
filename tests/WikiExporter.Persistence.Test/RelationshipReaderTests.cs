using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WikiExporter.Persistence.DbContext;

namespace WikiExporter.Persistence.Test
{
    [TestClass]
    public sealed class RelationshipReaderTests
    {
        //[TestMethod]
        //public async Task SeriesReader_LoadsEpisodeReferencesWithoutEmbeddingFullEpisodes()
        //{
        //    await using var connection = new SqliteConnection("Data Source=:memory:");
        //    await connection.OpenAsync();
        //    var services = new ServiceCollection();
        //    services.AddWikiExporterPersistence("Data Source=:memory:");

        //    // The production registration creates its own connection. For a stable in-memory test
        //    // we instead register a factory bound to the connection opened above.
        //    services.AddPooledDbContextFactory<EntertainmentInfothekDbContext>(o => o.UseSqlite(connection));

        //    await using var provider = services.BuildServiceProvider();
        //    await using (var db = provider.GetRequiredService<IDbContextFactory<EntertainmentInfothekDbContext>>().CreateDbContext())
        //    {
        //        await db.Database.EnsureCreatedAsync();
        //        db.SeriesEntity.Add(new Persistence.Entities.SeriesEntity { Id = "s1", OriginalTitle = "Series" });
        //        db.EpisodeEntity.Add(new Persistence.Entities.EpisodeEntity { Id = "e1", SeriesId = "s1", OriginalTitle = "Pilot", SeasonNo = "1", EpisodeNo = "1" });
        //        await db.SaveChangesAsync();
        //    }

        //    var reader = provider.GetRequiredService<ISeriesExportReader>();
        //    var result = await reader.GetAsync("s1");

        //    Assert.IsNotNull(result);

        //    var episode = Assert.Single(result!.Episodes);
        //    Assert.AreEqual("e1", episode.Id);
        //    Assert.AreEqual("1", episode.SeasonNo);
        //    Assert.AreEqual("1", episode.EpisodeNo);
        //}
    }
}
