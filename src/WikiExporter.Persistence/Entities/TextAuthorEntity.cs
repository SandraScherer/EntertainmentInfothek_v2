// WikiExporter.Persistence.dll: Provides access to the EntertainmentInfothek.db
// Copyright (C) 2026 Sandra Scherer

using System;
using System.Collections.Generic;
using System.Text;

namespace WikiExporter.Persistence.Entities
{
    /// <summary>
    /// EF representation of the SQLite table <c>Text_Author</c>.
    /// The entity is persistence-only.
    /// </summary>
    public class TextAuthorEntity
    {
        // --- Fields ---

        /// <summary>Maps to <c>ID</c>.</summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>Maps to <c>TextID</c>.</summary>
        public string? TextId { get; set; }

        /// <summary>Maps to <c>PersonID</c>.</summary>
        public string? PersonId { get; set; }

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


        // --- Foreign Key Navigation Properties ---

        /// <summary>Navigation for FK <c>TextID</c> to <c>Text</c>.</summary>
        public TextEntity? TextEntity { get; set; }

        /// <summary>Navigation for FK <c>PersonID</c> to <c>Person</c>.</summary>
        public PersonEntity? PersonEntity { get; set; }

        /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
        public StatusEntity? StatusEntity { get; set; }
    }
}
