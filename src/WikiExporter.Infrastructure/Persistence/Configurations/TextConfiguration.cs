using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Tabelle Text.
/// </summary>
public sealed class TextConfiguration
    : IEntityTypeConfiguration<TextEntity>
{
    public void Configure(
        EntityTypeBuilder<TextEntity> builder)
    {
        builder.ToTable("Text");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.Content)
            .HasColumnName("Content");
    }
}
