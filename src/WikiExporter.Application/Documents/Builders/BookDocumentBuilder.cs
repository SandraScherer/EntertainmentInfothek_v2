using System.Globalization;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Documents.Builders;

/// <summary>Represents book document builder.</summary>
public sealed class BookDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
/// <summary>Stores entity type for use by this component.</summary>
    public ExportEntityType EntityType => ExportEntityType.Book;
/// <summary>Performs the build operation.</summary>
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (BookExportData)data; var title = Title(d.Title, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        AddConnections(blocks, d, language);
        blocks.Add(new HeadingBlock(2, "General"));
        blocks.Add(new TableBlock(new[] { "Field", "Value" }, NonEmptyRows(("ID", d.Id), ("Type", d.TypeId))));
        AddCommonMediaSections(blocks, d.RelatedData, language);
        AddPublications(blocks, d.RelatedData, language);
        AddDetails(blocks, d.Details);
        return new("Book", d.Id, Metadata("Book", d.Id, title), blocks);
    }
}
