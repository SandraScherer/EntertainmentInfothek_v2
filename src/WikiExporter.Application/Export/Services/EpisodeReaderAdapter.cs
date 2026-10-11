using WikiExporter.Application.Abstractions.Persistence;
using WikiExporter.Application.Abstractions.Export;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export.Services;

/// <summary>Adapts the episode persistence reader to the common export reader interface.</summary>
internal sealed class EpisodeReaderAdapter(IEpisodeExportReader reader) : Adapter<EpisodeExportData>(reader.GetAsync, reader.ReadAllAsync)
{
}
