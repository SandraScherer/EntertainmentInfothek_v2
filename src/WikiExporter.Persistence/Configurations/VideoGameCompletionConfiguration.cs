using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_Completion</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameCompletionConfiguration : IEntityTypeConfiguration<VideoGameCompletionEntity>
{
    public void Configure(EntityTypeBuilder<VideoGameCompletionEntity> builder)
    {
        builder.ToTable("VideoGame_Completion");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.CompletionStatusId).HasColumnName("CompletionStatusID");
        builder.Property(x => x.PlatformId).HasColumnName("PlatformID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Completion.CompletionStatusID -> Status.ID
        builder.HasOne(x => x.CompletionStatus).WithMany().HasForeignKey(x => x.CompletionStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Completion.PlatformID -> Platform.ID
        builder.HasOne(x => x.PlatformEntity).WithMany().HasForeignKey(x => x.PlatformId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Completion.StatusID -> Status.ID
        builder.HasOne(x => x.StatusEntity).WithMany().HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Completion.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGameEntity).WithMany().HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
