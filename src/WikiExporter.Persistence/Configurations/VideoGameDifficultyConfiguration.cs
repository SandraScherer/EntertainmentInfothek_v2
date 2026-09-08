using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_Difficulty</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameDifficultyConfiguration : IEntityTypeConfiguration<VideoGameDifficulty>
{
    public void Configure(EntityTypeBuilder<VideoGameDifficulty> builder)
    {
        builder.ToTable("VideoGame_Difficulty");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.DifficultyId).HasColumnName("DifficultyID");
        builder.Property(x => x.PlatformId).HasColumnName("PlatformID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Difficulty.DifficultyID -> Difficulty.ID
        builder.HasOne(x => x.Difficulty).WithMany(x => x.VideoGameDifficultys).HasForeignKey(x => x.DifficultyId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Difficulty.PlatformID -> Platform.ID
        builder.HasOne(x => x.Platform).WithMany(x => x.VideoGameDifficultys).HasForeignKey(x => x.PlatformId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Difficulty.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGameDifficultys).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Difficulty.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.VideoGameDifficultys).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
