using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification_SupportedAdditionalHardware</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationSupportedAdditionalHardwareConfiguration : IEntityTypeConfiguration<TechnicalSpecificationSupportedAdditionalHardware>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationSupportedAdditionalHardware> builder)
    {
        builder.ToTable("TechnicalSpecification_SupportedAdditionalHardware");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationId).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.HardwareId).HasColumnName("HardwareID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_SupportedAdditionalHardware.HardwareID -> Hardware.ID
        builder.HasOne(x => x.Hardware).WithMany(x => x.TechnicalSpecificationSupportedAdditionalHardwares).HasForeignKey(x => x.HardwareId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedAdditionalHardware.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TechnicalSpecificationSupportedAdditionalHardwares).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedAdditionalHardware.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification).WithMany(x => x.TechnicalSpecificationSupportedAdditionalHardwares).HasForeignKey(x => x.TechnicalSpecificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
