using System.Globalization;
using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Documents.Builders;

/// <summary>Defines the connection document builder type.</summary>
public sealed class ConnectionDocumentBuilder(ILocalizedValueSelector s) : DocumentBuilderBase(s), IDocumentBuilder
{
/// <summary>Stores the entity type value.</summary>
    public ExportEntityType EntityType => ExportEntityType.Connection;
/// <summary>Executes the build operation.</summary>
    public MarkdownDocument Build(ExportDataBase data, ExportLanguage language)
    {
        var d = (ConnectionExportData)data; var title = Title(d.Name, language); var blocks = new List<MarkdownBlock> { new HeadingBlock(1, title) };
        if (!string.IsNullOrWhiteSpace(d.ParentConnectionId)) { blocks.Add(new HeadingBlock(2, "Parent Connection")); blocks.Add(new LinkBlock(d.ParentConnectionId!, "Connection", d.ParentConnectionId!)); }
        if (d.Children.Count > 0)
        {
            blocks.Add(new HeadingBlock(2, "Child Connections"));
            foreach (var child in d.Children.OrderBy(x => x.DisplayName ?? x.Id, StringComparer.Ordinal).ThenBy(x => x.Id, StringComparer.Ordinal)) blocks.Add(new LinkBlock(child.DisplayName ?? child.Id, "Connection", child.Id));
        }
        foreach (var group in d.Works.GroupBy(x => x.Type, StringComparer.Ordinal).OrderBy(g => g.Key, StringComparer.Ordinal))
        {
            blocks.Add(new HeadingBlock(2, group.Key));
            foreach (var work in group.OrderBy(x => Title(x.Title, language), StringComparer.Ordinal).ThenBy(x => x.Id, StringComparer.Ordinal)) blocks.Add(new LinkBlock(Title(work.Title, language), work.Type, work.Id));
        }
        AddDetails(blocks, d.Details);
        return new("Connection", d.Id, Metadata("Connection", d.Id, title), blocks);
    }
}
