// WikiExporter.Persistence.dll: Provides access to the EntertainmentInfothek.db
// Copyright (C) 2026 Sandra Scherer

using System;
using System.Collections.Generic;
using System.Text;

namespace WikiExporter.Persistence.Entities
{
    /// <summary>
    /// EF representation of the SQLite table <c>Movie_Image</c>.
    /// The entity is persistence-only.
    /// </summary>
    public class MovieImageEntity
    {
        // --- Fields ---

        /// <summary>Maps to <c>ID</c>.</summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>Maps to <c>MovieID</c>.</summary>
        public string? MovieId { get; set; }

        /// <summary>Maps to <c>ImageID</c>.</summary>
        public string? ImageId { get; set; }

        /// <summary>Maps to <c>TypeID</c>.</summary>
        public string? TypeId { get; set; }

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

        /// <summary>Navigation for FK <c>MovieID</c> to <c>Movie</c>.</summary>
        public MovieEntity? MovieEntity { get; set; }

        /// <summary>Navigation for FK <c>ImageID</c> to <c>Image</c>.</summary>
        public ImageEntity? ImageEntity { get; set; }

        /// <summary>Navigation for FK <c>TypeID</c> to <c>Type</c>.</summary>
        public ImageTypeEntity? TypeEntity { get; set; }

        /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
        public StatusEntity? StatusEntity { get; set; }
    }
}
