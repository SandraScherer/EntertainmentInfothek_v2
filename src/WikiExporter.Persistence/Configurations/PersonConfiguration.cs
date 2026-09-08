using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Person</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Person");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.FirstName).HasColumnName("FirstName");
        builder.Property(x => x.LastName).HasColumnName("LastName");
        builder.Property(x => x.NameAddOn).HasColumnName("NameAddOn");
        builder.Property(x => x.BirthName).HasColumnName("BirthName");
        builder.Property(x => x.DateOfBirth).HasColumnName("DateOfBirth");
        builder.Property(x => x.LocationOfBirthId).HasColumnName("LocationOfBirthID");
        builder.Property(x => x.DateOfDeath).HasColumnName("DateOfDeath");
        builder.Property(x => x.LocationOfDeathId).HasColumnName("LocationOfDeathID");
        builder.Property(x => x.EnglishCauseOfDeath).HasColumnName("EnglishCauseOfDeath");
        builder.Property(x => x.GermanCauseOfDeath).HasColumnName("GermanCauseOfDeath");
        builder.Property(x => x.GenderId).HasColumnName("GenderID");
        builder.Property(x => x.Height).HasColumnName("Height");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Person.GenderID -> Gender.ID
        builder.HasOne(x => x.Gender).WithMany(x => x.Persons).HasForeignKey(x => x.GenderId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person.LocationOfBirthID -> Location.ID
        builder.HasOne(x => x.LocationOfBirth).WithMany(x => x.PersonLocationOfBirths).HasForeignKey(x => x.LocationOfBirthId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person.LocationOfDeathID -> Location.ID
        builder.HasOne(x => x.LocationOfDeath).WithMany(x => x.PersonLocationOfDeaths).HasForeignKey(x => x.LocationOfDeathId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.Persons).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person.TypeID -> Type.ID
        builder.HasOne(x => x.Type).WithMany(x => x.Persons).HasForeignKey(x => x.TypeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
