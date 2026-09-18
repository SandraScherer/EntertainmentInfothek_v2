using System.Collections.Generic;

namespace WikiExporter.Persistence.Entities;

/// <summary>EF representation of the SQLite table <c>Movie_User</c>. The entity is persistence-only.</summary>
public sealed class MovieUserEntity
{
    /// <summary>Maps to <c>ID</c>.</summary>
    public string Id { get; set; }
    /// <summary>Maps to <c>MovieID</c>.</summary>
    public string? MovieId { get; set; }
    /// <summary>Maps to <c>UserID</c>.</summary>
    public string? UserId { get; set; }
    /// <summary>Maps to <c>EditionID</c>.</summary>
    public string? EditionId { get; set; }
    /// <summary>Maps to <c>UserStatusID</c>.</summary>
    public string? UserStatusId { get; set; }
    /// <summary>Maps to <c>PriorityID</c>.</summary>
    public string? PriorityId { get; set; }
    /// <summary>Maps to <c>EnglishExplanation</c>.</summary>
    public string? EnglishExplanation { get; set; }
    /// <summary>Maps to <c>GermanExplanation</c>.</summary>
    public string? GermanExplanation { get; set; }
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

    /// <summary>Navigation for FK <c>EditionID</c> to <c>Edition</c>.</summary>
    public EditionEntity? EditionEntity { get; set; }

    /// <summary>Navigation for FK <c>MovieID</c> to <c>Movie</c>.</summary>
    public MovieEntity? MovieEntity { get; set; }

    /// <summary>Navigation for FK <c>PriorityID</c> to <c>Priority</c>.</summary>
    public PriorityEntity? PriorityEntity { get; set; }

    /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? StatusEntity { get; set; }

    /// <summary>Navigation for FK <c>UserID</c> to <c>User</c>.</summary>
    public UserEntity? UserEntity { get; set; }

    /// <summary>Navigation for FK <c>UserStatusID</c> to <c>Status</c>.</summary>
    public StatusEntity? UserStatus { get; set; }
}
