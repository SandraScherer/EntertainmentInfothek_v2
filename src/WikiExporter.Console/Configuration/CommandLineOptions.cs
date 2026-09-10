using WikiExporter.Application.Export.Requests;

namespace WikiExporter.Console.Configuration;

/// <summary>Parsed command-line arguments. Interactive input is used for omitted selection values.</summary>
public sealed record CommandLineOptions(
    string? DatabasePath,
    string? OutputDirectory,
    ExportEntityType? EntityType,
    string? EntityId,
    bool All,
    ExportLanguage? Language,
    ExportFormat? Format,
    int? BatchSize,
    bool Help);

public static class CommandLineParser
{
    public static CommandLineOptions Parse(string[] args)
    {
        string? db = null, output = null, id = null;
        ExportEntityType? type = null;
        ExportLanguage? language = null;
        ExportFormat? format = null;
        int? batch = null;
        var all = false;
        var help = false;

        for (var i = 0; i < args.Length; i++)
        {
            var arg = args[i];
            if (arg is "-h" or "--help") { help = true; continue; }
            if (arg is "--all") { all = true; continue; }

            var (name, value) = Split(arg, args, ref i);
            switch (name.ToLowerInvariant())
            {
                case "--database": db = value; break;
                case "--output": output = value; break;
                case "--type": type = ParseEnum<ExportEntityType>(value, name); break;
                case "--id": id = value; break;
                case "--language": language = ParseEnum<ExportLanguage>(value, name); break;
                case "--format": format = ParseEnum<ExportFormat>(value, name); break;
                case "--batch-size":
                    if (!int.TryParse(value, out var size) || size < 1) throw new ArgumentException("--batch-size must be a positive integer.");
                    batch = size;
                    break;
                default: throw new ArgumentException($"Unknown argument '{arg}'. Use --help for usage.");
            }
        }

        if (all && id is not null) throw new ArgumentException("--all and --id cannot be used together.");
        return new(db, output, type, id, all, language, format, batch, help);
    }

    private static (string Name, string Value) Split(string arg, string[] args, ref int index)
    {
        var equals = arg.IndexOf('=');
        if (equals > 0) return (arg[..equals], arg[(equals + 1)..]);
        if (index + 1 >= args.Length) throw new ArgumentException($"Missing value for '{arg}'.");
        return (arg, args[++index]);
    }

    private static T ParseEnum<T>(string value, string argument) where T : struct, Enum
        => Enum.TryParse<T>(value, ignoreCase: true, out var parsed)
            ? parsed
            : throw new ArgumentException($"Invalid value '{value}' for {argument}.");
}
