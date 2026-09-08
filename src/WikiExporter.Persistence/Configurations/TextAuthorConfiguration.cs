using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Text_Author</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TextAuthorConfiguration : IEntityTypeConfiguration<TextAuthor>
{
    public void Configure(EntityTypeBuilder<TextAuthor> builder)
    {
        builder.ToTable("Text_Author");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TextId).HasColumnName("TextID");
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Text_Author.PersonID -> Person.ID
        builder.HasOne(x => x.Person).WithMany(x => x.TextAuthors).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Text_Author.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TextAuthors).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Text_Author.TextID -> Text.ID
        builder.HasOne(x => x.Text).WithMany(x => x.TextAuthors).HasForeignKey(x => x.TextId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
