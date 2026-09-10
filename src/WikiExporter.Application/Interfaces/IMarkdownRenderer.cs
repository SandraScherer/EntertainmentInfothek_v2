using WikiExporter.Application.Documents;

namespace WikiExporter.Application.Interfaces;

public interface IMarkdownRenderer
{
    string Render(ExportDocument document);
}
