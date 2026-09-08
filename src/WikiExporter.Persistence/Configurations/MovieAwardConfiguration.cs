using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_Award</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieAwardConfiguration : IEntityTypeConfiguration<MovieAward>
{
    public void Configure(EntityTypeBuilder<MovieAward> builder)
    {
        builder.ToTable("Movie_Award");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.AwardId).HasColumnName("AwardID");
        builder.Property(x => x.Category).HasColumnName("Category");
        builder.Property(x => x.Date).HasColumnName("Date");
        builder.Property(x => x.Winner).HasColumnName("Winner");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Award.AwardID -> Award.ID
        builder.HasOne(x => x.Award).WithMany(x => x.MovieAwards).HasForeignKey(x => x.AwardId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Award.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieAwards).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Award.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieAwards).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
