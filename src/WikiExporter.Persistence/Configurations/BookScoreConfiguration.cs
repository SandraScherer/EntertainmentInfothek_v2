using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Book_Score</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class BookScoreConfiguration : IEntityTypeConfiguration<BookScore>
{
    public void Configure(EntityTypeBuilder<BookScore> builder)
    {
        builder.ToTable("Book_Score");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookId).HasColumnName("BookID");
        builder.Property(x => x.Score).HasColumnName("Score");
        builder.Property(x => x.Date).HasColumnName("Date");
        builder.Property(x => x.CompanyId).HasColumnName("CompanyID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_Score.BookID -> Book.ID
        builder.HasOne(x => x.Book).WithMany(x => x.BookScores).HasForeignKey(x => x.BookId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Score.CompanyID -> Company.ID
        builder.HasOne(x => x.Company).WithMany(x => x.BookScores).HasForeignKey(x => x.CompanyId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Score.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.BookScores).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
