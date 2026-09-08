using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_ReleaseDateFirstEpisode</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesReleaseDateFirstEpisodeConfiguration : IEntityTypeConfiguration<SeriesReleaseDateFirstEpisode>
{
    public void Configure(EntityTypeBuilder<SeriesReleaseDateFirstEpisode> builder)
    {
        builder.ToTable("Series_ReleaseDateFirstEpisode");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
        builder.Property(x => x.EnglishDescription).HasColumnName("EnglishDescription");
        builder.Property(x => x.GermanDescription).HasColumnName("GermanDescription");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_ReleaseDateFirstEpisode.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesReleaseDateFirstEpisodes).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_ReleaseDateFirstEpisode.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesReleaseDateFirstEpisodes).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
