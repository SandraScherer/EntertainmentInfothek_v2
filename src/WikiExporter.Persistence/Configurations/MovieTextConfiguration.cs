using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_Text</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieTextConfiguration : IEntityTypeConfiguration<MovieText>
{
    public void Configure(EntityTypeBuilder<MovieText> builder)
    {
        builder.ToTable("Movie_Text");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.TextId).HasColumnName("TextID");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Text.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieTexts).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Text.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieTexts).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Text.TextID -> Text.ID
        builder.HasOne(x => x.Text).WithMany(x => x.MovieTexts).HasForeignKey(x => x.TextId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Text.TypeID -> TextType.ID
        builder.HasOne(x => x.Type).WithMany(x => x.MovieTexts).HasForeignKey(x => x.TypeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
