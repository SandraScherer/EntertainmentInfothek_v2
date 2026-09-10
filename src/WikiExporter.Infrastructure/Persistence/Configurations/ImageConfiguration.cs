using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Tabelle Image.
/// </summary>
public sealed class ImageConfiguration
    : IEntityTypeConfiguration<ImageEntity>
{
    public void Configure(
        EntityTypeBuilder<ImageEntity> builder)
    {
        builder.ToTable("Image");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.FileName)
            .HasColumnName("FileName");

        builder.Property(x => x.GermanDescription)
            .HasColumnName("GermanDescription");

        builder.Property(x => x.EnglishDescription)
            .HasColumnName("EnglishDescription");
    }
}
