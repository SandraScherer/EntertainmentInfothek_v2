using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Book_Text</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class BookTextConfiguration : IEntityTypeConfiguration<BookText>
{
    public void Configure(EntityTypeBuilder<BookText> builder)
    {
        builder.ToTable("Book_Text");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookId).HasColumnName("BookID");
        builder.Property(x => x.TextId).HasColumnName("TextID");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_Text.BookID -> Book.ID
        builder.HasOne(x => x.Book).WithMany(x => x.BookTexts).HasForeignKey(x => x.BookId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Text.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.BookTexts).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Text.TextID -> Text.ID
        builder.HasOne(x => x.Text).WithMany(x => x.BookTexts).HasForeignKey(x => x.TextId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Text.TypeID -> TextType.ID
        builder.HasOne(x => x.Type).WithMany(x => x.BookTexts).HasForeignKey(x => x.TypeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
