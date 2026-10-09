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
    /// Explicit EF Core mapping for <c>Certification</c>.
    /// No conventions are relied upon for columns/FKs.
    /// </summary>
    public class CertificationConfiguration
        : IEntityTypeConfiguration<CertificationEntity>
    {
        // --- Methods ---

        public void Configure(
            EntityTypeBuilder<CertificationEntity> builder)
        {
            builder.ToTable("Certification");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(x => x.OriginalName)
                .HasColumnName("OriginalName");

            builder.Property(x => x.ImageId)
                .HasColumnName("ImageID");

            builder.Property(x => x.CountryId)
                .HasColumnName("CountryID");

            builder.Property(x => x.Details)
                .HasColumnName("Details");

            builder.Property(x => x.Notes)
                .HasColumnName("Notes");

            builder.Property(x => x.StatusId)
                .HasColumnName("StatusID");

            builder.Property(x => x.LastUpdated)
                .HasColumnName("LastUpdated");

            // FK: Certification.ImageID -> Image.ID
            builder.HasOne(x => x.ImageEntity)
                .WithMany()
                .HasForeignKey(x => x.ImageId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // FK: Certification.CountryID -> Country.ID
            builder.HasOne(x => x.CountryEntity)
                .WithMany()
                .HasForeignKey(x => x.CountryId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // FK: Certification.StatusID -> Status.ID
            builder.HasOne(x => x.StatusEntity)
                .WithMany()
                .HasForeignKey(x => x.StatusId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
