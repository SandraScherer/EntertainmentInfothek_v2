using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification_SupportedVideoResolution</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationSupportedVideoResolutionConfiguration : IEntityTypeConfiguration<TechnicalSpecificationSupportedVideoResolution>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationSupportedVideoResolution> builder)
    {
        builder.ToTable("TechnicalSpecification_SupportedVideoResolution");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationId).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.VideoResolutionId).HasColumnName("VideoResolutionID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_SupportedVideoResolution.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TechnicalSpecificationSupportedVideoResolutions).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedVideoResolution.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification).WithMany(x => x.TechnicalSpecificationSupportedVideoResolutions).HasForeignKey(x => x.TechnicalSpecificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedVideoResolution.VideoResolutionID -> VideoResolution.ID
        builder.HasOne(x => x.VideoResolution).WithMany(x => x.TechnicalSpecificationSupportedVideoResolutions).HasForeignKey(x => x.VideoResolutionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
