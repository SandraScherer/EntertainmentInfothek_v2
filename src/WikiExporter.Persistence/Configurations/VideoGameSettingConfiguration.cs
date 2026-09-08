using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_Setting</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameSettingConfiguration : IEntityTypeConfiguration<VideoGameSetting>
{
    public void Configure(EntityTypeBuilder<VideoGameSetting> builder)
    {
        builder.ToTable("VideoGame_Setting");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.SettingId).HasColumnName("SettingID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Setting.SettingID -> Setting.ID
        builder.HasOne(x => x.Setting).WithMany(x => x.VideoGameSettings).HasForeignKey(x => x.SettingId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Setting.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGameSettings).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Setting.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.VideoGameSettings).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
