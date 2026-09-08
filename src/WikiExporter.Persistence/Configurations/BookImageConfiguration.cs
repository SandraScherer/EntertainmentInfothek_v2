using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Book_Image</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class BookImageConfiguration : IEntityTypeConfiguration<BookImage>
{
    public void Configure(EntityTypeBuilder<BookImage> builder)
    {
        builder.ToTable("Book_Image");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookId).HasColumnName("BookID");
        builder.Property(x => x.ImageId).HasColumnName("ImageID");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_Image.BookID -> Book.ID
        builder.HasOne(x => x.Book).WithMany(x => x.BookImages).HasForeignKey(x => x.BookId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Image.ImageID -> Image.ID
        builder.HasOne(x => x.Image).WithMany(x => x.BookImages).HasForeignKey(x => x.ImageId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Image.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.BookImages).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
