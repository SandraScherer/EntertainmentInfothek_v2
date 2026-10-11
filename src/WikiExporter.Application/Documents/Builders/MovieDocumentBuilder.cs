using System.Globalization;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Documents.Builders;

/// <summary>Defines the movie document builder type.</summary>
public sealed class MovieDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
/// <summary>Stores the entity type value.</summary>
    public ExportEntityType EntityType => ExportEntityType.Movie;
/// <summary>Executes the build operation.</summary>
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (MovieExportData)data; var title = Title(d.Title, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        AddConnections(blocks, d, language);
        blocks.Add(new HeadingBlock(2, "General"));
        blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(("ID", d.Id), ("Type", d.TypeId), ("Budget", d.Budget), ("Worldwide gross", d.WorldwideGross), ("Worldwide gross date", d.WorldwideGrossDate))));
        AddCommonMediaSections(blocks, d.RelatedData, language);
        AddDetails(blocks, d.Details);
        return new("Movie", d.Id, Metadata("Movie", d.Id, title), blocks);
    }
}
