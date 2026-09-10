using WikiExporter.Application.Exceptions;
using WikiExporter.Application.Models;

namespace WikiExporter.Application.Validation;

public static class ExportRequestValidator
{
    public static void Validate(
        ExportRequest request)
    {
        if (request is null)
        {
            throw new ValidationException(
                "Export request is null.");
        }

        if (string.IsNullOrWhiteSpace(
            request.RecordId))
        {
            throw new ValidationException(
                "Movie ID is required.");
        }

        if (string.IsNullOrWhiteSpace(
            request.OutputFolder))
        {
            throw new ValidationException(
                "Output folder is required.");
        }

        if (string.IsNullOrWhiteSpace(
            request.Language))
        {
            throw new ValidationException(
                "Language is required.");
        }
    }
}
