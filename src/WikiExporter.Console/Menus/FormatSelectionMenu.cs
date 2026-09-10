using WikiExporter.Application.Models;

namespace WikiExporter.Console.Menus;

/// <summary>
/// Auswahl des Zielformats.
/// </summary>
public sealed class FormatSelectionMenu
{
    public ExportFormat SelectFormat()
    {
        System.Console.WriteLine();

        System.Console.WriteLine(
            "Exportformat");

        System.Console.WriteLine(
            "1 - Obsidian");

        System.Console.WriteLine(
            "2 - DokuWiki");

        while (true)
        {
            System.Console.Write("> ");

            var input =
                System.Console.ReadLine();

            switch (input)
            {
                case "1":
                    return ExportFormat.Obsidian;

                case "2":
                    return ExportFormat.DokuWiki;
            }
        }
    }
}
