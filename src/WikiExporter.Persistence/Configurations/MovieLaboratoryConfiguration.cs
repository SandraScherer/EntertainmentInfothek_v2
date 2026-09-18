using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Movie_Laboratory</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class MovieLaboratoryConfiguration : IEntityTypeConfiguration<MovieLaboratoryEntity>
{
    public void Configure(EntityTypeBuilder<MovieLaboratoryEntity> builder)
    {
        builder.ToTable("Movie_Laboratory");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.MovieId).HasColumnName("MovieID");
        builder.Property(x => x.LaboratoryId).HasColumnName("LaboratoryID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Movie_Laboratory.LaboratoryID -> Laboratory.ID
        builder.HasOne(x => x.LaboratoryEntity).WithMany().HasForeignKey(x => x.LaboratoryId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Laboratory.MovieID -> Movie.ID
        builder.HasOne(x => x.MovieEntity).WithMany().HasForeignKey(x => x.MovieId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Movie_Laboratory.StatusID -> Status.ID
        builder.HasOne(x => x.StatusEntity).WithMany().HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
