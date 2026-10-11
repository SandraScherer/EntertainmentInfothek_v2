namespace WikiExporter.Application.Export.Requests;

public abstract partial record ExportScope
{
    /// <summary>Represents exporting one entity identified by its stable ID.</summary>
    public sealed record Single(string EntityId) : ExportScope;
}
