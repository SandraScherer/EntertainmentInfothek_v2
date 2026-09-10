using Microsoft.Extensions.Configuration;
using WikiExporter.Application.Export;
using WikiExporter.Application.Export.Requests;
using WikiExporter.Console.Configuration;
using WikiExporter.Console.Interaction;
using WikiExporter.Console.Presentation;
using WikiExporter.ConsoleApp;
using WikiExporter.Export.Markdown;
using WikiExporter.Persistence.DbContext;

namespace WikiExporter.ConsoleApp;

/// <summary>Console entry point. All UI concerns stay here; business orchestration remains in Application.</summary>
public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        try
        {
            var commandLine = CommandLineParser.Parse(args);
            if (commandLine.Help) { PrintHelp(); return 0; }

            using var host = CompositionRoot.BuildHost(args, commandLine.DatabasePath);
            using var scope = host.Services.CreateScope();

            var configuration = host.Services.GetRequiredService<IConfiguration>();
            var settings = configuration.GetSection(WikiExporterOptions.SectionName).Get<WikiExporterOptions>() ?? new();
            var interaction = scope.ServiceProvider.GetRequiredService<IConsoleInteraction>();

            var entityType = commandLine.EntityType ?? interaction.SelectEntityType();
            var language = commandLine.Language ?? ParseDefaultLanguage(settings.DefaultLanguage);
            if (commandLine.Language is null && Console.IsInputRedirected == false)
                language = interaction.SelectLanguage(language);

            var format = commandLine.Format ?? ParseDefaultFormat(settings.DefaultFormat);
            if (commandLine.Format is null && Console.IsInputRedirected == false)
                format = interaction.SelectFormat(format);

            ExportScope scopeSelection;
            if (commandLine.All) scopeSelection = new ExportScope.All(commandLine.BatchSize ?? settings.DefaultBatchSize);
            else if (commandLine.EntityId is not null) scopeSelection = new ExportScope.Single(commandLine.EntityId);
            else scopeSelection = interaction.SelectScope();

            var databasePath = commandLine.DatabasePath ?? settings.DatabasePath;
            ValidateDatabase(databasePath);
            var output = Path.GetFullPath(commandLine.OutputDirectory ?? settings.OutputDirectory);

            var request = new ExportRequest(entityType, scopeSelection, language, format, output);
            var useCase = scope.ServiceProvider.GetRequiredService<IExportUseCase>();
            var result = await useCase.ExecuteAsync(request);

            var markdown = scope.ServiceProvider.GetRequiredService<IMarkdownExportService>();
            foreach (var document in result.Documents)
            {
                await markdown.ExportAsync(document.Document, request.Format, output);
                System.Console.WriteLine($"Exported {document.EntityType} {document.EntityId}.");
            }

            scope.ServiceProvider.GetRequiredService<ConsolePresenter>().Print(result);
            return result.FailedItems == 0 ? 0 : 2;
        }
        catch (OperationCanceledException)
        {
            System.Console.Error.WriteLine("Export cancelled.");
            return 3;
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
            return 1;
        }
    }

    private static void ValidateDatabase(string path)
    {
        var full = Path.GetFullPath(path);
        if (!File.Exists(full)) throw new FileNotFoundException($"SQLite database not found: {full}", full);
    }

    private static ExportLanguage ParseDefaultLanguage(string value)
        => Enum.TryParse<ExportLanguage>(value, true, out var result) ? result : ExportLanguage.German;

    private static ExportFormat ParseDefaultFormat(string value)
        => Enum.TryParse<ExportFormat>(value, true, out var result) ? result : ExportFormat.Obsidian;

    private static void PrintHelp()
    {
        System.Console.WriteLine("WikiExporter");
        System.Console.WriteLine();
        System.Console.WriteLine("Usage:");
        System.Console.WriteLine("  WikiExporter [options]");
        System.Console.WriteLine();
        System.Console.WriteLine("Options:");
        System.Console.WriteLine("  --database <path>       SQLite database path");
        System.Console.WriteLine("  --output <path>         Export directory");
        System.Console.WriteLine("  --type <type>           Movie|Series|Episode|Book|VideoGame|Person|Connection");
        System.Console.WriteLine("  --id <id>               Export exactly one entity");
        System.Console.WriteLine("  --all                   Export all entities of the selected type");
        System.Console.WriteLine("  --language <language>   Original|English|German");
        System.Console.WriteLine("  --format <format>       Obsidian|DokuWiki");
        System.Console.WriteLine("  --batch-size <number>   Batch size for --all");
        System.Console.WriteLine("  --help                  Show this help");
    }
}
