using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_User</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameUserConfiguration : IEntityTypeConfiguration<VideoGameUser>
{
    public void Configure(EntityTypeBuilder<VideoGameUser> builder)
    {
        builder.ToTable("VideoGame_User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.UserId).HasColumnName("UserID");
        builder.Property(x => x.EditionId).HasColumnName("EditionID");
        builder.Property(x => x.UserStatusId).HasColumnName("UserStatusID");
        builder.Property(x => x.PriorityId).HasColumnName("PriorityID");
        builder.Property(x => x.EnglishExplanation).HasColumnName("EnglishExplanation");
        builder.Property(x => x.GermanExplanation).HasColumnName("GermanExplanation");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_User.EditionID -> Edition.ID
        builder.HasOne(x => x.Edition).WithMany(x => x.VideoGameUsers).HasForeignKey(x => x.EditionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_User.PriorityID -> Priority.ID
        builder.HasOne(x => x.Priority).WithMany(x => x.VideoGameUsers).HasForeignKey(x => x.PriorityId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_User.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGameUserStatuss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_User.UserID -> User.ID
        builder.HasOne(x => x.User).WithMany(x => x.VideoGameUsers).HasForeignKey(x => x.UserId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_User.UserStatusID -> Status.ID
        builder.HasOne(x => x.UserStatus).WithMany(x => x.VideoGameUserUserStatuss).HasForeignKey(x => x.UserStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_User.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.VideoGameUsers).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
