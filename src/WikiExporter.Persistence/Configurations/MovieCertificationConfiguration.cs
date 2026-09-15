using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_Certification</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieCertificationConfiguration : IEntityTypeConfiguration<MovieCertificationEntity>
{
    public void Configure(EntityTypeBuilder<MovieCertificationEntity> builder)
    {
        builder.ToTable("Movie_Certification");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.CertificationId).HasColumnName("CertificationID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Certification.CertificationID -> Certification.ID
        builder.HasOne(x => x.CertificationEntity).WithMany(x => x.MovieCertifications).HasForeignKey(x => x.CertificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Certification.MovieID -> Movie.ID
        builder.HasOne(x => x.MovieEntity).WithMany(x => x.MovieCertifications).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Certification.StatusID -> Status.ID
        builder.HasOne(x => x.StatusEntity).WithMany(x => x.MovieCertifications).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
