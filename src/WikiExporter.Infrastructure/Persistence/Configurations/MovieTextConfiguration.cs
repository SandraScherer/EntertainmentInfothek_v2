using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WikiExporter.Infrastructure.Persistence.Entities;

namespace WikiExporter.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapping für Movie_Text.
/// </summary>
public sealed class MovieTextConfiguration
    : IEntityTypeConfiguration<MovieTextEntity>
{
    public void Configure(
        EntityTypeBuilder<MovieTextEntity> builder)
    {
        builder.ToTable("Movie_Text");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.MovieId)
            .HasColumnName("MovieID");

        builder.Property(x => x.TextId)
            .HasColumnName("TextID");

        builder.Property(x => x.TypeId)
            .HasColumnName("TypeID");
     
        builder.HasOne(x => x.Movie)
            .WithMany(x => x.Texts)
            .HasForeignKey(x => x.MovieId);
     
        builder.HasOne(x => x.Text)
            .WithMany()
            .HasForeignKey(x => x.TextId);

        builder.HasOne(x => x.TextType)
            .WithMany()
            .HasForeignKey(x => x.TypeId);
    }
}
