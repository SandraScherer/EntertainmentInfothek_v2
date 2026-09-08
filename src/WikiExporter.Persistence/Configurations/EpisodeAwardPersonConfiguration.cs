using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Episode_Award_Person</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class EpisodeAwardPersonConfiguration : IEntityTypeConfiguration<EpisodeAwardPerson>
{
    public void Configure(EntityTypeBuilder<EpisodeAwardPerson> builder)
    {
        builder.ToTable("Episode_Award_Person");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.Episode_AwardId).HasColumnName("Episode_AwardID");
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_Award_Person.Episode_AwardID -> Episode_Award.ID
        builder.HasOne(x => x.Episode_Award).WithMany(x => x.EpisodeAwardPersons).HasForeignKey(x => x.Episode_AwardId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Award_Person.PersonID -> Person.ID
        builder.HasOne(x => x.Person).WithMany(x => x.EpisodeAwardPersons).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Award_Person.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.EpisodeAwardPersons).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
