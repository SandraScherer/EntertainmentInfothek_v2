using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Movie_Weblink.
/// </summary>
public sealed class MovieWeblinkConfiguration
    : IEntityTypeConfiguration<MovieWeblinkEntity>
{
    public void Configure(
        EntityTypeBuilder<MovieWeblinkEntity> builder)
    {
        builder.ToTable("Movie_Weblink");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.MovieId)
            .HasColumnName("MovieID");

        builder.Property(x => x.WeblinkId)
            .HasColumnName("WeblinkID");

        builder.HasOne(x => x.Movie)
            .WithMany(x => x.Weblinks)
            .HasForeignKey(x => x.MovieId);

        builder.HasOne(x => x.Weblink)
            .WithMany()
            .HasForeignKey(x => x.WeblinkId);
    }
}
