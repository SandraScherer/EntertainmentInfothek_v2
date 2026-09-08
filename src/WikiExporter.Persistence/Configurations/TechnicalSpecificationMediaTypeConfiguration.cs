using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>TechnicalSpecification_MediaType</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TechnicalSpecificationMediaTypeConfiguration : IEntityTypeConfiguration<TechnicalSpecificationMediaType>
{
    public void Configure(EntityTypeBuilder<TechnicalSpecificationMediaType> builder)
    {
        builder.ToTable("TechnicalSpecification_MediaType");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.TechnicalSpecificationId).HasColumnName("TechnicalSpecificationID");
        builder.Property(x => x.MediaTypeId).HasColumnName("MediaTypeID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: TechnicalSpecification_MediaType.MediaTypeID -> MediaType.ID
        builder.HasOne(x => x.MediaType).WithMany(x => x.TechnicalSpecificationMediaTypes).HasForeignKey(x => x.MediaTypeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_MediaType.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.TechnicalSpecificationMediaTypes).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: TechnicalSpecification_MediaType.TechnicalSpecificationID -> TechnicalSpecification.ID
        builder.HasOne(x => x.TechnicalSpecification).WithMany(x => x.TechnicalSpecificationMediaTypes).HasForeignKey(x => x.TechnicalSpecificationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
