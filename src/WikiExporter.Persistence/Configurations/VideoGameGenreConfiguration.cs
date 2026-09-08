using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_Genre</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameGenreConfiguration : IEntityTypeConfiguration<VideoGameGenre>
{
    public void Configure(EntityTypeBuilder<VideoGameGenre> builder)
    {
        builder.ToTable("VideoGame_Genre");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.GenreId).HasColumnName("GenreID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Genre.GenreID -> Genre.ID
        builder.HasOne(x => x.Genre).WithMany(x => x.VideoGameGenres).HasForeignKey(x => x.GenreId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Genre.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGameGenres).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Genre.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.VideoGameGenres).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
