using WikiExporter.Application.DTOs;

namespace WikiExporter.Application.Interfaces;

public interface IMovieRepository
{
    Task<MovieExportDto> GetForExportAsync(
        string movieId,
        CancellationToken cancellationToken);
}
