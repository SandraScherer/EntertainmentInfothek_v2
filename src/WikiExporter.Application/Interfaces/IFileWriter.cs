namespace WikiExporter.Application.Interfaces;

public interface IFileWriter
{
    Task WriteAsync(
        string folder,
        string fileName,
        string content,
        CancellationToken cancellationToken);
}
