using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification_RequiredAdditionalHardware</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationRequiredAdditionalHardwareConfiguration : IEntityTypeConfiguration<TechnicalSpecificationRequiredAdditionalHardware>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationRequiredAdditionalHardware> builder)
    {
        builder.ToTable("TechnicalSpecification_RequiredAdditionalHardware");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationId).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.HardwareId).HasColumnName("HardwareID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_RequiredAdditionalHardware.HardwareID -> Hardware.ID
        builder.HasOne(x => x.Hardware).WithMany(x => x.TechnicalSpecificationRequiredAdditionalHardwares).HasForeignKey(x => x.HardwareId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_RequiredAdditionalHardware.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TechnicalSpecificationRequiredAdditionalHardwares).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_RequiredAdditionalHardware.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification).WithMany(x => x.TechnicalSpecificationRequiredAdditionalHardwares).HasForeignKey(x => x.TechnicalSpecificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
