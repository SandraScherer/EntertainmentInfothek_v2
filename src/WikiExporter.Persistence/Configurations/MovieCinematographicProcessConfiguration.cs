using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_CinematographicProcess</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieCinematographicProcessConfiguration : IEntityTypeConfiguration<MovieCinematographicProcess>
{
    public void Configure(EntityTypeBuilder<MovieCinematographicProcess> builder)
    {
        builder.ToTable("Movie_CinematographicProcess");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.CinematographicProcessId).HasColumnName("CinematographicProcessID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_CinematographicProcess.CinematographicProcessID -> CinematographicProcess.ID
        builder.HasOne(x => x.CinematographicProcess).WithMany(x => x.MovieCinematographicProcesss).HasForeignKey(x => x.CinematographicProcessId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_CinematographicProcess.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieCinematographicProcesss).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_CinematographicProcess.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieCinematographicProcesss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
