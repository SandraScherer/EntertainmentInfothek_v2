using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Genre</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesGenreConfiguration : IEntityTypeConfiguration<SeriesGenre>
{
    public void Configure(EntityTypeBuilder<SeriesGenre> builder)
    {
        builder.ToTable("Series_Genre");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.GenreId).HasColumnName("GenreID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Genre.GenreID -> Genre.ID
        builder.HasOne(x => x.Genre).WithMany(x => x.SeriesGenres).HasForeignKey(x => x.GenreId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Genre.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesGenres).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Genre.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesGenres).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
