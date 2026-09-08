using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Book</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Book");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalTitle).HasColumnName("OriginalTitle");
        builder.Property(x => x.EnglishTitle).HasColumnName("EnglishTitle");
        builder.Property(x => x.GermanTitle).HasColumnName("GermanTitle");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
        builder.Property(x => x.CastStatusId).HasColumnName("CastStatusID");
        builder.Property(x => x.CrewStatusId).HasColumnName("CrewStatusID");
        builder.Property(x => x.ConnectionId).HasColumnName("ConnectionID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Book.CastStatusID -> Status.ID
        builder.HasOne(x => x.CastStatus).WithMany(x => x.BookCastStatuss).HasForeignKey(x => x.CastStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book.CrewStatusID -> Status.ID
        builder.HasOne(x => x.CrewStatus).WithMany(x => x.BookCrewStatuss).HasForeignKey(x => x.CrewStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book.ConnectionID -> Connection.ID
        builder.HasOne(x => x.Connection).WithMany(x => x.Books).HasForeignKey(x => x.ConnectionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.BookStatuss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Book.TypeID -> Type.ID
        builder.HasOne(x => x.Type).WithMany(x => x.Books).HasForeignKey(x => x.TypeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
