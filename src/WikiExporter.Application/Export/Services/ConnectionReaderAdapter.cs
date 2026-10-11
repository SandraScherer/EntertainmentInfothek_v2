using WikiExporter.Application.Abstractions.Persistence;
using WikiExporter.Application.Abstractions.Export;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export.Services;

/// <summary>Adapts the connection persistence reader to the common export reader interface.</summary>
internal sealed class ConnectionReaderAdapter(IConnectionExportReader reader) : Adapter<ConnectionExportData>(reader.GetAsync, reader.ReadAllAsync)
{
}
