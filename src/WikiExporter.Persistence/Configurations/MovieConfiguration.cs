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
    /// Explicit EF Core mapping for <c>Movie</c>.
    /// No conventions are relied upon for columns/FKs.
    /// </summary>
    public class MovieConfiguration
        : IEntityTypeConfiguration<MovieEntity>
    {
        // --- Methods ---

        public void Configure(
            EntityTypeBuilder<MovieEntity> builder)
        {
            builder.ToTable("Movie");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(x => x.OriginalTitle)
                .HasColumnName("OriginalTitle");

            builder.Property(x => x.EnglishTitle)
                .HasColumnName("EnglishTitle");

            builder.Property(x => x.GermanTitle)
                .HasColumnName("GermanTitle");

            builder.Property(x => x.TypeId)
                .HasColumnName("TypeID");

            builder.Property(x => x.Budget)
                .HasColumnName("Budget");

            builder.Property(x => x.WorldwideGross)
                .HasColumnName("WorldwideGross");

            builder.Property(x => x.WorldwideGrossDate)
                .HasColumnName("WorldwideGrossDate");

            builder.Property(x => x.CastStatusId)
                .HasColumnName("CastStatusID");

            builder.Property(x => x.CrewStatusId)
                .HasColumnName("CrewStatusID");

            builder.Property(x => x.ConnectionId)
                .HasColumnName("ConnectionID");

            builder.Property(x => x.Details)
                .HasColumnName("Details");

            builder.Property(x => x.Notes)
                .HasColumnName("Notes");

            builder.Property(x => x.StatusId)
                .HasColumnName("StatusID");

            builder.Property(x => x.LastUpdated)
                .HasColumnName("LastUpdated");

            // FK: Movie.TypeID -> Type.ID
            builder.HasOne(x => x.TypeEntity)
                .WithMany()
                .HasForeignKey(x => x.TypeId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // FK: Movie.CastStatusID -> Status.ID
            builder.HasOne(x => x.CastStatus)
                .WithMany()
                .HasForeignKey(x => x.CastStatusId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // FK: Movie.CrewStatusID -> Status.ID
            builder.HasOne(x => x.CrewStatus)
                .WithMany()
                .HasForeignKey(x => x.CrewStatusId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // FK: Movie.ConnectionID -> Connection.ID
            builder.HasOne(x => x.ConnectionEntity)
                .WithMany()
                .HasForeignKey(x => x.ConnectionId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // FK: Movie.StatusID -> Status.ID
            builder.HasOne(x => x.StatusEntity)
                .WithMany()
                .HasForeignKey(x => x.StatusId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
