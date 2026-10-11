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

/// <summary>Defines the console interaction type.</summary>
public sealed class ConsoleInteraction : IConsoleInteraction
{
/// <summary>Executes the select entity type operation.</summary>
    public ExportEntityType SelectEntityType()
    {
        var values = Enum.GetValues<ExportEntityType>();
        WriteLine("Export type:");
        for (var i = 0; i < values.Length; i++) WriteLine($"  {i + 1}. {values[i]}");
        return values[ReadIndex(values.Length, "Selection")];
    }

/// <summary>Executes the select language operation.</summary>
    public ExportLanguage SelectLanguage(ExportLanguage defaultValue)
    {
        WriteLine($"Language [{defaultValue}]:");
        var values = Enum.GetValues<ExportLanguage>();
        for (var i = 0; i < values.Length; i++) WriteLine($"  {i + 1}. {values[i]}");
        var line = ReadLineOrEmpty();
        return string.IsNullOrWhiteSpace(line) ? defaultValue : ParseIndexOrEnum<ExportLanguage>(line, values);
    }

/// <summary>Executes the select format operation.</summary>
    public ExportFormat SelectFormat(ExportFormat defaultValue)
    {
        WriteLine($"Format [{defaultValue}]:");
        var values = Enum.GetValues<ExportFormat>();
        for (var i = 0; i < values.Length; i++) WriteLine($"  {i + 1}. {values[i]}");
        var line = ReadLineOrEmpty();
        return string.IsNullOrWhiteSpace(line) ? defaultValue : ParseIndexOrEnum<ExportFormat>(line, values);
    }

/// <summary>Executes the select scope operation.</summary>
    public ExportScope SelectScope()
    {
        WriteLine("Scope:");
        WriteLine("  1. Single record");
        WriteLine("  2. All records");
        var line = ReadRequired("Selection: ");
        if (line == "2" || line.Equals("all", StringComparison.OrdinalIgnoreCase)) return new ExportScope.All();
        if (line == "1" || line.Equals("single", StringComparison.OrdinalIgnoreCase)) return new ExportScope.Single(ReadRequired("Entity ID: "));
        throw new ArgumentException("Invalid scope selection.");
    }

/// <summary>Executes the read required operation.</summary>
    public string ReadRequired(string prompt)
    {
        Write(prompt);
        var value = System.Console.ReadLine();
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("A value is required.");
        return value.Trim();
    }

/// <summary>Executes the write operation.</summary>
    public void Write(string text) => System.Console.Write(text);
/// <summary>Executes the write line operation.</summary>
    public void WriteLine(string text = "") => System.Console.WriteLine(text);
/// <summary>Executes the read line or empty operation.</summary>
    private static string ReadLineOrEmpty() => System.Console.ReadLine()?.Trim() ?? "";
/// <summary>Executes the read index operation.</summary>
    private static int ReadIndex(int count, string prompt)
    {
        var value = new ConsoleInteraction().ReadRequired($"{prompt}: ");
        return int.TryParse(value, out var n) && n >= 1 && n <= count ? n - 1 : throw new ArgumentException("Invalid selection.");
    }
    private static T ParseIndexOrEnum<T>(string input, T[] values) where T : struct, Enum
    {
        if (int.TryParse(input, out var n) && n >= 1 && n <= values.Length) return values[n - 1];
        return Enum.TryParse<T>(input, true, out var parsed) ? parsed : throw new ArgumentException("Invalid selection.");
    }
}
