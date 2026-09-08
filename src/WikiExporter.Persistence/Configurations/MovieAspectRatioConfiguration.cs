using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_AspectRatio</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieAspectRatioConfiguration : IEntityTypeConfiguration<MovieAspectRatio>
{
    public void Configure(EntityTypeBuilder<MovieAspectRatio> builder)
    {
        builder.ToTable("Movie_AspectRatio");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.AspectRatioId).HasColumnName("AspectRatioID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_AspectRatio.AspectRatioID -> AspectRatio.ID
        builder.HasOne(x => x.AspectRatio).WithMany(x => x.MovieAspectRatios).HasForeignKey(x => x.AspectRatioId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_AspectRatio.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieAspectRatios).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_AspectRatio.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieAspectRatios).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
