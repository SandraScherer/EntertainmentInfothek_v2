using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_FilmLength</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieFilmLengthConfiguration : IEntityTypeConfiguration<MovieFilmLength>
{
    public void Configure(EntityTypeBuilder<MovieFilmLength> builder)
    {
        builder.ToTable("Movie_FilmLength");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.Length).HasColumnName("Length");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_FilmLength.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieFilmLengths).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_FilmLength.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieFilmLengths).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
