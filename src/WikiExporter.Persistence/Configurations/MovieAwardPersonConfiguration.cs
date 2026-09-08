using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_Award_Person</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieAwardPersonConfiguration : IEntityTypeConfiguration<MovieAwardPerson>
{
    public void Configure(EntityTypeBuilder<MovieAwardPerson> builder)
    {
        builder.ToTable("Movie_Award_Person");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.Movie_AwardId).HasColumnName("Movie_AwardID");
        builder.Property(x => x.PersonId).HasColumnName("PersonID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Award_Person.Movie_AwardID -> Movie_Award.ID
        builder.HasOne(x => x.Movie_Award).WithMany(x => x.MovieAwardPersons).HasForeignKey(x => x.Movie_AwardId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Award_Person.PersonID -> Person.ID
        builder.HasOne(x => x.Person).WithMany(x => x.MovieAwardPersons).HasForeignKey(x => x.PersonId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Award_Person.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieAwardPersons).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
