using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Episode_CompanyCredits</c>. The entity is persistence-only.</summary>
public sealed class EpisodeCompanyCredits
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>EpisodeID</c>.</summary>
    public string? EpisodeId { get; set; }
    /// <summary>Maps to <c>CompanyID</c>.</summary>
    public string? CompanyId { get; set; }
    /// <summary>Maps to <c>DepartmentID</c>.</summary>
    public string? DepartmentId { get; set; }
    /// <summary>Maps to <c>CountryID</c>.</summary>
    public string? CountryId { get; set; }
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

    /// <summary>Navigation for FK <c>CompanyID</c> to <c>Company</c>.</summary>
    public Company? Company { get; set; }

    /// <summary>Navigation for FK <c>CountryID</c> to <c>Country</c>.</summary>
    public Country? Country { get; set; }

    /// <summary>Navigation for FK <c>DepartmentID</c> to <c>Department</c>.</summary>
    public Department? Department { get; set; }

    /// <summary>Navigation for FK <c>EpisodeID</c> to <c>Episode</c>.</summary>
    public Episode? Episode { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public Status? Status { get; set; }
}
