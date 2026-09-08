using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification_SupportedVideoMode</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationSupportedVideoModeConfiguration : IEntityTypeConfiguration<TechnicalSpecificationSupportedVideoMode>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationSupportedVideoMode> builder)
    {
        builder.ToTable("TechnicalSpecification_SupportedVideoMode");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationId).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.VideoModeId).HasColumnName("VideoModeID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_SupportedVideoMode.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TechnicalSpecificationSupportedVideoModes).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedVideoMode.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification).WithMany(x => x.TechnicalSpecificationSupportedVideoModes).HasForeignKey(x => x.TechnicalSpecificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SupportedVideoMode.VideoModeID -> VideoMode.ID
        builder.HasOne(x => x.VideoMode).WithMany(x => x.TechnicalSpecificationSupportedVideoModes).HasForeignKey(x => x.VideoModeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
