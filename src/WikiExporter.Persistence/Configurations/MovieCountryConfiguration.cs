using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_Country</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieCountryConfiguration : IEntityTypeConfiguration<MovieCountry>
{
    public void Configure(EntityTypeBuilder<MovieCountry> builder)
    {
        builder.ToTable("Movie_Country");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.CountryId).HasColumnName("CountryID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Country.CountryID -> Country.ID
        builder.HasOne(x => x.Country).WithMany(x => x.MovieCountrys).HasForeignKey(x => x.CountryId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Country.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieCountrys).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Country.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieCountrys).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
