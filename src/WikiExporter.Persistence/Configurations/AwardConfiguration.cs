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
    /// Explicit EF Core mapping for <c>Award</c>.
    /// No conventions are relied upon for columns/FKs.
    /// </summary>
    public class AwardConfiguration
        : IEntityTypeConfiguration<AwardEntity>
    {
        // --- Methods ---

        public void Configure(
            EntityTypeBuilder<AwardEntity> builder)
        {
            builder.ToTable("Award");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(x => x.OriginalName)
                .HasColumnName("OriginalName");

            builder.Property(x => x.PresenterId)
                .HasColumnName("PresenterID");

            builder.Property(x => x.EnglishRole)
                .HasColumnName("EnglishRole");

            builder.Property(x => x.GermanRole)
                .HasColumnName("GermanRole");

            builder.Property(x => x.Details)
                .HasColumnName("Details");

            builder.Property(x => x.Notes)
                .HasColumnName("Notes");

            builder.Property(x => x.StatusId)
                .HasColumnName("StatusID");

            builder.Property(x => x.LastUpdated)
                .HasColumnName("LastUpdated");

            // FK: Award.PresenterID -> Company.ID
            builder.HasOne(x => x.Presenter)
                .WithMany()
                .HasForeignKey(x => x.PresenterId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // FK: Award.StatusID -> Status.ID
            builder.HasOne(x => x.StatusEntity)
                .WithMany()
                .HasForeignKey(x => x.StatusId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
