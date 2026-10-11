namespace WikiExporter.Domain.Export;

/// <summary>Stable reference to another exported entity.</summary>
public sealed record EntityReference(string Id, string? DisplayName = null);
