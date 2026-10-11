using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Console.Interaction;

/// <summary>Provides the interactive terminal prompts used when command-line options are omitted.</summary>
public sealed class ConsoleInteraction : IConsoleInteraction
{
    /// <summary>Prompts for the type of entertainment entity to export.</summary>
    public ExportEntityType SelectEntityType() => SelectEnum<ExportEntityType>("Export type");

    /// <summary>Prompts for an export language, allowing the supplied default to be retained.</summary>
    public ExportLanguage SelectLanguage(ExportLanguage defaultValue) => SelectEnum("Language", defaultValue);

    /// <summary>Prompts for an output format, allowing the supplied default to be retained.</summary>
    public ExportFormat SelectFormat(ExportFormat defaultValue) => SelectEnum("Format", defaultValue);

    /// <summary>Prompts whether to export one entity or all entities of the selected type.</summary>
    public ExportScope SelectScope()
    {
        WriteLine("Export scope:");
        WriteLine("  1. One entity");
        WriteLine("  2. All entities");
        var choice = ReadIndex(2, "Selection");
        if (choice == 0)
            return new ExportScope.Single(ReadRequired("Entity ID"));

        var batchText = ReadLineWithPrompt("Batch size [250]: ");
        if (string.IsNullOrWhiteSpace(batchText))
            return new ExportScope.All(250);
        if (!int.TryParse(batchText, out var batchSize) || batchSize < 1)
            throw new FormatException("Batch size must be a positive integer.");
        return new ExportScope.All(batchSize);
    }

    /// <summary>Displays a prompt and reads a non-empty response.</summary>
    public string ReadRequired(string prompt)
    {
        while (true)
        {
            var value = ReadLineWithPrompt($"{prompt}: ");
            if (!string.IsNullOrWhiteSpace(value))
                return value.Trim();
            WriteLine("A value is required.");
        }
    }

    /// <summary>Writes text to standard output without a trailing newline.</summary>
    public void Write(string text) => System.Console.Write(text);

    /// <summary>Writes text to standard output followed by a newline.</summary>
    public void WriteLine(string text = "") => System.Console.WriteLine(text);

    private T SelectEnum<T>(string prompt, T? defaultValue = null) where T : struct, Enum
    {
        var values = Enum.GetValues<T>();
        WriteLine(defaultValue is null ? $"{prompt}:" : $"{prompt} [{defaultValue}]:");
        for (var i = 0; i < values.Length; i++)
            WriteLine($"  {i + 1}. {values[i]}");

        var input = ReadLineWithPrompt("Selection (number or name): ");
        if (string.IsNullOrWhiteSpace(input) && defaultValue is T fallback)
            return fallback;
        if (int.TryParse(input, out var number) && number >= 1 && number <= values.Length)
            return values[number - 1];
        if (Enum.TryParse<T>(input, ignoreCase: true, out var parsed) && Enum.IsDefined(parsed))
            return parsed;
        throw new FormatException($"Invalid {prompt.ToLowerInvariant()} selection: '{input}'.");
    }

    private static int ReadIndex(int count, string prompt)
    {
        while (true)
        {
            var input = ReadLineWithPrompt($"{prompt}: ");
            if (int.TryParse(input, out var index) && index >= 1 && index <= count)
                return index - 1;
            System.Console.WriteLine($"Enter a number from 1 to {count}.");
        }
    }

    private static string ReadLineWithPrompt(string prompt)
    {
        System.Console.Write(prompt);
        return System.Console.ReadLine() ?? string.Empty;
    }
}
