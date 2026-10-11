using WikiExporter.Application.Persistence;
using WikiExporter.Application.Abstractions.Export;
using WikiExporter.Domain.Export;

namespace WikiExporter.Application.Export.Services;

/// <summary>Adapts the movie persistence reader to the common export reader interface.</summary>
internal sealed class MovieReaderAdapter(IMovieExportReader reader) : Adapter<MovieExportData>(reader.GetAsync, reader.ReadAllAsync)
{
}
