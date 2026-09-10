using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace WikiExporter.Application.Tests;

public sealed class DocumentBuilderTests
{
    private static ExportRowData Row(string table, string id, IDictionary<string,string?>? fields = null, IDictionary<string,string?>? fks = null, string? order = null)
        => new(table, id, fields ?? new Dictionary<string,string?>(), fks ?? new Dictionary<string,string?>(), order);

    [Fact]
    public void MovieBuilder_UsesSemanticCastAndAwardsSections()
    {
        var rows = new[]
        {
            Row("Person", "p1", new Dictionary<string,string?> { ["FirstName"]="Max", ["LastName"]="Mustermann" }),
            Row("Award", "a1", new Dictionary<string,string?> { ["OriginalName"]="Award Name" }),
            Row("Movie_Cast", "c1", new Dictionary<string,string?> { ["EnglishRole"]="Hero", ["Order"]="1" }, new Dictionary<string,string?> { ["ActorID"]="p1" }, "1"),
            Row("Movie_Award", "ma1", new Dictionary<string,string?> { ["Category"]="Best Actor", ["Winner"]="1", ["AwardID"]="a1" }, new Dictionary<string,string?> { ["AwardID"]="a1" }),
            Row("Movie_Award_Person", "map1", new Dictionary<string,string?> { ["EnglishRole"]="Lead" }, new Dictionary<string,string?> { ["Movie_AwardID"]="ma1", ["PersonID"]="p1" })
        };
        var movie = new MovieExportData("m1", new("Original", "English title", "Deutscher Titel"), "type", null, null, null, null, "Details", rows);
        var document = new MovieDocumentBuilder(new LocalizedValueSelector()).Build(movie, ExportLanguage.German);

        Assert.Contains(document.Blocks, b => b is HeadingBlock h && h.Text == "Cast");
        Assert.Contains(document.Blocks, b => b is HeadingBlock h && h.Text == "Awards");
        Assert.Contains(document.Blocks, b => b is LinkBlock l && l.TargetType == "Person" && l.TargetId == "p1");
        Assert.DoesNotContain(document.Blocks, b => b is HeadingBlock h && h.Text == "Movie Cast");
    }

    [Fact]
    public void BookBuilder_EmbedsPublications()
    {
        var rows = new[]
        {
            Row("Publication", "pub1", new Dictionary<string,string?> { ["EnglishTitle"]="Special Edition", ["ISBN13"]="123", ["NoOfPages"]="500", ["BookID"]="b1" }),
            Row("Publication_Certification", "pc1", new Dictionary<string,string?>(), new Dictionary<string,string?> { ["PublicationID"]="pub1", ["CertificationID"]="cert1" }),
            Row("Certification", "cert1", new Dictionary<string,string?> { ["OriginalName"]="Age 12" })
        };
        var book = new BookExportData("b1", new("Original", "English", "Deutsch"), "type", null, null, rows);
        var document = new BookDocumentBuilder(new LocalizedValueSelector()).Build(book, ExportLanguage.English);

        Assert.Contains(document.Blocks, b => b is HeadingBlock h && h.Text == "Publications");
        Assert.Contains(document.Blocks, b => b is HeadingBlock h && h.Text == "Special Edition");
        Assert.Contains(document.Blocks, b => b is LinkBlock l && l.TargetType == "Certification" && l.TargetId == "cert1");
    }

    [Fact]
    public void VideoGameBuilder_RendersTechnicalSpecificationsAsDedicatedSection()
    {
        var rows = new[]
        {
            Row("TechnicalSpecification", "ts1", new Dictionary<string,string?> { ["NoOfPlayersOnline"]="8", ["EnglishAnnotation"]="Online multiplayer" }),
            Row("TechnicalSpecification_SupportedDriver", "td1", new Dictionary<string,string?>(), new Dictionary<string,string?> { ["TechnicalSpecificationID"]="ts1", ["SupportedDriverID"]="driver1" })
        };
        var game = new VideoGameExportData("g1", new("Original", "Game", "Spiel"), null, null, null, null, null, null, rows);
        var document = new VideoGameDocumentBuilder(new LocalizedValueSelector()).Build(game, ExportLanguage.English);

        Assert.Contains(document.Blocks, b => b is HeadingBlock h && h.Text == "Technical Specifications");
        Assert.Contains(document.Blocks, b => b is HeadingBlock h && h.Level == 4 && h.Text == "Supported Driver");
    }

