using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Color</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesColorConfiguration : IEntityTypeConfiguration<SeriesColor>
{
    public void Configure(EntityTypeBuilder<SeriesColor> builder)
    {
        builder.ToTable("Series_Color");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.ColorId).HasColumnName("ColorID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Color.ColorID -> Color.ID
        builder.HasOne(x => x.Color).WithMany(x => x.SeriesColors).HasForeignKey(x => x.ColorId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Color.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesColors).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Color.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesColors).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
