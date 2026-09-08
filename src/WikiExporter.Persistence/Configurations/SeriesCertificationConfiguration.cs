using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Certification</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesCertificationConfiguration : IEntityTypeConfiguration<SeriesCertification>
{
    public void Configure(EntityTypeBuilder<SeriesCertification> builder)
    {
        builder.ToTable("Series_Certification");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.CertificationId).HasColumnName("CertificationID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Certification.CertificationID -> Certification.ID
        builder.HasOne(x => x.Certification).WithMany(x => x.SeriesCertifications).HasForeignKey(x => x.CertificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Certification.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesCertifications).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Certification.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesCertifications).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
