using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Camera</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesCameraConfiguration : IEntityTypeConfiguration<SeriesCamera>
{
    public void Configure(EntityTypeBuilder<SeriesCamera> builder)
    {
        builder.ToTable("Series_Camera");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.CameraId).HasColumnName("CameraID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Camera.CameraID -> Camera.ID
        builder.HasOne(x => x.Camera).WithMany(x => x.SeriesCameras).HasForeignKey(x => x.CameraId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Camera.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesCameras).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Camera.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesCameras).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
