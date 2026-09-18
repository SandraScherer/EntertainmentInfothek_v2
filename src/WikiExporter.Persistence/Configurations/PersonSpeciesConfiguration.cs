using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Person_Species</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PersonSpeciesConfiguration : IEntityTypeConfiguration<PersonSpeciesEntity>
{
    public void Configure(EntityTypeBuilder<PersonSpeciesEntity> builder)
    {
        builder.ToTable("Person_Species");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.SpeciesId).HasColumnName("SpeciesID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Person_Species.PersonID -> Person.ID
        builder.HasOne(x => x.PersonEntity).WithMany().HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Species.SpeciesID -> Species.ID
        builder.HasOne(x => x.SpeciesEntity).WithMany().HasForeignKey(x => x.SpeciesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Species.StatusID -> Status.ID
        builder.HasOne(x => x.StatusEntity).WithMany().HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
