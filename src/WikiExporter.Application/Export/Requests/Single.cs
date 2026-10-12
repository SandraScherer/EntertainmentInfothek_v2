namespace WikiExporter.Application.Export.Requests;

/// <summary>Represents the export scope for one entity ID.</summary>
public abstract partial record ExportScope
{
    /// <summary>Represents exporting one entity identified by its stable ID.</summary>
    public sealed record Single(string EntityId) : ExportScope;
}
