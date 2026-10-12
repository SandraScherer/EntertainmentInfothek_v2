using WikiExporter.Application.Documents.Models;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export;

/// <summary>Represents i export reader resolver.</summary>
public interface IExportReaderResolver
{
    IExportReaderAdapter Resolve(ExportEntityType type);
}
