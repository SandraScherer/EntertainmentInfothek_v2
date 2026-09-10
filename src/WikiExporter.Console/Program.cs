using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using WikiExporter.Application.Models;
using WikiExporter.Application.UseCases;

using WikiExporter.Console.Menus;

using WikiExporter.Infrastructure.DependencyInjection;

var host =
    Host.CreateDefaultBuilder(args)
        .ConfigureServices(
            (context, services) =>
            {
                services.AddWikiExporter(
                    context.Configuration);

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

await using var scope =
    host.Services.CreateAsyncScope();

var services =
    scope.ServiceProvider;

var logger =
    services
        .GetRequiredService<
            ILoggerFactory>()
        .CreateLogger("Program");

var mainMenu =
    services.GetRequiredService<
        MainMenu>();

while (true)
{
    var selection =
        mainMenu.Show();

    switch (selection)
    {
        case 0:
        {
            logger.LogInformation(
                "Application terminated.");

            return;
        }

        case 1:
        {
            await ExecuteMovieExport(
                services,
                logger);

            break;
        }

        default:
        {
            System.Console.WriteLine(
                "Unknown menu option.");

            break;
        }
    }

    System.Console.WriteLine();
    System.Console.WriteLine(
        "Press ENTER to continue...");

    System.Console.ReadLine();
}

static async Task ExecuteMovieExport(
    IServiceProvider services,
    ILogger logger)
{
    var movieMenu =
        services.GetRequiredService<
            MovieSelectionMenu>();

    var formatMenu =
        services.GetRequiredService<
            FormatSelectionMenu>();

    var movieId =
        await movieMenu.SelectMovieAsync();

    if (string.IsNullOrWhiteSpace(movieId))
    {
        System.Console.WriteLine(
            "Invalid Movie ID.");

        return;
    }

    var format =
        formatMenu.SelectFormat();

    var useCase =
        services.GetRequiredService<
            ExportMovieUseCase>();

    var request =
        new ExportRequest
        {
            RecordId = movieId,
            Language = "de-DE",
            Format = format,
            OutputFolder = "Exports"
        };

    logger.LogInformation(
        "Starting export for Movie {MovieId}",
        movieId);

    var result =
        await useCase.ExecuteAsync(
            request,
            CancellationToken.None);

    if (result.Success)
    {
        logger.LogInformation(
            "Export completed.");

        System.Console.WriteLine();

        System.Console.WriteLine(
            $"File created: {result.FilePath}");
    }
    else
    {
        logger.LogError(
            "Export failed.");

        foreach (var error in result.Errors)
        {
            System.Console.WriteLine(
                $"ERROR: {error}");
        }
    }
}
