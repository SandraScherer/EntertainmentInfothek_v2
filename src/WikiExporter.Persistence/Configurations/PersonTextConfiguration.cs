using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Person_Text</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PersonTextConfiguration : IEntityTypeConfiguration<PersonText>
{
    public void Configure(EntityTypeBuilder<PersonText> builder)
    {
        builder.ToTable("Person_Text");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.TextId).HasColumnName("TextID");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Person_Text.PersonID -> Person.ID
        builder.HasOne(x => x.Person).WithMany(x => x.PersonTexts).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Text.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.PersonTexts).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Text.TextID -> Text.ID
        builder.HasOne(x => x.Text).WithMany(x => x.PersonTexts).HasForeignKey(x => x.TextId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Text.TypeID -> TextType.ID
        builder.HasOne(x => x.Type).WithMany(x => x.PersonTexts).HasForeignKey(x => x.TypeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
