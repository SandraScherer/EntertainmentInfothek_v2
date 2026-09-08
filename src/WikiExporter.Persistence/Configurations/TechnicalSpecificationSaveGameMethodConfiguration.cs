using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification_SaveGameMethod</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationSaveGameMethodConfiguration : IEntityTypeConfiguration<TechnicalSpecificationSaveGameMethod>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationSaveGameMethod> builder)
    {
        builder.ToTable("TechnicalSpecification_SaveGameMethod");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationId).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.SaveGameMethodId).HasColumnName("SaveGameMethodID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_SaveGameMethod.SaveGameMethodID -> SaveGameMethod.ID
        builder.HasOne(x => x.SaveGameMethod).WithMany(x => x.TechnicalSpecificationSaveGameMethods).HasForeignKey(x => x.SaveGameMethodId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SaveGameMethod.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TechnicalSpecificationSaveGameMethods).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_SaveGameMethod.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification).WithMany(x => x.TechnicalSpecificationSaveGameMethods).HasForeignKey(x => x.TechnicalSpecificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
