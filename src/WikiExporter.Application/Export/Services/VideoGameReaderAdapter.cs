using WikiExporter.Application.Persistence;
using WikiExporter.Application.Abstractions.Export;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export.Services;

/// <summary>Adapts the game persistence reader to the common export reader interface.</summary>
internal sealed class VideoGameReaderAdapter(IVideoGameExportReader reader) : Adapter<VideoGameExportData>(reader.GetAsync, reader.ReadAllAsync)
{
}
