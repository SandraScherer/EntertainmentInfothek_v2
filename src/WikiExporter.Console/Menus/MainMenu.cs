namespace WikiExporter.Console.Menus;

/// <summary>
/// Hauptmenü der Anwendung.
/// </summary>
public sealed class MainMenu
{
    public int Show()
    {
        System.Console.Clear();

        System.Console.WriteLine(
            "===================================");

        System.Console.WriteLine(
            " WikiExporter");

        System.Console.WriteLine(
            "===================================");

        System.Console.WriteLine();

        System.Console.WriteLine(
            "1 - Movie exportieren");

        System.Console.WriteLine(
            "0 - Beenden");

        System.Console.WriteLine();

        return ReadNumber();
    }

    private static int ReadNumber()
    {
        while (true)
        {
            System.Console.Write("> ");

            var input =
                System.Console.ReadLine();

            if (int.TryParse(
                input,
                out var value))
            {
                return value;
            }
        }
    }
}
