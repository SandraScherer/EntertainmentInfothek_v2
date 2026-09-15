using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Image_Source</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class ImageSourceConfiguration : IEntityTypeConfiguration<ImageSourceEntity>
{
    public void Configure(EntityTypeBuilder<ImageSourceEntity> builder)
    {
        builder.ToTable("Image_Source");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.ImageId).HasColumnName("ImageID");
        builder.Property(x => x.CompanyId).HasColumnName("CompanyID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Image_Source.CompanyID -> Company.ID
        builder.HasOne(x => x.CompanyEntity).WithMany(x => x.ImageSources).HasForeignKey(x => x.CompanyId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Image_Source.ImageID -> Image.ID
        builder.HasOne(x => x.ImageEntity).WithMany(x => x.ImageSources).HasForeignKey(x => x.ImageId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Image_Source.StatusID -> Status.ID
        builder.HasOne(x => x.StatusEntity).WithMany(x => x.ImageSources).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
