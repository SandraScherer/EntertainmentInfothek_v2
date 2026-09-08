using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_Version</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameVersionConfiguration : IEntityTypeConfiguration<VideoGameVersion>
{
    public void Configure(EntityTypeBuilder<VideoGameVersion> builder)
    {
        builder.ToTable("VideoGame_Version");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.VersionId).HasColumnName("VersionID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Version.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGameVersions).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Version.VersionID -> Version.ID
        builder.HasOne(x => x.Version).WithMany(x => x.VideoGameVersions).HasForeignKey(x => x.VersionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Version.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.VideoGameVersions).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
