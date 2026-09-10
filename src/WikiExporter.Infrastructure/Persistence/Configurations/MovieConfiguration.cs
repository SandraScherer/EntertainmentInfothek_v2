using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Tabelle Movie.
/// </summary>
public sealed class MovieConfiguration
    : IEntityTypeConfiguration<MovieEntity>
{
    public void Configure(
        EntityTypeBuilder<MovieEntity> builder)
    {
        builder.ToTable("Movie");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.StatusId)
            .HasColumnName("StatusID");

        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusId);

        builder.HasMany(x => x.Genres)
            .WithOne(x => x.Movie)
            .HasForeignKey(x => x.MovieId);

        builder.HasMany(x => x.Cast)
            .WithOne(x => x.Movie)
            .HasForeignKey(x => x.MovieId);

        builder.HasMany(x => x.Crew)
            .WithOne(x => x.Movie)
            .HasForeignKey(x => x.MovieId);

        builder.HasMany(x => x.Texts)
            .WithOne(x => x.Movie)
            .HasForeignKey(x => x.MovieId);

        builder.HasMany(x => x.Images)
            .WithOne(x => x.Movie)
            .HasForeignKey(x => x.MovieId);

        builder.HasMany(x => x.Weblinks)
            .WithOne(x => x.Movie)
            .HasForeignKey(x => x.MovieId);
    }
}
