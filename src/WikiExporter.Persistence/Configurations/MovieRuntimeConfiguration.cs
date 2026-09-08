using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_Runtime</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieRuntimeConfiguration : IEntityTypeConfiguration<MovieRuntime>
{
    public void Configure(EntityTypeBuilder<MovieRuntime> builder)
    {
        builder.ToTable("Movie_Runtime");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.Runtime).HasColumnName("Runtime");
        builder.Property(x => x.EditionId).HasColumnName("EditionID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Runtime.EditionID -> Edition.ID
        builder.HasOne(x => x.Edition).WithMany(x => x.MovieRuntimes).HasForeignKey(x => x.EditionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Runtime.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieRuntimes).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Runtime.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieRuntimes).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
