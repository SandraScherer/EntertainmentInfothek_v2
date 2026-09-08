using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Episode_ReleaseDate</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class EpisodeReleaseDateConfiguration : IEntityTypeConfiguration<EpisodeReleaseDate>
{
    public void Configure(EntityTypeBuilder<EpisodeReleaseDate> builder)
    {
        builder.ToTable("Episode_ReleaseDate");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EpisodeId).HasColumnName("EpisodeID");
        builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
        builder.Property(x => x.EnglishDescription).HasColumnName("EnglishDescription");
        builder.Property(x => x.GermanDescription).HasColumnName("GermanDescription");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_ReleaseDate.EpisodeID -> Episode.ID
        builder.HasOne(x => x.Episode).WithMany(x => x.EpisodeReleaseDates).HasForeignKey(x => x.EpisodeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_ReleaseDate.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.EpisodeReleaseDates).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
