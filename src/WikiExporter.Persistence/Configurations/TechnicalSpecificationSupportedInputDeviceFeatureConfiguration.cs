using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification_SupportedInputDeviceFeature</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationSupportedInputDeviceFeatureConfiguration : IEntityTypeConfiguration<TechnicalSpecificationSupportedInputDeviceFeature>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationSupportedInputDeviceFeature> builder)
    {
        builder.ToTable("TechnicalSpecification_SupportedInputDeviceFeature");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationId).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.InputDeviceFeatureId).HasColumnName("InputDeviceFeatureID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_SupportedInputDeviceFeature.InputDeviceFeatureID -> InputDeviceFeature.ID
        builder.HasOne(x => x.InputDeviceFeature).WithMany(x => x.TechnicalSpecificationSupportedInputDeviceFeatures).HasForeignKey(x => x.InputDeviceFeatureId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedInputDeviceFeature.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TechnicalSpecificationSupportedInputDeviceFeatures).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedInputDeviceFeature.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification).WithMany(x => x.TechnicalSpecificationSupportedInputDeviceFeatures).HasForeignKey(x => x.TechnicalSpecificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
