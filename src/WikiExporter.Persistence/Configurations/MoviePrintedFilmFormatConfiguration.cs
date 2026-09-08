using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_PrintedFilmFormat</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MoviePrintedFilmFormatConfiguration : IEntityTypeConfiguration<MoviePrintedFilmFormat>
{
    public void Configure(EntityTypeBuilder<MoviePrintedFilmFormat> builder)
    {
        builder.ToTable("Movie_PrintedFilmFormat");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.FilmFormatId).HasColumnName("FilmFormatID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_PrintedFilmFormat.FilmFormatID -> FilmFormat.ID
        builder.HasOne(x => x.FilmFormat).WithMany(x => x.MoviePrintedFilmFormats).HasForeignKey(x => x.FilmFormatId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_PrintedFilmFormat.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MoviePrintedFilmFormats).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_PrintedFilmFormat.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MoviePrintedFilmFormats).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
