using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_FilmingLocation</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesFilmingLocationConfiguration : IEntityTypeConfiguration<SeriesFilmingLocation>
{
    public void Configure(EntityTypeBuilder<SeriesFilmingLocation> builder)
    {
        builder.ToTable("Series_FilmingLocation");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.LocationId).HasColumnName("LocationID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_FilmingLocation.LocationID -> Location.ID
        builder.HasOne(x => x.Location).WithMany(x => x.SeriesFilmingLocations).HasForeignKey(x => x.LocationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_FilmingLocation.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesFilmingLocations).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_FilmingLocation.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesFilmingLocations).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
