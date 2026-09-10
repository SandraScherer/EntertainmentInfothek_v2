using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Tabelle Person.
/// </summary>
public sealed class PersonConfiguration
    : IEntityTypeConfiguration<PersonEntity>
{
    public void Configure(
        EntityTypeBuilder<PersonEntity> builder)
    {
        builder.ToTable("Person");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.FirstName)
            .HasColumnName("FirstName");

        builder.Property(x => x.LastName)
            .HasColumnName("LastName");
    }
}
