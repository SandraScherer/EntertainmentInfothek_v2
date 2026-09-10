using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WikiExporter.Application.DependencyInjection;
using WikiExporter.Export.DependencyInjection;
using WikiExporter.Persistence.DependencyInjection;

namespace WikiExporter.ConsoleApp;

/// <summary>
/// The Composition Root is the only place where concrete infrastructure is assembled.
/// This keeps Console/UI code independent from the individual EF Core and renderer types.
/// </summary>
public static class CompositionRoot
{
    public static IHost BuildHost(string[] args, string? databasePathOverride = null)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, configuration) =>
            {
                configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
                configuration.AddEnvironmentVariables(prefix: "WIKIEXPORTER_");
            })
            .ConfigureLogging(logging =>
            {
                // Console logging is deliberately configured here, not inside Application.
                logging.ClearProviders();
                logging.AddSimpleConsole(options => options.SingleLine = true);
            })
            .ConfigureServices((context, services) =>
            {
                var databasePath = databasePathOverride ?? context.Configuration["WikiExporter:DatabasePath"] ?? "EntertainmentInfothek.db";
                var connectionString = BuildSqliteConnectionString(databasePath);

                // Application knows only its abstractions; Persistence and Export implement them.
                services.AddWikiExporterApplication();
                services.AddWikiExporterPersistence(connectionString);
                services.AddWikiExporterExport();

                services.AddSingleton<Interaction.IConsoleInteraction, Interaction.ConsoleInteraction>();
                services.AddSingleton<Presentation.ConsolePresenter>();
            })
            .Build();
    }

    private static string BuildSqliteConnectionString(string databasePath)
    {
        // Relative database paths are resolved against the process working directory.
        var fullPath = Path.GetFullPath(databasePath);
        return $"Data Source={fullPath};Mode=ReadOnly;Cache=Shared";
    }
}
