using System.Globalization;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Documents.Builders;

/// <summary>Defines the video game document builder type.</summary>
public sealed class VideoGameDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
/// <summary>Stores the entity type value.</summary>
    public ExportEntityType EntityType => ExportEntityType.VideoGame;
/// <summary>Executes the build operation.</summary>
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (VideoGameExportData)data; var title = Title(d.Title, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        AddConnections(blocks, d, language);
        blocks.Add(new HeadingBlock(2, "General"));
        blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(("ID", d.Id), ("Type", d.TypeId), ("Budget", d.Budget), ("Worldwide gross", d.WorldwideGross), ("Worldwide gross date", d.WorldwideGrossDate))));
        AddTechnicalSpecifications(blocks, d.RelatedData, language);
        AddCommonMediaSections(blocks, d.RelatedData, language);
        AddDetails(blocks, d.Details);
        return new("VideoGame", d.Id, Metadata("VideoGame", d.Id, title), blocks);
    }
}
