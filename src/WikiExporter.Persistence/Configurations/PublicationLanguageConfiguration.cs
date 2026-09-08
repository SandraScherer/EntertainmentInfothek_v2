using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Publication_Language</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PublicationLanguageConfiguration : IEntityTypeConfiguration<PublicationLanguage>
{
    public void Configure(EntityTypeBuilder<PublicationLanguage> builder)
    {
        builder.ToTable("Publication_Language");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PublicationId).HasColumnName("PublicationID");
        builder.Property(x => x.LanguageId).HasColumnName("LanguageID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Publication_Language.LanguageID -> Language.ID
        builder.HasOne(x => x.Language).WithMany(x => x.PublicationLanguages).HasForeignKey(x => x.LanguageId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Language.PublicationID -> Publication.ID
        builder.HasOne(x => x.Publication).WithMany(x => x.PublicationLanguages).HasForeignKey(x => x.PublicationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Language.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.PublicationLanguages).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
