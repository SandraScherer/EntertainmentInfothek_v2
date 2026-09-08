using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_Language</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieLanguageConfiguration : IEntityTypeConfiguration<MovieLanguage>
{
    public void Configure(EntityTypeBuilder<MovieLanguage> builder)
    {
        builder.ToTable("Movie_Language");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.LanguageId).HasColumnName("LanguageID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Language.LanguageID -> Language.ID
        builder.HasOne(x => x.Language).WithMany(x => x.MovieLanguages).HasForeignKey(x => x.LanguageId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Language.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieLanguages).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Language.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieLanguages).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
