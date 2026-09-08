using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Book_Crew</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class BookCrewConfiguration : IEntityTypeConfiguration<BookCrew>
{
    public void Configure(EntityTypeBuilder<BookCrew> builder)
    {
        builder.ToTable("Book_Crew");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.BookId).HasColumnName("BookID");
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.DepartmentId).HasColumnName("DepartmentID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book_Crew.BookID -> Book.ID
        builder.HasOne(x => x.Book).WithMany(x => x.BookCrews).HasForeignKey(x => x.BookId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Crew.DepartmentID -> Department.ID
        builder.HasOne(x => x.Department).WithMany(x => x.BookCrews).HasForeignKey(x => x.DepartmentId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Crew.PersonID -> Person.ID
        builder.HasOne(x => x.Person).WithMany(x => x.BookCrews).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book_Crew.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.BookCrews).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
