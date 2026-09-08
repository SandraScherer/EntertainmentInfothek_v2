using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>AspectRatio</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class AspectRatioConfiguration : IEntityTypeConfiguration<AspectRatio>
{
    public void Configure(EntityTypeBuilder<AspectRatio> builder)
    {
        builder.ToTable("AspectRatio");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalName).HasColumnName("OriginalName");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: AspectRatio.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.AspectRatios).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
