using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Episode_FilmingDate</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class EpisodeFilmingDateConfiguration : IEntityTypeConfiguration<EpisodeFilmingDate>
{
    public void Configure(EntityTypeBuilder<EpisodeFilmingDate> builder)
    {
        builder.ToTable("Episode_FilmingDate");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EpisodeId).HasColumnName("EpisodeID");
        builder.Property(x => x.StartDate).HasColumnName("StartDate");
        builder.Property(x => x.EndDate).HasColumnName("EndDate");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_FilmingDate.EpisodeID -> Episode.ID
        builder.HasOne(x => x.Episode).WithMany(x => x.EpisodeFilmingDates).HasForeignKey(x => x.EpisodeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_FilmingDate.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.EpisodeFilmingDates).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
