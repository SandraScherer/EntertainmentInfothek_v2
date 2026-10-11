using WikiExporter.Application.Persistence;
using WikiExporter.Application.Abstractions.Export;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export.Services;

/// <summary>Adapts the series persistence reader to the common export reader interface.</summary>
internal sealed class SeriesReaderAdapter(ISeriesExportReader reader) : Adapter<SeriesExportData>(reader.GetAsync, reader.ReadAllAsync)
{
}
