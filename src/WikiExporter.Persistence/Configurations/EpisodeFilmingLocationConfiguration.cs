using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Episode_FilmingLocation</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class EpisodeFilmingLocationConfiguration : IEntityTypeConfiguration<EpisodeFilmingLocation>
{
    public void Configure(EntityTypeBuilder<EpisodeFilmingLocation> builder)
    {
        builder.ToTable("Episode_FilmingLocation");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EpisodeId).HasColumnName("EpisodeID");
        builder.Property(x => x.LocationId).HasColumnName("LocationID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_FilmingLocation.EpisodeID -> Episode.ID
        builder.HasOne(x => x.Episode).WithMany(x => x.EpisodeFilmingLocations).HasForeignKey(x => x.EpisodeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_FilmingLocation.LocationID -> Location.ID
        builder.HasOne(x => x.Location).WithMany(x => x.EpisodeFilmingLocations).HasForeignKey(x => x.LocationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_FilmingLocation.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.EpisodeFilmingLocations).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
