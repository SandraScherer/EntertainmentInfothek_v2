namespace WikiExporter.Application.Export.Requests;

/// <summary>Represents the all-items export scope and its batch-size setting.</summary>
public abstract partial record ExportScope
{
    /// <summary>Represents exporting all entities in batches.</summary>
    public sealed record All(int BatchSize = 250) : ExportScope;
}
