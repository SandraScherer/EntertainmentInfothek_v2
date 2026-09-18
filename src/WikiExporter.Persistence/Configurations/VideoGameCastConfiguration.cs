using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_Cast</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameCastConfiguration : IEntityTypeConfiguration<VideoGameCastEntity>
{
    public void Configure(EntityTypeBuilder<VideoGameCastEntity> builder)
    {
        builder.ToTable("VideoGame_Cast");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.ActorId).HasColumnName("ActorID");
        builder.Property(x => x.EnglishDubberId).HasColumnName("EnglishDubberID");
        builder.Property(x => x.GermanDubberId).HasColumnName("GermanDubberID");
        builder.Property(x => x.CharacterId).HasColumnName("CharacterID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Cast.ActorID -> Person.ID
        builder.HasOne(x => x.Actor).WithMany().HasForeignKey(x => x.ActorId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Cast.CharacterID -> Person.ID
        builder.HasOne(x => x.Character).WithMany().HasForeignKey(x => x.CharacterId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Cast.EnglishDubberID -> Person.ID
        builder.HasOne(x => x.EnglishDubber).WithMany().HasForeignKey(x => x.EnglishDubberId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Cast.GermanDubberID -> Person.ID
        builder.HasOne(x => x.GermanDubber).WithMany().HasForeignKey(x => x.GermanDubberId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Cast.StatusID -> Status.ID
        builder.HasOne(x => x.StatusEntity).WithMany().HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Cast.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGameEntity).WithMany().HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
