using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification_MultiplayerOption</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationMultiplayerOptionConfiguration : IEntityTypeConfiguration<TechnicalSpecificationMultiplayerOption>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationMultiplayerOption> builder)
    {
        builder.ToTable("TechnicalSpecification_MultiplayerOption");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationId).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.MultiplayerOptionId).HasColumnName("MultiplayerOptionID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_MultiplayerOption.MultiplayerOptionID -> MultiplayerOption.ID
        builder.HasOne(x => x.MultiplayerOption).WithMany(x => x.TechnicalSpecificationMultiplayerOptions).HasForeignKey(x => x.MultiplayerOptionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_MultiplayerOption.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TechnicalSpecificationMultiplayerOptions).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_MultiplayerOption.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification).WithMany(x => x.TechnicalSpecificationMultiplayerOptions).HasForeignKey(x => x.TechnicalSpecificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
