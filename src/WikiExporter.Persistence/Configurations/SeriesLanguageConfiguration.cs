using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Language</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesLanguageConfiguration : IEntityTypeConfiguration<SeriesLanguage>
{
    public void Configure(EntityTypeBuilder<SeriesLanguage> builder)
    {
        builder.ToTable("Series_Language");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.LanguageId).HasColumnName("LanguageID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Language.LanguageID -> Language.ID
        builder.HasOne(x => x.Language).WithMany(x => x.SeriesLanguages).HasForeignKey(x => x.LanguageId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Language.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesLanguages).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Language.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesLanguages).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
