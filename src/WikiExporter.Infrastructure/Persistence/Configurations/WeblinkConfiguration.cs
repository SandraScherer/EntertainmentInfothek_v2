using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Tabelle Weblink.
/// </summary>
public sealed class WeblinkConfiguration
    : IEntityTypeConfiguration<WeblinkEntity>
{
    public void Configure(
        EntityTypeBuilder<WeblinkEntity> builder)
    {
        builder.ToTable("Weblink");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.Url)
            .HasColumnName("URL");

        builder.Property(x => x.EnglishName)
            .HasColumnName("EnglishName");

        builder.Property(x => x.GermanName)
            .HasColumnName("GermanName");
    }
}
