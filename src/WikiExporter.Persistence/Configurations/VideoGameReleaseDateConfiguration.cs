using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_ReleaseDate</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameReleaseDateConfiguration : IEntityTypeConfiguration<VideoGameReleaseDate>
{
    public void Configure(EntityTypeBuilder<VideoGameReleaseDate> builder)
    {
        builder.ToTable("VideoGame_ReleaseDate");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
        builder.Property(x => x.PlatformId).HasColumnName("PlatformID");
        builder.Property(x => x.EnglishDescription).HasColumnName("EnglishDescription");
        builder.Property(x => x.GermanDescription).HasColumnName("GermanDescription");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_ReleaseDate.PlatformID -> Platform.ID
        builder.HasOne(x => x.Platform).WithMany(x => x.VideoGameReleaseDates).HasForeignKey(x => x.PlatformId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_ReleaseDate.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGameReleaseDates).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_ReleaseDate.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.VideoGameReleaseDates).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
