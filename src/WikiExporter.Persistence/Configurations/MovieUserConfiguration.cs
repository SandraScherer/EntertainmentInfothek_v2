using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_User</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieUserConfiguration : IEntityTypeConfiguration<MovieUser>
{
    public void Configure(EntityTypeBuilder<MovieUser> builder)
    {
        builder.ToTable("Movie_User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
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

        // FK: Movie_User.EditionID -> Edition.ID
        builder.HasOne(x => x.Edition).WithMany(x => x.MovieUsers).HasForeignKey(x => x.EditionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_User.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieUsers).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_User.PriorityID -> Priority.ID
        builder.HasOne(x => x.Priority).WithMany(x => x.MovieUsers).HasForeignKey(x => x.PriorityId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_User.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieUserStatuss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_User.UserID -> User.ID
        builder.HasOne(x => x.User).WithMany(x => x.MovieUsers).HasForeignKey(x => x.UserId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_User.UserStatusID -> Status.ID
        builder.HasOne(x => x.UserStatus).WithMany(x => x.MovieUserUserStatuss).HasForeignKey(x => x.UserStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
