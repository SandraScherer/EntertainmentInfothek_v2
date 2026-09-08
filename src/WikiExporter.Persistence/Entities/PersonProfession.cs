using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Person_Profession</c>. The entity is persistence-only.</summary>
public sealed class PersonProfession
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>PersonID</c>.</summary>
    public string? PersonId { get; set; }
    /// <summary>Maps to <c>ProfessionID</c>.</summary>
    public string? ProfessionId { get; set; }
    /// <summary>Maps to <c>Order</c>.</summary>
    public string? Order { get; set; }
    /// <summary>Maps to <c>Details</c>.</summary>
    public string? Details { get; set; }
    /// <summary>Maps to <c>Notes</c>.</summary>
    public string? Notes { get; set; }
    /// <summary>Maps to <c>StatusID</c>.</summary>
    public string? StatusId { get; set; }
    /// <summary>Maps to <c>LastUpdated</c>.</summary>
    public string? LastUpdated { get; set; }

    /// <summary>Navigation for FK <c>PersonID</c> to <c>Person</c>.</summary>
    public Person? Person { get; set; }

    /// <summary>Navigation for FK <c>ProfessionID</c> to <c>Profession</c>.</summary>
    public Profession? Profession { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }
}
