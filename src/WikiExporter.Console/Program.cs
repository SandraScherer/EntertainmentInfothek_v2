using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using WikiExporter.Application.Models;
using WikiExporter.Application.UseCases;

using WikiExporter.Console.Menus;

using WikiExporter.Infrastructure.DependencyInjection;

var builder =
    Host.CreateDefaultBuilder(args);

builder.ConfigureAppConfiguration(
    configuration =>
    {
        configuration.AddJsonFile(
            "appsettings.json",
            false,
            true);
    });

builder.ConfigureServices(
    (context, services) =>
    {
        services.AddWikiExporter(
            context.Configuration);

        services.AddTransient<
            MainMenu>();

        services.AddTransient<
            MovieSelectionMenu>();

        services.AddTransient<
            FormatSelectionMenu>();
    });

builder.ConfigureLogging(
    logging =>
    {
        logging.ClearProviders();

        logging.AddConsole();
    });

var host = builder.Build();

await using var scope =
    host.Services.CreateAsyncScope();

var provider =
    scope.ServiceProvider;

var logger =
    provider.GetRequiredService<
        ILoggerFactory>()
    .CreateLogger("Program");

var menu =
    provider.GetRequiredService<
        MainMenu>();

while (true)
{
    var choice =
        menu.Show();

    if (choice == 0)
    {
        break;
    }

     if (choice != 1)
     {
         continue;
     }

     // Movie Workflow
}

var movieMenu =
    provider.GetRequiredService<
        MovieSelectionMenu>();

var movieId =
    await movieMenu
        .SelectMovieAsync();

var formatMenu =
    provider.GetRequiredService<
        FormatSelectionMenu>();

var format =
    formatMenu.SelectFormat();

var useCase =
    provider.GetRequiredService<
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
    "Export started");

var result =
    await useCase.ExecuteAsync(
        request,
        CancellationToken.None);

logger.LogInformation(
    "Export finished");

System.Console.WriteLine();

System.Console.WriteLine(
    $"File created: {result.FilePath}");
