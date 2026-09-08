using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_Weblink</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieWeblinkConfiguration : IEntityTypeConfiguration<MovieWeblink>
{
    public void Configure(EntityTypeBuilder<MovieWeblink> builder)
    {
        builder.ToTable("Movie_Weblink");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.WeblinkId).HasColumnName("WeblinkID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Weblink.MovieID -> Movie.ID
        builder.HasOne(x => x.Movie).WithMany(x => x.MovieWeblinks).HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Weblink.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.MovieWeblinks).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Weblink.WeblinkID -> Weblink.ID
        builder.HasOne(x => x.Weblink).WithMany(x => x.MovieWeblinks).HasForeignKey(x => x.WeblinkId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
