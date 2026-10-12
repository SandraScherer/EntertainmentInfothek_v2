namespace WikiExporter.Domain.Export;

/// <summary>Represents episode reference.</summary>
public sealed record EpisodeReference(string Id, LocalizedValue Title, string? SeasonNo, string? EpisodeNo);
