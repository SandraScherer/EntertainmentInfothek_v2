using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Episode_Certification</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class EpisodeCertificationConfiguration : IEntityTypeConfiguration<EpisodeCertification>
{
    public void Configure(EntityTypeBuilder<EpisodeCertification> builder)
    {
        builder.ToTable("Episode_Certification");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EpisodeId).HasColumnName("EpisodeID");
        builder.Property(x => x.CertificationId).HasColumnName("CertificationID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_Certification.CertificationID -> Certification.ID
        builder.HasOne(x => x.Certification).WithMany(x => x.EpisodeCertifications).HasForeignKey(x => x.CertificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Certification.EpisodeID -> Episode.ID
        builder.HasOne(x => x.Episode).WithMany(x => x.EpisodeCertifications).HasForeignKey(x => x.EpisodeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_Certification.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.EpisodeCertifications).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
