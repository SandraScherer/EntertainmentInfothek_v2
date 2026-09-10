namespace WikiExporter.Infrastructure.Persistence.Entities;

/// <summary>
/// Tabelle Text
/// </summary>
public sealed class TextEntity
{
    public string Id { get; set; } = string.Empty;

    public string? Content { get; set; }
}
