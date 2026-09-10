using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Movie_Genre.
/// </summary>
public sealed class MovieGenreConfiguration
    : IEntityTypeConfiguration<MovieGenreEntity>
{
    public void Configure(
        EntityTypeBuilder<MovieGenreEntity> builder)
    {
        builder.ToTable("Movie_Genre");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.MovieId)
            .HasColumnName("MovieID");

        builder.Property(x => x.GenreId)
            .HasColumnName("GenreID");

        builder.HasOne(x => x.Movie)
            .WithMany(x => x.Genres)
            .HasForeignKey(x => x.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Genre)
            .WithMany()
            .HasForeignKey(x => x.GenreId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
