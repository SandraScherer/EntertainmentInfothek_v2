using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Represents i document builder resolver.</summary>
public interface IDocumentBuilderResolver
{
    IDocumentBuilder Resolve(ExportEntityType type);
}
