using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_ReleaseDateLastEpisode</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesReleaseDateLastEpisodeConfiguration : IEntityTypeConfiguration<SeriesReleaseDateLastEpisode>
{
    public void Configure(EntityTypeBuilder<SeriesReleaseDateLastEpisode> builder)
    {
        builder.ToTable("Series_ReleaseDateLastEpisode");
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

        // FK: Series_ReleaseDateLastEpisode.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesReleaseDateLastEpisodes).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_ReleaseDateLastEpisode.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesReleaseDateLastEpisodes).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
