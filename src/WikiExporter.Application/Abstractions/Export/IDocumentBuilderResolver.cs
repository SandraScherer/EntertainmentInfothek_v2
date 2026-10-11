using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Defines the i document builder resolver type.</summary>
public interface IDocumentBuilderResolver
{
    IDocumentBuilder Resolve(ExportEntityType type);
}
