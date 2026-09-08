using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Person_Family</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PersonFamilyConfiguration : IEntityTypeConfiguration<PersonFamily>
{
    public void Configure(EntityTypeBuilder<PersonFamily> builder)
    {
        builder.ToTable("Person_Family");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.FamilyId).HasColumnName("FamilyID");
        builder.Property(x => x.OriginalName).HasColumnName("OriginalName");
        builder.Property(x => x.RelationshipId).HasColumnName("RelationshipID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Person_Family.FamilyID -> Person.ID
        builder.HasOne(x => x.Family).WithMany(x => x.PersonFamilyFamilys).HasForeignKey(x => x.FamilyId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Family.PersonID -> Person.ID
        builder.HasOne(x => x.Person).WithMany(x => x.PersonFamilyPersons).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Family.RelationshipID -> Relationship.ID
        builder.HasOne(x => x.Relationship).WithMany(x => x.PersonFamilys).HasForeignKey(x => x.RelationshipId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Family.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.PersonFamilys).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
