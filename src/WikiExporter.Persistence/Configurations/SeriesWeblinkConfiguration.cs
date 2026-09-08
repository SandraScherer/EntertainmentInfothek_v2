using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Weblink</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesWeblinkConfiguration : IEntityTypeConfiguration<SeriesWeblink>
{
    public void Configure(EntityTypeBuilder<SeriesWeblink> builder)
    {
        builder.ToTable("Series_Weblink");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.WeblinkId).HasColumnName("WeblinkID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Weblink.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesWeblinks).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Weblink.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesWeblinks).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Weblink.WeblinkID -> Weblink.ID
        builder.HasOne(x => x.Weblink).WithMany(x => x.SeriesWeblinks).HasForeignKey(x => x.WeblinkId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
