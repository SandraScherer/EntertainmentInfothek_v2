using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Weblink</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class WeblinkConfiguration : IEntityTypeConfiguration<Weblink>
{
    public void Configure(EntityTypeBuilder<Weblink> builder)
    {
        builder.ToTable("Weblink");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.URL).HasColumnName("URL");
        builder.Property(x => x.EnglishName).HasColumnName("EnglishName");
        builder.Property(x => x.GermanName).HasColumnName("GermanName");
        builder.Property(x => x.LanguageId).HasColumnName("LanguageID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Weblink.LanguageID -> Language.ID
        builder.HasOne(x => x.Language).WithMany(x => x.Weblinks).HasForeignKey(x => x.LanguageId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Weblink.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.Weblinks).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
