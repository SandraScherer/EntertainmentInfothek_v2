using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Movie_Cast.
/// </summary>
public sealed class MovieCastConfiguration
    : IEntityTypeConfiguration<MovieCastEntity>
{
    public void Configure(
        EntityTypeBuilder<MovieCastEntity> builder)
    {
        builder.ToTable("Movie_Cast");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.MovieId)
            .HasColumnName("MovieID");

        builder.Property(x => x.ActorId)
            .HasColumnName("ActorID");

        builder.Property(x => x.EnglishRole)
            .HasColumnName("EnglishRole");

        builder.Property(x => x.GermanRole)
            .HasColumnName("GermanRole");

        builder.Property(x => x.Order)
            .HasColumnName("Order");

        builder.HasOne(x => x.Movie)
            .WithMany(x => x.Cast)
            .HasForeignKey(x => x.MovieId);

        builder.HasOne(x => x.Actor)
            .WithMany()
            .HasForeignKey(x => x.ActorId);
    }
}
