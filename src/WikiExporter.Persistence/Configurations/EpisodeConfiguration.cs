using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Episode</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder)
    {
        builder.ToTable("Episode");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalTitle).HasColumnName("OriginalTitle");
        builder.Property(x => x.EnglishTitle).HasColumnName("EnglishTitle");
        builder.Property(x => x.GermanTitle).HasColumnName("GermanTitle");
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.SeasonNo).HasColumnName("SeasonNo");
        builder.Property(x => x.EpisodeNo).HasColumnName("EpisodeNo");
        builder.Property(x => x.CastStatusId).HasColumnName("CastStatusID");
        builder.Property(x => x.CrewStatusId).HasColumnName("CrewStatusID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode.CastStatusID -> Status.ID
        builder.HasOne(x => x.CastStatus).WithMany(x => x.EpisodeCastStatuss).HasForeignKey(x => x.CastStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode.CrewStatusID -> Status.ID
        builder.HasOne(x => x.CrewStatus).WithMany(x => x.EpisodeCrewStatuss).HasForeignKey(x => x.CrewStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.Episodes).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.EpisodeStatuss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