    [Fact]
    public void ConnectionBuilder_CreatesLinksForParentChildrenAndWorks()
    {
        var data = new ConnectionExportData("c1", new("Original", "Universe", "Universum"), "parent", "details",
            new[] { new EntityReference("child", "Child") },
            new[] { new WorkReference("Movie", "m1", new("Film", "Movie", "Film")) },
            Array.Empty<ExportRowData>());
        var document = new ConnectionDocumentBuilder(new LocalizedValueSelector()).Build(data, ExportLanguage.German);

        Assert.Equal(3, document.Blocks.OfType<LinkBlock>().Count());
        Assert.Contains(document.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Connection" && x.TargetId == "parent");
        Assert.Contains(document.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Movie" && x.TargetId == "m1");
    }
}

public sealed partial class DocumentBuilderCoverageTests
{
    [Fact]
    public void AllSevenDocumentBuilders_AreRegisteredAndResolvable()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddWikiExporterApplication();
        using var provider = services.BuildServiceProvider();
        var resolver = provider.GetRequiredService<IDocumentBuilderResolver>();

        foreach (var type in Enum.GetValues<ExportEntityType>())
            Assert.Equal(type, resolver.Resolve(type).EntityType);
    }
}

public sealed class RemainingDocumentBuilderTests
{
    private static readonly ILocalizedValueSelector Selector = new LocalizedValueSelector();

    [Fact]
    public void SeriesBuilder_RendersEpisodeReferencesAsLinks()
    {
        var data = new SeriesExportData("s1", new("Original", "Series", "Serie"), null, "3", "30", null, null,
            new[] { new EpisodeReference("e1", new("Episode", "Episode EN", "Episode DE"), "1", "2") }, Array.Empty<ExportRowData>());
        var doc = new SeriesDocumentBuilder(Selector).Build(data, ExportLanguage.German);
        Assert.Contains(doc.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Episode" && x.TargetId == "e1" && x.Text.Contains("Episode DE"));
    }

    [Fact]
    public void EpisodeBuilder_RendersSeriesReference()
    {
        var rows = new[] { new ExportRowData("Series", "s1", new Dictionary<string,string?> { ["EnglishTitle"]="Series EN", ["GermanTitle"]="Serie DE" }, new Dictionary<string,string?>()) };
        var data = new EpisodeExportData("e1", new("Original", "Episode EN", "Episode DE"), "s1", "1", "2", null, rows);
        var doc = new EpisodeDocumentBuilder(Selector).Build(data, ExportLanguage.German);
        Assert.Contains(doc.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Series" && x.TargetId == "s1" && x.Text == "Serie DE");
    }

    [Fact]
    public void PersonBuilder_RendersFamilyAndProfessionRelations()
    {
        var rows = new[]
        {
            new ExportRowData("Person", "p2", new Dictionary<string,string?> { ["FirstName"]="Jane", ["LastName"]="Doe" }, new Dictionary<string,string?>()),
            new ExportRowData("Person_Family", "f1", new Dictionary<string,string?> { ["EnglishRole"]="Sister" }, new Dictionary<string,string?> { ["FamilyID"]="p2", ["RelationshipID"]="rel1" }),
            new ExportRowData("Person_Profession", "pr1", new Dictionary<string,string?>(), new Dictionary<string,string?> { ["ProfessionID"]="prof1" }),
            new ExportRowData("Profession", "prof1", new Dictionary<string,string?> { ["OriginalName"]="Actor" }, new Dictionary<string,string?>())
        };
        var data = new PersonExportData("p1", new("Max", "Max Mustermann", "Max Mustermann"), null, null, null, null, null, null, null, null, null, rows);
        var doc = new PersonDocumentBuilder(Selector).Build(data, ExportLanguage.English);
        Assert.Contains(doc.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Person" && x.TargetId == "p2");
        Assert.Contains(doc.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Profession" && x.TargetId == "prof1");
    }
}
