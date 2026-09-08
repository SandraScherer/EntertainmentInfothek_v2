using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Person_Family</c>. The entity is persistence-only.</summary>
public sealed class PersonFamily
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>PersonID</c>.</summary>
    public string? PersonId { get; set; }
    /// <summary>Maps to <c>FamilyID</c>.</summary>
    public string? FamilyId { get; set; }
    /// <summary>Maps to <c>OriginalName</c>.</summary>
    public string? OriginalName { get; set; }
    /// <summary>Maps to <c>RelationshipID</c>.</summary>
    public string? RelationshipId { get; set; }
    /// <summary>Maps to <c>EnglishRole</c>.</summary>
    public string? EnglishRole { get; set; }
    /// <summary>Maps to <c>GermanRole</c>.</summary>
    public string? GermanRole { get; set; }
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

    /// <summary>Navigation for FK <c>FamilyID</c> to <c>Person</c>.</summary>
    public Person? Family { get; set; }

    /// <summary>Navigation for FK <c>PersonID</c> to <c>Person</c>.</summary>
    public Person? Person { get; set; }

    /// <summary>Navigation for FK <c>RelationshipID</c> to <c>Relationship</c>.</summary>
    public Relationship? Relationship { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }
}
