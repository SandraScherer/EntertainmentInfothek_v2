using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_CinematographicProcess</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesCinematographicProcessConfiguration : IEntityTypeConfiguration<SeriesCinematographicProcess>
{
    public void Configure(EntityTypeBuilder<SeriesCinematographicProcess> builder)
    {
        builder.ToTable("Series_CinematographicProcess");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.CinematographicProcessId).HasColumnName("CinematographicProcessID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_CinematographicProcess.CinematographicProcessID -> CinematographicProcess.ID
        builder.HasOne(x => x.CinematographicProcess).WithMany(x => x.SeriesCinematographicProcesss).HasForeignKey(x => x.CinematographicProcessId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_CinematographicProcess.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesCinematographicProcesss).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_CinematographicProcess.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesCinematographicProcesss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
