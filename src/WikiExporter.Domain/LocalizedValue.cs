namespace WikiExporter.Domain.Export;

/// <summary>Localized source value. Persistence keeps all three source-language variants.</summary>
public sealed record LocalizedValue(string? Original, string? English, string? German);
