namespace WikiExporter.Application.Export.Requests;

public abstract partial record ExportScope
{
    /// <summary>Represents exporting all entities in batches.</summary>
    public sealed record All(int BatchSize = 250) : ExportScope;
}
