using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Award</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesAwardConfiguration : IEntityTypeConfiguration<SeriesAward>
{
    public void Configure(EntityTypeBuilder<SeriesAward> builder)
    {
        builder.ToTable("Series_Award");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.AwardId).HasColumnName("AwardID");
        builder.Property(x => x.Category).HasColumnName("Category");
        builder.Property(x => x.Date).HasColumnName("Date");
        builder.Property(x => x.Winner).HasColumnName("Winner");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Award.AwardID -> Award.ID
        builder.HasOne(x => x.Award).WithMany(x => x.SeriesAwards).HasForeignKey(x => x.AwardId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Award.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesAwards).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Award.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesAwards).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
