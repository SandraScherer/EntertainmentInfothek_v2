using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Book_Language</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class BookLanguageConfiguration : IEntityTypeConfiguration<BookLanguage>
{
    public void Configure(EntityTypeBuilder<BookLanguage> builder)
    {
        builder.ToTable("Book_Language");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookId).HasColumnName("BookID");
        builder.Property(x => x.LanguageId).HasColumnName("LanguageID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_Language.BookID -> Book.ID
        builder.HasOne(x => x.Book).WithMany(x => x.BookLanguages).HasForeignKey(x => x.BookId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Language.LanguageID -> Language.ID
        builder.HasOne(x => x.Language).WithMany(x => x.BookLanguages).HasForeignKey(x => x.LanguageId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Language.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.BookLanguages).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
