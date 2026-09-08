using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Book_Weblink</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class BookWeblinkConfiguration : IEntityTypeConfiguration<BookWeblink>
{
    public void Configure(EntityTypeBuilder<BookWeblink> builder)
    {
        builder.ToTable("Book_Weblink");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookId).HasColumnName("BookID");
        builder.Property(x => x.WeblinkId).HasColumnName("WeblinkID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_Weblink.BookID -> Book.ID
        builder.HasOne(x => x.Book).WithMany(x => x.BookWeblinks).HasForeignKey(x => x.BookId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Weblink.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.BookWeblinks).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Weblink.WeblinkID -> Weblink.ID
        builder.HasOne(x => x.Weblink).WithMany(x => x.BookWeblinks).HasForeignKey(x => x.WeblinkId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
