using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_ProductionDate</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieProductionDateConfiguration : IEntityTypeConfiguration<MovieProductionDate>
{
    public void Configure(EntityTypeBuilder<MovieProductionDate> builder)
    {
        builder.ToTable("Movie_ProductionDate");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.StartDate).HasColumnName("StartDate");
        builder.Property(x => x.EndDate).HasColumnName("EndDate");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_ProductionDate.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieProductionDates).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_ProductionDate.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieProductionDates).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
