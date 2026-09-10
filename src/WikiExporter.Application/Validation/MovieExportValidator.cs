using WikiExporter.Application.DTOs;
using WikiExporter.Application.Exceptions;

namespace WikiExporter.Application.Validation;

public static class MovieExportValidator
{
    public static void Validate(
        MovieExportDto dto)
    {
        if (dto is null)
        {
            throw new ValidationException(
                "Movie data is missing.");
        }

        var hasTitle =
               !string.IsNullOrWhiteSpace(
                    dto.GermanTitle)
            || !string.IsNullOrWhiteSpace(
                    dto.EnglishTitle)
            || !string.IsNullOrWhiteSpace(
                    dto.OriginalTitle);

        if (!hasTitle)
        {
            throw new ValidationException(
                "Movie title is missing.");
        }
    }
}
