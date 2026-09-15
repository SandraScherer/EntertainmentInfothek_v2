using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification_MacOSSprocket</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationMacOSSprocketConfiguration : IEntityTypeConfiguration<TechnicalSpecificationMacOSSprocketEntity>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationMacOSSprocketEntity> builder)
    {
        builder.ToTable("TechnicalSpecification_MacOSSprocket");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationId).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.MacOSSprocketId).HasColumnName("MacOSSprocketID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_MacOSSprocket.MacOSSprocketID -> MacOSSprocket.ID
        builder.HasOne(x => x.MacOSSprocketEntity).WithMany(x => x.TechnicalSpecificationMacOSSprockets).HasForeignKey(x => x.MacOSSprocketId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_MacOSSprocket.StatusID -> Status.ID
        builder.HasOne(x => x.StatusEntity).WithMany(x => x.TechnicalSpecificationMacOSSprockets).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_MacOSSprocket.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecificationEntity).WithMany(x => x.TechnicalSpecificationMacOSSprockets).HasForeignKey(x => x.TechnicalSpecificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
