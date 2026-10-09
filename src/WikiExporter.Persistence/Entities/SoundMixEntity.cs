// WikiExporter.Persistence.dll: Provides access to the EntertainmentInfothek.db
// Copyright (C) 2026 Sandra Scherer

using System;
using System.Collections.Generic;
using System.Text;

namespace WikiExporter.Persistence.Entities
{
    /// <summary>
    /// EF representation of the SQLite table <c>SoundMix</c>.
    /// The entity is persistence-only.
    /// </summary>
    public class SoundMixEntity
    {
        // --- Fields ---

        /// <summary>Maps to <c>ID</c>.</summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>Maps to <c>OriginalName</c>.</summary>
        public string? OriginalName { get; set; }

        /// <summary>Maps to <c>Details</c>.</summary>
        public string? Details { get; set; }

        /// <summary>Maps to <c>Notes</c>.</summary>
        public string? Notes { get; set; }

        /// <summary>Maps to <c>StatusID</c>.</summary>
        public string? StatusId { get; set; }

        /// <summary>Maps to <c>LastUpdated</c>.</summary>
        public string? LastUpdated { get; set; }


        // --- Foreign Key Navigation Properties ---

        /// <summary>Navigation for FK <c>StatusID</c> to <c>Status</c>.</summary>
        public StatusEntity? StatusEntity { get; set; }


        // --- Dependent Navigation Properties ---

        ///// <summary>Dependent rows referencing this SoundMix.</summary>
        //public ICollection<MovieSoundMixEntity> MovieSoundMixs { get; set; } = new List<MovieSoundMixEntity>();

        ///// <summary>Dependent rows referencing this SoundMix.</summary>
        //public ICollection<SeriesSoundMixEntity> SeriesSoundMixs { get; set; } = new List<SeriesSoundMixEntity>();
    }
}
