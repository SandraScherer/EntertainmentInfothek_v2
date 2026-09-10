using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Movie_Image.
/// </summary>
public sealed class MovieImageConfiguration
    : IEntityTypeConfiguration<MovieImageEntity>
{
    public void Configure(
        EntityTypeBuilder<MovieImageEntity> builder)
    {
        builder.ToTable("Movie_Image");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.MovieId)
            .HasColumnName("MovieID");

        builder.Property(x => x.ImageId)
            .HasColumnName("ImageID");

        builder.HasOne(x => x.Movie)
            .WithMany(x => x.Images)
            .HasForeignKey(x => x.MovieId);

        builder.HasOne(x => x.Image)
            .WithMany()
            .HasForeignKey(x => x.ImageId);
    }
}
