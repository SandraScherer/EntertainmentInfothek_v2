using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Person_Profession</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PersonProfessionConfiguration : IEntityTypeConfiguration<PersonProfession>
{
    public void Configure(EntityTypeBuilder<PersonProfession> builder)
    {
        builder.ToTable("Person_Profession");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.ProfessionId).HasColumnName("ProfessionID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Person_Profession.PersonID -> Person.ID
        builder.HasOne(x => x.Person).WithMany(x => x.PersonProfessions).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Profession.ProfessionID -> Profession.ID
        builder.HasOne(x => x.Profession).WithMany(x => x.PersonProfessions).HasForeignKey(x => x.ProfessionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Profession.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.PersonProfessions).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
