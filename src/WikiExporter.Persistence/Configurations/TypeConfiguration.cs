using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Type</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TypeConfiguration : IEntityTypeConfiguration<Type>
{
    public void Configure(EntityTypeBuilder<Type> builder)
    {
        builder.ToTable("Type");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EnglishName).HasColumnName("EnglishName");
        builder.Property(x => x.GermanName).HasColumnName("GermanName");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Type.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.Types).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
