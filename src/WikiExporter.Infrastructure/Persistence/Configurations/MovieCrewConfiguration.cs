using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Movie_Crew.
/// </summary>
public sealed class MovieCrewConfiguration
    : IEntityTypeConfiguration<MovieCrewEntity>
{
    public void Configure(
        EntityTypeBuilder<MovieCrewEntity> builder)
    {
        builder.ToTable("Movie_Crew");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.MovieId)
            .HasColumnName("MovieID");

        builder.Property(x => x.PersonId)
            .HasColumnName("PersonID");

        builder.Property(x => x.DepartmentId)
            .HasColumnName("DepartmentID");

        builder.Property(x => x.EnglishRole)
            .HasColumnName("EnglishRole");

        builder.Property(x => x.GermanRole)
            .HasColumnName("GermanRole");

        builder.Property(x => x.Order)
            .HasColumnName("Order");

        builder.HasOne(x => x.Movie)
            .WithMany(x => x.Crew)
            .HasForeignKey(x => x.MovieId);

        builder.HasOne(x => x.Person)
            .WithMany()
            .HasForeignKey(x => x.PersonId);

        builder.HasOne(x => x.Department)
            .WithMany()
            .HasForeignKey(x => x.DepartmentId);
    }
}
