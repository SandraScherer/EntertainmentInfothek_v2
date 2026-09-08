using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_Language</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameLanguageConfiguration : IEntityTypeConfiguration<VideoGameLanguage>
{
    public void Configure(EntityTypeBuilder<VideoGameLanguage> builder)
    {
        builder.ToTable("VideoGame_Language");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.LanguageId).HasColumnName("LanguageID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Language.LanguageID -> Language.ID
        builder.HasOne(x => x.Language).WithMany(x => x.VideoGameLanguages).HasForeignKey(x => x.LanguageId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Language.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGameLanguages).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Language.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.VideoGameLanguages).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
