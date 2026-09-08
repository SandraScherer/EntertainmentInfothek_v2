using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_Cast</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieCastConfiguration : IEntityTypeConfiguration<MovieCast>
{
    public void Configure(EntityTypeBuilder<MovieCast> builder)
    {
        builder.ToTable("Movie_Cast");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.ActorId).HasColumnName("ActorID");
        builder.Property(x => x.EnglishDubberId).HasColumnName("EnglishDubberID");
        builder.Property(x => x.GermanDubberId).HasColumnName("GermanDubberID");
        builder.Property(x => x.CharacterId).HasColumnName("CharacterID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Cast.ActorID -> Person.ID
        builder.HasOne(x => x.Actor).WithMany(x => x.MovieCastActors).HasForeignKey(x => x.ActorId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Cast.CharacterID -> Person.ID
        builder.HasOne(x => x.Character).WithMany(x => x.MovieCastCharacters).HasForeignKey(x => x.CharacterId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Cast.EnglishDubberID -> Person.ID
        builder.HasOne(x => x.EnglishDubber).WithMany(x => x.MovieCastEnglishDubbers).HasForeignKey(x => x.EnglishDubberId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Cast.GermanDubberID -> Person.ID
        builder.HasOne(x => x.GermanDubber).WithMany(x => x.MovieCastGermanDubbers).HasForeignKey(x => x.GermanDubberId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Cast.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieCasts).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Cast.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieCasts).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
