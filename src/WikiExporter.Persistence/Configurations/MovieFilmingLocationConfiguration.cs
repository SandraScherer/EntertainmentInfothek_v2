using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_FilmingLocation</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieFilmingLocationConfiguration : IEntityTypeConfiguration<MovieFilmingLocationEntity>
{
    public void Configure(EntityTypeBuilder<MovieFilmingLocationEntity> builder)
    {
        builder.ToTable("Movie_FilmingLocation");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.LocationId).HasColumnName("LocationID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_FilmingLocation.LocationID -> Location.ID
        builder.HasOne(x => x.LocationEntity).WithMany().HasForeignKey(x => x.LocationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_FilmingLocation.MovieID -> Movie.ID
        builder.HasOne(x => x.MovieEntity).WithMany().HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_FilmingLocation.StatusID -> Status.ID
        builder.HasOne(x => x.StatusEntity).WithMany().HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
