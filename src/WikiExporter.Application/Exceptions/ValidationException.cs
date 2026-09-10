namespace WikiExporter.Application.Exceptions;

/// <summary>
/// Fachlicher Validierungsfehler.
/// </summary>
public sealed class ValidationException
    : Exception
{
    public ValidationException(
        string message)
        : base(message)
    {
    }
}
