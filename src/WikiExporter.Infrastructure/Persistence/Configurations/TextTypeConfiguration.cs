using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Tabelle TextType.
/// </summary>
public sealed class TextTypeConfiguration
    : IEntityTypeConfiguration<TextTypeEntity>
{
    public void Configure(
        EntityTypeBuilder<TextTypeEntity> builder)
    {
        builder.ToTable("TextType");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.EnglishName)
            .HasColumnName("EnglishName");

        builder.Property(x => x.GermanName)
            .HasColumnName("GermanName");
    }
}
