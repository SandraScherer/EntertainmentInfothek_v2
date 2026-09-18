using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_PrintedFilmFormat</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesPrintedFilmFormatConfiguration : IEntityTypeConfiguration<SeriesPrintedFilmFormatEntity>
{
    public void Configure(EntityTypeBuilder<SeriesPrintedFilmFormatEntity> builder)
    {
        builder.ToTable("Series_PrintedFilmFormat");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.FilmFormatId).HasColumnName("FilmFormatID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_PrintedFilmFormat.FilmFormatID -> FilmFormat.ID
        builder.HasOne(x => x.FilmFormatEntity).WithMany().HasForeignKey(x => x.FilmFormatId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_PrintedFilmFormat.SeriesID -> Series.ID
        builder.HasOne(x => x.SeriesEntity).WithMany().HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_PrintedFilmFormat.StatusID -> Status.ID
        builder.HasOne(x => x.StatusEntity).WithMany().HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
