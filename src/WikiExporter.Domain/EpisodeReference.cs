namespace WikiExporter.Domain.Export;

/// <summary>Defines the episode reference type.</summary>
public sealed record EpisodeReference(string Id, LocalizedValue Title, string? SeasonNo, string? EpisodeNo);
