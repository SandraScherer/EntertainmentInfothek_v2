using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Publication_ReleaseDate</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PublicationReleaseDateConfiguration : IEntityTypeConfiguration<PublicationReleaseDate>
{
    public void Configure(EntityTypeBuilder<PublicationReleaseDate> builder)
    {
        builder.ToTable("Publication_ReleaseDate");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PublicationId).HasColumnName("PublicationID");
        builder.Property(x => x.ReleaseDate).HasColumnName("ReleaseDate");
        builder.Property(x => x.EnglishDescription).HasColumnName("EnglishDescription");
        builder.Property(x => x.GermanDescription).HasColumnName("GermanDescription");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Publication_ReleaseDate.PublicationID -> Publication.ID
        builder.HasOne(x => x.Publication).WithMany(x => x.PublicationReleaseDates).HasForeignKey(x => x.PublicationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_ReleaseDate.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.PublicationReleaseDates).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
