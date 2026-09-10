namespace WikiExporter.Application.Exceptions;

/// <summary>
/// Movie wurde nicht gefunden.
/// </summary>
public sealed class MovieNotFoundException
    : Exception
{
    public MovieNotFoundException(
        string movieId)
        : base(
            $"Movie '{movieId}' was not found.")
    {
    }
}
