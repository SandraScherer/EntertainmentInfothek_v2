using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Console.Interaction;

/// <summary>Small, testable abstraction around terminal input/output.</summary>
public interface IConsoleInteraction
{
    ExportEntityType SelectEntityType();
    ExportLanguage SelectLanguage(ExportLanguage defaultValue);
    ExportFormat SelectFormat(ExportFormat defaultValue);
    ExportScope SelectScope();
    string ReadRequired(string prompt);
    void Write(string text);
    void WriteLine(string text = "");
}
