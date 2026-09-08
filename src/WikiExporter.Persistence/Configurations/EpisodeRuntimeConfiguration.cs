using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Episode_Runtime</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class EpisodeRuntimeConfiguration : IEntityTypeConfiguration<EpisodeRuntime>
{
    public void Configure(EntityTypeBuilder<EpisodeRuntime> builder)
    {
        builder.ToTable("Episode_Runtime");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EpisodeId).HasColumnName("EpisodeID");
        builder.Property(x => x.Runtime).HasColumnName("Runtime");
        builder.Property(x => x.EditionId).HasColumnName("EditionID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_Runtime.EditionID -> Edition.ID
        builder.HasOne(x => x.Edition).WithMany(x => x.EpisodeRuntimes).HasForeignKey(x => x.EditionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Runtime.EpisodeID -> Episode.ID
        builder.HasOne(x => x.Episode).WithMany(x => x.EpisodeRuntimes).HasForeignKey(x => x.EpisodeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Runtime.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.EpisodeRuntimes).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
