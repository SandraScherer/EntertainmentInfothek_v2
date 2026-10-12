using WikiExporter.Application.Documents.Builders;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Application.Localization;
using WikiExporter.Domain.Export;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace WikiExporter.Application.Tests;

/// <summary>Represents remaining document builder tests.</summary>
public sealed class RemainingDocumentBuilderTests
{
/// <summary>Stores selector for use by this component.</summary>
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
/// <summary>Initializes this export row data instance.</summary>
            new ExportRowData("Profession", "prof1", new Dictionary<string,string?> { ["OriginalName"]="Actor" }, new Dictionary<string,string?>())
        };
        var data = new PersonExportData("p1", new("Max", "Max Mustermann", "Max Mustermann"), null, null, null, null, null, null, null, null, null, rows);
        var doc = new PersonDocumentBuilder(Selector).Build(data, ExportLanguage.English);
        Assert.Contains(doc.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Person" && x.TargetId == "p2");
        Assert.Contains(doc.Blocks.OfType<LinkBlock>(), x => x.TargetType == "Profession" && x.TargetId == "prof1");
    }
}
