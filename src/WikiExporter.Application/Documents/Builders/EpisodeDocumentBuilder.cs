using System.Globalization;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Documents.Builders;

/// <summary>Defines the episode document builder type.</summary>
public sealed class EpisodeDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
/// <summary>Stores the entity type value.</summary>
    public ExportEntityType EntityType => ExportEntityType.Episode;
/// <summary>Executes the build operation.</summary>
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (EpisodeExportData)data; var title = Title(d.Title, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        if (!string.IsNullOrWhiteSpace(d.SeriesId)) { blocks.Add(new HeadingBlock(2, "Series")); blocks.Add(new LinkBlock(ReferenceName(d.RelatedData, "Series", d.SeriesId!, language), "Series", d.SeriesId!)); }
        blocks.Add(new HeadingBlock(2, "Episode Information"));
        blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(("ID", d.Id), ("Season", d.SeasonNo), ("Episode", d.EpisodeNo))));
        AddCommonMediaSections(blocks, d.RelatedData, language);
        AddDetails(blocks, d.Details);
        return new("Episode", d.Id, Metadata("Episode", d.Id, title), blocks);
    }
}
