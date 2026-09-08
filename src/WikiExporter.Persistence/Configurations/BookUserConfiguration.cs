using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Book_User</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class BookUserConfiguration : IEntityTypeConfiguration<BookUser>
{
    public void Configure(EntityTypeBuilder<BookUser> builder)
    {
        builder.ToTable("Book_User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookId).HasColumnName("BookID");
        builder.Property(x => x.UserId).HasColumnName("UserID");
        builder.Property(x => x.PublicationId).HasColumnName("PublicationID");
        builder.Property(x => x.UserStatusId).HasColumnName("UserStatusID");
        builder.Property(x => x.PriorityId).HasColumnName("PriorityID");
        builder.Property(x => x.EnglishExplanation).HasColumnName("EnglishExplanation");
        builder.Property(x => x.GermanExplanation).HasColumnName("GermanExplanation");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_User.BookID -> Book.ID
        builder.HasOne(x => x.Book).WithMany(x => x.BookUsers).HasForeignKey(x => x.BookId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_User.PriorityID -> Priority.ID
        builder.HasOne(x => x.Priority).WithMany(x => x.BookUsers).HasForeignKey(x => x.PriorityId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_User.PublicationID -> Publication.ID
        builder.HasOne(x => x.Publication).WithMany(x => x.BookUsers).HasForeignKey(x => x.PublicationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_User.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.BookUserStatuss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_User.UserID -> User.ID
        builder.HasOne(x => x.User).WithMany(x => x.BookUsers).HasForeignKey(x => x.UserId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_User.UserStatusID -> Status.ID
        builder.HasOne(x => x.UserStatus).WithMany(x => x.BookUserUserStatuss).HasForeignKey(x => x.UserStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
