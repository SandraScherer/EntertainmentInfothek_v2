using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Country</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesCountryConfiguration : IEntityTypeConfiguration<SeriesCountry>
{
    public void Configure(EntityTypeBuilder<SeriesCountry> builder)
    {
        builder.ToTable("Series_Country");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.CountryId).HasColumnName("CountryID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Country.CountryID -> Country.ID
        builder.HasOne(x => x.Country).WithMany(x => x.SeriesCountrys).HasForeignKey(x => x.CountryId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Country.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesCountrys).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Country.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesCountrys).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
