using WikiExporter.Application.DTOs;

namespace WikiExporter.Application.Interfaces;

public interface IMovieRepository
{
    Task<MovieExportData> GetForExportAsync(
        string movieId,
        CancellationToken cancellationToken);
}
