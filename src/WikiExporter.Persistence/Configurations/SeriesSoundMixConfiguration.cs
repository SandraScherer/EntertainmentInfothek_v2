using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_SoundMix</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesSoundMixConfiguration : IEntityTypeConfiguration<SeriesSoundMix>
{
    public void Configure(EntityTypeBuilder<SeriesSoundMix> builder)
    {
        builder.ToTable("Series_SoundMix");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.SoundMixId).HasColumnName("SoundMixID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_SoundMix.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesSoundMixs).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_SoundMix.SoundMixID -> SoundMix.ID
        builder.HasOne(x => x.SoundMix).WithMany(x => x.SeriesSoundMixs).HasForeignKey(x => x.SoundMixId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_SoundMix.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesSoundMixs).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
