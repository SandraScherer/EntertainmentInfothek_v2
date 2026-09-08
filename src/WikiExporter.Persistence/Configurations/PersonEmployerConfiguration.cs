using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Person_Employer</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PersonEmployerConfiguration : IEntityTypeConfiguration<PersonEmployer>
{
    public void Configure(EntityTypeBuilder<PersonEmployer> builder)
    {
        builder.ToTable("Person_Employer");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.EmployerId).HasColumnName("EmployerID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Person_Employer.EmployerID -> Employer.ID
        builder.HasOne(x => x.Employer).WithMany(x => x.PersonEmployers).HasForeignKey(x => x.EmployerId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Employer.PersonID -> Person.ID
        builder.HasOne(x => x.Person).WithMany(x => x.PersonEmployers).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Employer.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.PersonEmployers).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
