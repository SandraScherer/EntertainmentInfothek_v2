using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Laboratory</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class LaboratoryConfiguration : IEntityTypeConfiguration<Laboratory>
{
    public void Configure(EntityTypeBuilder<Laboratory> builder)
    {
        builder.ToTable("Laboratory");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalName).HasColumnName("OriginalName");
        builder.Property(x => x.LocationId).HasColumnName("LocationID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Laboratory.LocationID -> Location.ID
        builder.HasOne(x => x.Location).WithMany(x => x.Laboratorys).HasForeignKey(x => x.LocationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Laboratory.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.Laboratorys).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
