using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_Camera</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieCameraConfiguration : IEntityTypeConfiguration<MovieCamera>
{
    public void Configure(EntityTypeBuilder<MovieCamera> builder)
    {
        builder.ToTable("Movie_Camera");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.CameraId).HasColumnName("CameraID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Camera.CameraID -> Camera.ID
        builder.HasOne(x => x.Camera).WithMany(x => x.MovieCameras).HasForeignKey(x => x.CameraId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Camera.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieCameras).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Camera.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieCameras).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
