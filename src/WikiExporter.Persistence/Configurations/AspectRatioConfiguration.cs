// WikiExporter.Persistence.dll: Provides access to the EntertainmentInfothek.db
// Copyright (C) 2026 Sandra Scherer

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations
{
    /// <summary>
    /// Explicit EF Core mapping for <c>AspectRatio</c>.
    /// No conventions are relied upon for columns/FKs.
    /// </summary>
    public class AspectRatioConfiguration
        : IEntityTypeConfiguration<AspectRatioEntity>
    {
        // --- Methods ---

        public void Configure(
            EntityTypeBuilder<AspectRatioEntity> builder)
        {
            builder.ToTable("AspectRatio");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(x => x.OriginalName)
                .HasColumnName("OriginalName");

            builder.Property(x => x.Details)
                .HasColumnName("Details");

            builder.Property(x => x.Notes)
                .HasColumnName("Notes");

            builder.Property(x => x.StatusId)
                .HasColumnName("StatusID");

            builder.Property(x => x.LastUpdated)
                .HasColumnName("LastUpdated");

            // FK: AspectRatio.StatusID -> Status.ID
            builder.HasOne(x => x.StatusEntity)
                .WithMany()
                .HasForeignKey(x => x.StatusId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
