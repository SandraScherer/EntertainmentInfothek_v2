using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Book_Cast</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class BookCastConfiguration : IEntityTypeConfiguration<BookCast>
{
    public void Configure(EntityTypeBuilder<BookCast> builder)
    {
        builder.ToTable("Book_Cast");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookId).HasColumnName("BookID");
        builder.Property(x => x.CharacterId).HasColumnName("CharacterID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_Cast.BookID -> Book.ID
        builder.HasOne(x => x.Book).WithMany(x => x.BookCasts).HasForeignKey(x => x.BookId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Cast.CharacterID -> Person.ID
        builder.HasOne(x => x.Character).WithMany(x => x.BookCasts).HasForeignKey(x => x.CharacterId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Cast.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.BookCasts).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
