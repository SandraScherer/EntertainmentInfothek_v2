using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Laboratory</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesLaboratoryConfiguration : IEntityTypeConfiguration<SeriesLaboratory>
{
    public void Configure(EntityTypeBuilder<SeriesLaboratory> builder)
    {
        builder.ToTable("Series_Laboratory");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.LaboratoryId).HasColumnName("LaboratoryID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Laboratory.LaboratoryID -> Laboratory.ID
        builder.HasOne(x => x.Laboratory).WithMany(x => x.SeriesLaboratorys).HasForeignKey(x => x.LaboratoryId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Laboratory.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesLaboratorys).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Laboratory.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesLaboratorys).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
