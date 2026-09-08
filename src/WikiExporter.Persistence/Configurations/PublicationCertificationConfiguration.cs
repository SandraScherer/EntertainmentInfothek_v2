using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Publication_Certification</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PublicationCertificationConfiguration : IEntityTypeConfiguration<PublicationCertification>
{
    public void Configure(EntityTypeBuilder<PublicationCertification> builder)
    {
        builder.ToTable("Publication_Certification");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PublicationId).HasColumnName("PublicationID");
        builder.Property(x => x.CertificationId).HasColumnName("CertificationID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Publication_Certification.CertificationID -> Certification.ID
        builder.HasOne(x => x.Certification).WithMany(x => x.PublicationCertifications).HasForeignKey(x => x.CertificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Certification.PublicationID -> Publication.ID
        builder.HasOne(x => x.Publication).WithMany(x => x.PublicationCertifications).HasForeignKey(x => x.PublicationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Certification.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.PublicationCertifications).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
