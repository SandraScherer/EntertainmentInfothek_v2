namespace WikiExporter.Application.Exceptions;

/// <summary>
/// Fehler während des Exports.
/// </summary>
public sealed class ExportFailedException
    : Exception
{
    public ExportFailedException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }
}
