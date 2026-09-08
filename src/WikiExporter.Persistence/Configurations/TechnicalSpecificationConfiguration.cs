using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationConfiguration : IEntityTypeConfiguration<TechnicalSpecification>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecification> builder)
    {
        builder.ToTable("TechnicalSpecification");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.PlatformId).HasColumnName("PlatformID");
        builder.Property(x => x.BusinessModelId).HasColumnName("BusinessModelID");
        builder.Property(x => x.MinimumCPUClassId).HasColumnName("MinimumCPUClassID");
        builder.Property(x => x.MinimumOSClassId).HasColumnName("MinimumOSClassID");
        builder.Property(x => x.MinimumRAMId).HasColumnName("MinimumRAMID");
        builder.Property(x => x.MinimumDirectXId).HasColumnName("MinimumDirectXID");
        builder.Property(x => x.MinimumCDRomDriveSpeedId).HasColumnName("MinimumCDRomDriveSpeedID");
        builder.Property(x => x.MinimumVideoRAMId).HasColumnName("MinimumVideoRAMID");
        builder.Property(x => x.NoOfPlayersOffline).HasColumnName("NoOfPlayersOffline");
        builder.Property(x => x.NoOfPlayersOfflineMultitap).HasColumnName("NoOfPlayersOfflineMultitap");
        builder.Property(x => x.NoOfPlayersOnline).HasColumnName("NoOfPlayersOnline");
        builder.Property(x => x.EnglishAnnotation).HasColumnName("EnglishAnnotation");
        builder.Property(x => x.GermanAnnotation).HasColumnName("GermanAnnotation");
        builder.Property(x => x.MiscAttributes).HasColumnName("MiscAttributes");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification.BusinessModelID -> BusinessModel.ID
        builder.HasOne(x => x.BusinessModel).WithMany(x => x.TechnicalSpecifications).HasForeignKey(x => x.BusinessModelId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.MinimumCDRomDriveSpeedID -> CDROMDriveSpeed.ID
        builder.HasOne(x => x.MinimumCDRomDriveSpeed).WithMany(x => x.TechnicalSpecifications).HasForeignKey(x => x.MinimumCDRomDriveSpeedId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.MinimumCPUClassID -> CPU.ID
        builder.HasOne(x => x.MinimumCPUClass).WithMany(x => x.TechnicalSpecifications).HasForeignKey(x => x.MinimumCPUClassId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.MinimumDirectXID -> DirectX.ID
        builder.HasOne(x => x.MinimumDirectX).WithMany(x => x.TechnicalSpecifications).HasForeignKey(x => x.MinimumDirectXId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.MinimumOSClassID -> OperatingSystem.ID
        builder.HasOne(x => x.MinimumOSClass).WithMany(x => x.TechnicalSpecifications).HasForeignKey(x => x.MinimumOSClassId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.MinimumRAMID -> RAM.ID
        builder.HasOne(x => x.MinimumRAM).WithMany(x => x.TechnicalSpecificationMinimumRAMs).HasForeignKey(x => x.MinimumRAMId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.MinimumVideoRAMID -> RAM.ID
        builder.HasOne(x => x.MinimumVideoRAM).WithMany(x => x.TechnicalSpecificationMinimumVideoRAMs).HasForeignKey(x => x.MinimumVideoRAMId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.PlatformID -> Platform.ID
        builder.HasOne(x => x.Platform).WithMany(x => x.TechnicalSpecifications).HasForeignKey(x => x.PlatformId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TechnicalSpecifications).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.TechnicalSpecifications).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
