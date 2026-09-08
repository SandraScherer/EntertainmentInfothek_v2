using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification_CopyProtection</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationCopyProtectionConfiguration : IEntityTypeConfiguration<TechnicalSpecificationCopyProtection>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationCopyProtection> builder)
    {
        builder.ToTable("TechnicalSpecification_CopyProtection");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationId).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.CopyProtectionId).HasColumnName("CopyProtectionID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_CopyProtection.CopyProtectionID -> CopyProtection.ID
        builder.HasOne(x => x.CopyProtection).WithMany(x => x.TechnicalSpecificationCopyProtections).HasForeignKey(x => x.CopyProtectionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_CopyProtection.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TechnicalSpecificationCopyProtections).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_CopyProtection.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification).WithMany(x => x.TechnicalSpecificationCopyProtections).HasForeignKey(x => x.TechnicalSpecificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
