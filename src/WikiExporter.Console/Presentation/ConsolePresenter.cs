using WikiExporter.Application.Export;

namespace WikiExporter.Console.Presentation;

/// <summary>Formats application results for a human-readable terminal summary.</summary>
public sealed class ConsolePresenter
{
    public void Print(ExportResult result)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Export finished.");
        System.Console.WriteLine($"Type:        {result.EntityType}");
        System.Console.WriteLine($"Requested:   {result.RequestedItems}");
        System.Console.WriteLine($"Built:       {result.SuccessfullyBuilt}");
        System.Console.WriteLine($"Failed:      {result.FailedItems}");
        if (result.Documents.Count > 0)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Documents:");
            foreach (var document in result.Documents)
                System.Console.WriteLine($"  {document.EntityType}/{document.EntityId}");
        }
        if (result.Errors.Count > 0)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Errors:");
            foreach (var error in result.Errors)
                System.Console.WriteLine($"  {(error.EntityId is null ? "" : error.EntityId + ": ")}{error.Message}");
        }
    }
}
