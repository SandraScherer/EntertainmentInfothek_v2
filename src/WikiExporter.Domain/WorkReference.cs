namespace WikiExporter.Domain.Export;

/// <summary>Represents work reference.</summary>
public sealed record WorkReference(string Type, string Id, LocalizedValue Title);
