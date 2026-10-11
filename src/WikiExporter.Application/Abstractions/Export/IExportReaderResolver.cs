using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Defines the i export reader resolver type.</summary>
public interface IExportReaderResolver
{
    IExportReaderAdapter Resolve(ExportEntityType type);
}
