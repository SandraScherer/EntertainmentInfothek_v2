namespace WikiExporter.Application.Export.Requests;

public enum ExportEntityType { Movie, Series, Episode, Book, VideoGame, Person, Connection }
public enum ExportLanguage { Original, English, German }
public enum ExportFormat { DokuWiki, Obsidian }

public abstract record ExportScope
{
    private ExportScope() { }
    public sealed record Single(string EntityId) : ExportScope;
    public sealed record All(int BatchSize = 250) : ExportScope;
}

/// <summary>Complete application-level export command. It deliberately contains no EF/SQLite/Markdown implementation detail.</summary>
public sealed record ExportRequest(
    ExportEntityType EntityType,
    ExportScope Scope,
    ExportLanguage Language,
    ExportFormat Format = ExportFormat.Obsidian,
    string? OutputDirectory = null);
