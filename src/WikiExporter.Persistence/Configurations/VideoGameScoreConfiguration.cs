using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_Score</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameScoreConfiguration : IEntityTypeConfiguration<VideoGameScore>
{
    public void Configure(EntityTypeBuilder<VideoGameScore> builder)
    {
        builder.ToTable("VideoGame_Score");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.Score).HasColumnName("Score");
        builder.Property(x => x.Date).HasColumnName("Date");
        builder.Property(x => x.CompanyId).HasColumnName("CompanyID");
        builder.Property(x => x.PlatformId).HasColumnName("PlatformID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Score.CompanyID -> Company.ID
        builder.HasOne(x => x.Company).WithMany(x => x.VideoGameScores).HasForeignKey(x => x.CompanyId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Score.PlatformID -> Platform.ID
        builder.HasOne(x => x.Platform).WithMany(x => x.VideoGameScores).HasForeignKey(x => x.PlatformId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Score.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGameScores).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Score.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.VideoGameScores).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
