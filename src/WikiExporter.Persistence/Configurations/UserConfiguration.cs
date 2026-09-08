using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>User</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalName).HasColumnName("OriginalName");
        builder.Property(x => x.EMail).HasColumnName("EMail");
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: User.PersonID -> Person.ID
        builder.HasOne(x => x.Person).WithMany(x => x.Users).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: User.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.Users).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
