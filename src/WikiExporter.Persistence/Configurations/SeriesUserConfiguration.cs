using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_User</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesUserConfiguration : IEntityTypeConfiguration<SeriesUserEntity>
{
    public void Configure(EntityTypeBuilder<SeriesUserEntity> builder)
    {
        builder.ToTable("Series_User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
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

        // FK: Series_User.EditionID -> Edition.ID
        builder.HasOne(x => x.EditionEntity).WithMany().HasForeignKey(x => x.EditionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_User.PriorityID -> Priority.ID
        builder.HasOne(x => x.PriorityEntity).WithMany().HasForeignKey(x => x.PriorityId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_User.SeriesID -> Series.ID
        builder.HasOne(x => x.SeriesEntity).WithMany().HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_User.StatusID -> Status.ID
        builder.HasOne(x => x.StatusEntity).WithMany().HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_User.UserID -> User.ID
        builder.HasOne(x => x.UserEntity).WithMany().HasForeignKey(x => x.UserId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_User.UserStatusID -> Status.ID
        builder.HasOne(x => x.UserStatus).WithMany().HasForeignKey(x => x.UserStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
