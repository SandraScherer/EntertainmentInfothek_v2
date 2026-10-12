using Microsoft.EntityFrameworkCore;
using WikiExporter.Persistence.DbContext;

namespace WikiExporter.Persistence.Test;

[TestClass]
public class EfModelAndReaderTests
{
    [TestMethod]
    public void Model_ContainsAllSchemaTablesAndForeignKeys()
    {
        var options = new DbContextOptionsBuilder<EntertainmentInfothekDbContext>()
            .UseSqlite("Data Source=:memory:")
            .Options;
        using var db = new EntertainmentInfothekDbContext(options);
        var tables = db.Model.GetEntityTypes()
            .Select(x => x.GetTableName())
            .Where(x => x is not null)
            .Distinct(StringComparer.Ordinal)
            .ToArray();
        var foreignKeys = db.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()).Count();

        Assert.AreEqual(60, tables.Length);    // 196 ChatGPT
        Assert.AreEqual(148, foreignKeys);      // 547 ChatGPT
    }

    //[TestMethod]
    //public async Task MovieReader_LoadsRootWithoutRequiringLookupRows()
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
    //        db.MovieEntity.Add(
    //            new Persistence.Entities.MovieEntity { Id = "m1", OriginalTitle = "Original", EnglishTitle = "English", GermanTitle = "Deutsch", Details = "Details" });
    //        await db.SaveChangesAsync();
    //    }

    //    var reader = provider.GetRequiredService<IMovieExportReader>();
    //    var result = await reader.GetAsync("m1");

    //    Assert.IsNotNull(result);
    //    Assert.AreEqual("m1", result!.Id);
    //    Assert.AreEqual("English", result.Title.English);
    //}
}
