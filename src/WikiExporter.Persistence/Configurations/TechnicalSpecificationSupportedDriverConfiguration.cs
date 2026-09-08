using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification_SupportedDriver</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationSupportedDriverConfiguration : IEntityTypeConfiguration<TechnicalSpecificationSupportedDriver>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationSupportedDriver> builder)
    {
        builder.ToTable("TechnicalSpecification_SupportedDriver");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationId).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.DriverId).HasColumnName("DriverID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_SupportedDriver.DriverID -> Driver.ID
        builder.HasOne(x => x.Driver).WithMany(x => x.TechnicalSpecificationSupportedDrivers).HasForeignKey(x => x.DriverId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedDriver.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TechnicalSpecificationSupportedDrivers).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedDriver.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification).WithMany(x => x.TechnicalSpecificationSupportedDrivers).HasForeignKey(x => x.TechnicalSpecificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
