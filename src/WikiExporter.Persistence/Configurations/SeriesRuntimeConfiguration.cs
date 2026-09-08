using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Runtime</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesRuntimeConfiguration : IEntityTypeConfiguration<SeriesRuntime>
{
    public void Configure(EntityTypeBuilder<SeriesRuntime> builder)
    {
        builder.ToTable("Series_Runtime");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.Runtime).HasColumnName("Runtime");
        builder.Property(x => x.EditionId).HasColumnName("EditionID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Runtime.EditionID -> Edition.ID
        builder.HasOne(x => x.Edition).WithMany(x => x.SeriesRuntimes).HasForeignKey(x => x.EditionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Runtime.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesRuntimes).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Runtime.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesRuntimes).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
