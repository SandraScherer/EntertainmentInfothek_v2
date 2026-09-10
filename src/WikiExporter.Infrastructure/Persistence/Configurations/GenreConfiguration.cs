using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Tabelle Genre.
/// </summary>
public sealed class GenreConfiguration
    : IEntityTypeConfiguration<GenreEntity>
{
    public void Configure(
        EntityTypeBuilder<GenreEntity> builder)
    {
        builder.ToTable("Genre");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.GermanName)
            .HasColumnName("GermanName");

        builder.Property(x => x.EnglishName)
            .HasColumnName("EnglishName");
    }
}
