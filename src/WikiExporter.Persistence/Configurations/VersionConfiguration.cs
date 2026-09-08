using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Version</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VersionConfiguration : IEntityTypeConfiguration<Version>
{
    public void Configure(EntityTypeBuilder<Version> builder)
    {
        builder.ToTable("Version");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalName).HasColumnName("OriginalName");
        builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
        builder.Property(x => x.PlatformId).HasColumnName("PlatformID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Version.PlatformID -> Platform.ID
        builder.HasOne(x => x.Platform).WithMany(x => x.Versions).HasForeignKey(x => x.PlatformId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Version.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.Versions).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Version.TypeID -> Type.ID
        builder.HasOne(x => x.Type).WithMany(x => x.Versions).HasForeignKey(x => x.TypeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
