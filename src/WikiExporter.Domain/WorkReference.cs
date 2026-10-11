namespace WikiExporter.Domain.Export;

/// <summary>Defines the work reference type.</summary>
public sealed record WorkReference(string Type, string Id, LocalizedValue Title);
