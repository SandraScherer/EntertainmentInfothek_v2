using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_Perspective</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGamePerspectiveConfiguration : IEntityTypeConfiguration<VideoGamePerspective>
{
    public void Configure(EntityTypeBuilder<VideoGamePerspective> builder)
    {
        builder.ToTable("VideoGame_Perspective");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.PerspectiveId).HasColumnName("PerspectiveID");
        builder.Property(x => x.PlatformId).HasColumnName("PlatformID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Perspective.PerspectiveID -> Perspective.ID
        builder.HasOne(x => x.Perspective).WithMany(x => x.VideoGamePerspectives).HasForeignKey(x => x.PerspectiveId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Perspective.PlatformID -> Platform.ID
        builder.HasOne(x => x.Platform).WithMany(x => x.VideoGamePerspectives).HasForeignKey(x => x.PlatformId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Perspective.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGamePerspectives).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Perspective.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.VideoGamePerspectives).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
