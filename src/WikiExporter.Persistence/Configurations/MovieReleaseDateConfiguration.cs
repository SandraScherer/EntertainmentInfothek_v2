using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_ReleaseDate</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieReleaseDateConfiguration : IEntityTypeConfiguration<MovieReleaseDate>
{
    public void Configure(EntityTypeBuilder<MovieReleaseDate> builder)
    {
        builder.ToTable("Movie_ReleaseDate");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
        builder.Property(x => x.EnglishDescription).HasColumnName("EnglishDescription");
        builder.Property(x => x.GermanDescription).HasColumnName("GermanDescription");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_ReleaseDate.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieReleaseDates).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_ReleaseDate.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieReleaseDates).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
