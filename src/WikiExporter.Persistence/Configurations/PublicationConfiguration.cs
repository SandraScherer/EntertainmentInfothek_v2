using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Publication</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PublicationConfiguration : IEntityTypeConfiguration<Publication>
{
    public void Configure(EntityTypeBuilder<Publication> builder)
    {
        builder.ToTable("Publication");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EnglishTitle).HasColumnName("EnglishTitle");
        builder.Property(x => x.GermanTitle).HasColumnName("GermanTitle");
        builder.Property(x => x.ISBN13).HasColumnName("ISBN13");
        builder.Property(x => x.ISBN10).HasColumnName("ISBN10");
        builder.Property(x => x.BookId).HasColumnName("BookID");
        builder.Property(x => x.EditionId).HasColumnName("EditionID");
        builder.Property(x => x.Format).HasColumnName("Format");
        builder.Property(x => x.NoOfPages).HasColumnName("NoOfPages");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Publication.BookID -> Book.ID
        builder.HasOne(x => x.Book).WithMany(x => x.Publications).HasForeignKey(x => x.BookId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication.EditionID -> Edition.ID
        builder.HasOne(x => x.Edition).WithMany(x => x.Publications).HasForeignKey(x => x.EditionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.Publications).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
