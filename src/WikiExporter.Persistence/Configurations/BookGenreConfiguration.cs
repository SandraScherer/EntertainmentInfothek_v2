using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Book_Genre</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
{
    public void Configure(EntityTypeBuilder<BookGenre> builder)
    {
        builder.ToTable("Book_Genre");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookId).HasColumnName("BookID");
        builder.Property(x => x.GenreId).HasColumnName("GenreID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_Genre.BookID -> Book.ID
        builder.HasOne(x => x.Book).WithMany(x => x.BookGenres).HasForeignKey(x => x.BookId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Genre.GenreID -> Genre.ID
        builder.HasOne(x => x.Genre).WithMany(x => x.BookGenres).HasForeignKey(x => x.GenreId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Genre.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.BookGenres).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
