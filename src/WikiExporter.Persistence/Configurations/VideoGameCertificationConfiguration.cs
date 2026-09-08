using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_Certification</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameCertificationConfiguration : IEntityTypeConfiguration<VideoGameCertification>
{
    public void Configure(EntityTypeBuilder<VideoGameCertification> builder)
    {
        builder.ToTable("VideoGame_Certification");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.CertificationId).HasColumnName("CertificationID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_Certification.CertificationID -> Certification.ID
        builder.HasOne(x => x.Certification).WithMany(x => x.VideoGameCertifications).HasForeignKey(x => x.CertificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Certification.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGameCertifications).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_Certification.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.VideoGameCertifications).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
