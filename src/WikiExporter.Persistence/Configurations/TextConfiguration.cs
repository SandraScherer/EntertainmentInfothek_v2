using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Text</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class TextConfiguration : IEntityTypeConfiguration<Text>
{
    public void Configure(EntityTypeBuilder<Text> builder)
    {
        builder.ToTable("Text");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.Content).HasColumnName("Content");
        builder.Property(x => x.LanguageId).HasColumnName("LanguageID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Text.LanguageID -> Language.ID
        builder.HasOne(x => x.Language).WithMany(x => x.Texts).HasForeignKey(x => x.LanguageId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Text.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.Texts).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
