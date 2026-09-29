using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using WikiExporter.Application.Models;
using WikiExporter.Application.UseCases;
using WikiExporter.Console.Menus;
using WikiExporter.Infrastructure.DependencyInjection;

namespace WikiExporter.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // 1. Host-Builder initialisieren und DI-Container konfigurieren
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddWikiExporter(context.Configuration);
                    services.AddTransient<MainMenu>();
                    services.AddTransient<MovieSelectionMenu>();
                    services.AddTransient<FormatSelectionMenu>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .Build();

            // 2. Asynchronen Scope für die Service-Auflösung erstellen
            await using AsyncServiceScope scope = host.Services.CreateAsyncScope();
            IServiceProvider services = scope.ServiceProvider;

            // 3. Logger und Hauptmenü instanziieren
            ILogger logger = services.GetRequiredService<ILoggerFactory>().CreateLogger("Program");
            MainMenu mainMenu = services.GetRequiredService<MainMenu>();

            // 4. Hauptanwendungsschleife
            while (true)
            {
                int selection = mainMenu.Show();

                switch (selection)
                {
                    case 0:
                        logger.LogInformation("Application terminated.");
                        return;

                    case 1:
                        await ExecuteMovieExport(services, logger);
                        break;

                    default:
                        System.Console.WriteLine("Unknown menu option.");
                        break;
                }

                System.Console.WriteLine();
                System.Console.WriteLine("Press ENTER to continue...");
                System.Console.ReadLine();
            }
        }

        // 5. Hilfsmethode für den Exportprozess
        private static async Task ExecuteMovieExport(IServiceProvider services, ILogger logger)
        {
            MovieSelectionMenu movieMenu = services.GetRequiredService<MovieSelectionMenu>();
            FormatSelectionMenu formatMenu = services.GetRequiredService<FormatSelectionMenu>();

            string? movieId = await movieMenu.SelectMovieAsync();

            if (string.IsNullOrWhiteSpace(movieId))
            {
                System.Console.WriteLine("Invalid Movie ID.");
                return;
            }

            var format = formatMenu.SelectFormat();
            ExportMovieUseCase useCase = services.GetRequiredService<ExportMovieUseCase>();

            var request = new ExportRequest
            {
                RecordId = movieId,
                Language = "de-DE",
                Format = format,
                OutputFolder = "Exports"
            };

            logger.LogInformation("Starting export for Movie {MovieId}", movieId);

            ExportResult result = await useCase.ExecuteAsync(request, CancellationToken.None);

            if (result.Success)
            {
                logger.LogInformation("Export completed.");
                System.Console.WriteLine();
                System.Console.WriteLine($"File created: {result.FilePath}");
            }
            else
            {
                logger.LogError("Export failed.");
                foreach (string error in result.Errors)
                {
                    System.Console.WriteLine($"ERROR: {error}");
                }
            }
        }
    }
}
