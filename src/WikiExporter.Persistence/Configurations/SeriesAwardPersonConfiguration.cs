using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Award_Person</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesAwardPersonConfiguration : IEntityTypeConfiguration<SeriesAwardPerson>
{
    public void Configure(EntityTypeBuilder<SeriesAwardPerson> builder)
    {
        builder.ToTable("Series_Award_Person");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.Series_AwardId).HasColumnName("Series_AwardID");
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Award_Person.PersonID -> Person.ID
        builder.HasOne(x => x.Person).WithMany(x => x.SeriesAwardPersons).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Award_Person.Series_AwardID -> Series_Award.ID
        builder.HasOne(x => x.Series_Award).WithMany(x => x.SeriesAwardPersons).HasForeignKey(x => x.Series_AwardId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Award_Person.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesAwardPersons).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
