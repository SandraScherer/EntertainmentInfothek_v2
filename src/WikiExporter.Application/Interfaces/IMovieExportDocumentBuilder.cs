using WikiExporter.Application.Documents;
using WikiExporter.Application.DTOs;

namespace WikiExporter.Application.Interfaces;

public interface IMovieExportDocumentBuilder
{
    ExportDocument Build(
        MovieExportDto dto,
        string language);
}
