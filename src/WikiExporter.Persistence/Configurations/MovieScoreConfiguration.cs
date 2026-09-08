using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_Score</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieScoreConfiguration : IEntityTypeConfiguration<MovieScore>
{
    public void Configure(EntityTypeBuilder<MovieScore> builder)
    {
        builder.ToTable("Movie_Score");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.Score).HasColumnName("Score");
        builder.Property(x => x.Date).HasColumnName("Date");
        builder.Property(x => x.CompanyId).HasColumnName("CompanyID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Score.CompanyID -> Company.ID
        builder.HasOne(x => x.Company).WithMany(x => x.MovieScores).HasForeignKey(x => x.CompanyId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Score.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieScores).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Score.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieScores).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
