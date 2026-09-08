using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Publication_Text</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PublicationTextConfiguration : IEntityTypeConfiguration<PublicationText>
{
    public void Configure(EntityTypeBuilder<PublicationText> builder)
    {
        builder.ToTable("Publication_Text");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PublicationId).HasColumnName("PublicationID");
        builder.Property(x => x.TextId).HasColumnName("TextID");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Publication_Text.PublicationID -> Publication.ID
        builder.HasOne(x => x.Publication).WithMany(x => x.PublicationTexts).HasForeignKey(x => x.PublicationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Text.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.PublicationTexts).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Text.TextID -> Text.ID
        builder.HasOne(x => x.Text).WithMany(x => x.PublicationTexts).HasForeignKey(x => x.TextId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_Text.TypeID -> TextType.ID
        builder.HasOne(x => x.Type).WithMany(x => x.PublicationTexts).HasForeignKey(x => x.TypeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
