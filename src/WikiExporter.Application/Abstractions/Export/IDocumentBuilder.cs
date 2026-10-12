using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Represents i document builder.</summary>
public interface IDocumentBuilder
{
    ExportEntityType EntityType { get; }
    MarkdownDocument Build(ExportDataBase data, ExportLanguage language);
}
