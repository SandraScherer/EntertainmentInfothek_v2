using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_Image</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameImageConfiguration : IEntityTypeConfiguration<VideoGameImage>
{
    public void Configure(EntityTypeBuilder<VideoGameImage> builder)
    {
        builder.ToTable("VideoGame_Image");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.ImageId).HasColumnName("ImageID");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Image.ImageID -> Image.ID
        builder.HasOne(x => x.Image).WithMany(x => x.VideoGameImages).HasForeignKey(x => x.ImageId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Image.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGameImages).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Image.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.VideoGameImages).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
