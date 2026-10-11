namespace WikiExporter.Application.Export.Requests;

/// <summary>Defines the export entity type type.</summary>
public enum ExportEntityType { Movie, Series, Episode, Book, VideoGame, Person, Connection }
/// <summary>Defines the export language type.</summary>
public enum ExportLanguage { Original, English, German }
/// <summary>Defines the export format type.</summary>
public enum ExportFormat { DokuWiki, Obsidian }

/// <summary>Defines the export scope type.</summary>
public abstract record ExportScope
{
/// <summary>Initializes a new instance of the export scope type.</summary>
    private ExportScope() { }
/// <summary>Defines the single type.</summary>
    public sealed record Single(string EntityId) : ExportScope;
/// <summary>Defines the all type.</summary>
    public sealed record All(int BatchSize = 250) : ExportScope;
}

/// <summary>Complete application-level export command. It deliberately contains no EF/SQLite/Markdown implementation detail.</summary>
public sealed record ExportRequest(
    ExportEntityType EntityType,
    ExportScope Scope,
    ExportLanguage Language,
    ExportFormat Format = ExportFormat.Obsidian,
    string? OutputDirectory = null);
