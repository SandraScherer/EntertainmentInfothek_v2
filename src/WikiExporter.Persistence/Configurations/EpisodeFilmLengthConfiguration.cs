using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Episode_FilmLength</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class EpisodeFilmLengthConfiguration : IEntityTypeConfiguration<EpisodeFilmLength>
{
    public void Configure(EntityTypeBuilder<EpisodeFilmLength> builder)
    {
        builder.ToTable("Episode_FilmLength");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EpisodeId).HasColumnName("EpisodeID");
        builder.Property(x => x.Length).HasColumnName("Length");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_FilmLength.EpisodeID -> Episode.ID
        builder.HasOne(x => x.Episode).WithMany(x => x.EpisodeFilmLengths).HasForeignKey(x => x.EpisodeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_FilmLength.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.EpisodeFilmLengths).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
