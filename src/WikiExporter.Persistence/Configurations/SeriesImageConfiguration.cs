using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Image</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesImageConfiguration : IEntityTypeConfiguration<SeriesImage>
{
    public void Configure(EntityTypeBuilder<SeriesImage> builder)
    {
        builder.ToTable("Series_Image");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.ImageId).HasColumnName("ImageID");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Image.ImageID -> Image.ID
        builder.HasOne(x => x.Image).WithMany(x => x.SeriesImages).HasForeignKey(x => x.ImageId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Image.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesImages).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Image.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesImages).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
