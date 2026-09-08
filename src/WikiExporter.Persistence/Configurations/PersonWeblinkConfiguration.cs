using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Person_Weblink</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PersonWeblinkConfiguration : IEntityTypeConfiguration<PersonWeblink>
{
    public void Configure(EntityTypeBuilder<PersonWeblink> builder)
    {
        builder.ToTable("Person_Weblink");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.WeblinkId).HasColumnName("WeblinkID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Person_Weblink.PersonID -> Person.ID
        builder.HasOne(x => x.Person).WithMany(x => x.PersonWeblinks).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Weblink.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.PersonWeblinks).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Person_Weblink.WeblinkID -> Weblink.ID
        builder.HasOne(x => x.Weblink).WithMany(x => x.PersonWeblinks).HasForeignKey(x => x.WeblinkId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
