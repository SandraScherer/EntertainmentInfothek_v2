using System.Globalization;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Documents.Builders;

/// <summary>Defines the series document builder type.</summary>
public sealed class SeriesDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
/// <summary>Stores the entity type value.</summary>
    public ExportEntityType EntityType => ExportEntityType.Series;
/// <summary>Executes the build operation.</summary>
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (SeriesExportData)data; var title = Title(d.Title, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        AddConnections(blocks, d, language);
        blocks.Add(new HeadingBlock(2, "General"));
        blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(("ID", d.Id), ("Type", d.TypeId), ("Seasons", d.NoOfSeasons), ("Episodes", d.NoOfEpisodes))));
        if (d.Episodes.Count > 0)
        {
            blocks.Add(new HeadingBlock(2, "Episodes"));
            foreach (var episode in d.Episodes.OrderBy(x => x.SeasonNo, StringComparer.Ordinal).ThenBy(x => x.EpisodeNo, StringComparer.Ordinal).ThenBy(x => x.Id, StringComparer.Ordinal))
                blocks.Add(new LinkBlock($"{Title(episode.Title, language)} ({episode.SeasonNo}/{episode.EpisodeNo})", "Episode", episode.Id));
        }
        AddCommonMediaSections(blocks, d.RelatedData, language);
        AddDetails(blocks, d.Details);
        return new("Series", d.Id, Metadata("Series", d.Id, title), blocks);
    }
}
