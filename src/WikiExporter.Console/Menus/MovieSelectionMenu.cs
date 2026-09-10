using WikiExporter.Application.Interfaces;

namespace WikiExporter.Console.Menus;

/// <summary>
/// Auswahl eines Films.
/// </summary>
public sealed class MovieSelectionMenu
{
    private readonly IMovieRepository _repository;

    public MovieSelectionMenu(
        IMovieRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> SelectMovieAsync()
    {
        System.Console.WriteLine();
        System.Console.WriteLine(
            "Movie-ID eingeben:");

        System.Console.Write("> ");

        return await Task.FromResult(
            System.Console.ReadLine()
            ?? string.Empty);
    }
}
