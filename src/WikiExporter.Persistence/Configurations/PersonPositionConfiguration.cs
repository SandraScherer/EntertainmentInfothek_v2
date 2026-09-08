using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Person_Position</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PersonPositionConfiguration : IEntityTypeConfiguration<PersonPosition>
{
    public void Configure(EntityTypeBuilder<PersonPosition> builder)
    {
        builder.ToTable("Person_Position");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.PositionId).HasColumnName("PositionID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Person_Position.PersonID -> Person.ID
        builder.HasOne(x => x.Person).WithMany(x => x.PersonPositions).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Position.PositionID -> Position.ID
        builder.HasOne(x => x.Position).WithMany(x => x.PersonPositions).HasForeignKey(x => x.PositionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Position.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.PersonPositions).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
