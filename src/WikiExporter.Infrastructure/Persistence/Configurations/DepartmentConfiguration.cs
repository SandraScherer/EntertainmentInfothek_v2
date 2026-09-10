using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Tabelle Department.
/// </summary>
public sealed class DepartmentConfiguration
    : IEntityTypeConfiguration<DepartmentEntity>
{
    public void Configure(
        EntityTypeBuilder<DepartmentEntity> builder)
    {
        builder.ToTable("Department");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.GermanName)
            .HasColumnName("GermanName");

        builder.Property(x => x.EnglishName)
            .HasColumnName("EnglishName");
    }
}
