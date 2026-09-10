using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Tabelle Status.
/// </summary>
public sealed class StatusConfiguration
    : IEntityTypeConfiguration<StatusEntity>
{
    public void Configure(
        EntityTypeBuilder<StatusEntity> builder)
    {
        builder.ToTable("Status");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.GermanName)
            .HasColumnName("GermanName");

        builder.Property(x => x.EnglishName)
            .HasColumnName("EnglishName");
    }
}
