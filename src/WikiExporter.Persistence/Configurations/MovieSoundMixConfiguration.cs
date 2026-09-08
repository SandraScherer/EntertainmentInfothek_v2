using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_SoundMix</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieSoundMixConfiguration : IEntityTypeConfiguration<MovieSoundMix>
{
    public void Configure(EntityTypeBuilder<MovieSoundMix> builder)
    {
        builder.ToTable("Movie_SoundMix");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.SoundMixId).HasColumnName("SoundMixID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_SoundMix.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieSoundMixs).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_SoundMix.SoundMixID -> SoundMix.ID
        builder.HasOne(x => x.SoundMix).WithMany(x => x.MovieSoundMixs).HasForeignKey(x => x.SoundMixId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_SoundMix.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieSoundMixs).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
