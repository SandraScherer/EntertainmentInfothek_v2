using Microsoft.EntityFrameworkCore.Metadata;

namespace WikiExporter.Persistence.Queries;

/// <summary>Represents the entities and foreign-key values loaded for one bounded export batch.</summary>
internal sealed class ExportGraph
{
    /// <summary>Gets loaded entities keyed by EF entity type and database identifier.</summary>
    public Dictionary<(IEntityType TypeEntity, string Id), object> Entities { get; } = new();

    /// <summary>Gets foreign-key values keyed by EF entity type and database identifier.</summary>
    public Dictionary<(IEntityType TypeEntity, string Id), Dictionary<string, string?>> ForeignKeys { get; } = new();
}
