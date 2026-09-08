using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_FilmingDate</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesFilmingDateConfiguration : IEntityTypeConfiguration<SeriesFilmingDate>
{
    public void Configure(EntityTypeBuilder<SeriesFilmingDate> builder)
    {
        builder.ToTable("Series_FilmingDate");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.StartDate).HasColumnName("StartDate");
        builder.Property(x => x.EndDate).HasColumnName("EndDate");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_FilmingDate.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesFilmingDates).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_FilmingDate.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesFilmingDates).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
