using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Defines the i document builder type.</summary>
public interface IDocumentBuilder
{
    ExportEntityType EntityType { get; }
    MarkdownDocument Build(ExportDataBase data, ExportLanguage language);
}
