using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Country</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalShortName).HasColumnName("OriginalShortName");
        builder.Property(x => x.OriginalName).HasColumnName("OriginalName");
        builder.Property(x => x.EnglishShortName).HasColumnName("EnglishShortName");
        builder.Property(x => x.EnglishName).HasColumnName("EnglishName");
        builder.Property(x => x.GermanShortName).HasColumnName("GermanShortName");
        builder.Property(x => x.GermanName).HasColumnName("GermanName");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Country.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.Countrys).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
