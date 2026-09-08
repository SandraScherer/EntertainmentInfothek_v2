using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Text</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesTextConfiguration : IEntityTypeConfiguration<SeriesText>
{
    public void Configure(EntityTypeBuilder<SeriesText> builder)
    {
        builder.ToTable("Series_Text");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.TextId).HasColumnName("TextID");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Text.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesTexts).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Text.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesTexts).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Text.TextID -> Text.ID
        builder.HasOne(x => x.Text).WithMany(x => x.SeriesTexts).HasForeignKey(x => x.TextId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Text.TypeID -> TextType.ID
        builder.HasOne(x => x.Type).WithMany(x => x.SeriesTexts).HasForeignKey(x => x.TypeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
