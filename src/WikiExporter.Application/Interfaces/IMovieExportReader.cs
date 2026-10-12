using WikiExporter.Application.DTOs;

namespace WikiExporter.Application.Interfaces;

public interface IMovieExportReader
{
    Task<MovieExportData> GetForExportAsync(
        string movieId,
        CancellationToken cancellationToken);
}
