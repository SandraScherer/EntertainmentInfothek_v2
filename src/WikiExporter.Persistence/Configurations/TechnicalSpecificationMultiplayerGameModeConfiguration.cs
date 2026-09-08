using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification_MultiplayerGameMode</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationMultiplayerGameModeConfiguration : IEntityTypeConfiguration<TechnicalSpecificationMultiplayerGameMode>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationMultiplayerGameMode> builder)
    {
        builder.ToTable("TechnicalSpecification_MultiplayerGameMode");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationId).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.MultiplayerGameModeId).HasColumnName("MultiplayerGameModeID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_MultiplayerGameMode.MultiplayerGameModeID -> MultiplayerGameMode.ID
        builder.HasOne(x => x.MultiplayerGameMode).WithMany(x => x.TechnicalSpecificationMultiplayerGameModes).HasForeignKey(x => x.MultiplayerGameModeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_MultiplayerGameMode.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TechnicalSpecificationMultiplayerGameModes).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_MultiplayerGameMode.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification).WithMany(x => x.TechnicalSpecificationMultiplayerGameModes).HasForeignKey(x => x.TechnicalSpecificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
