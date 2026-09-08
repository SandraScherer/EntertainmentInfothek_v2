using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_Cast</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesCastConfiguration : IEntityTypeConfiguration<SeriesCast>
{
    public void Configure(EntityTypeBuilder<SeriesCast> builder)
    {
        builder.ToTable("Series_Cast");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
        builder.Property(x => x.ActorId).HasColumnName("ActorID");
        builder.Property(x => x.EnglishDubberId).HasColumnName("EnglishDubberID");
        builder.Property(x => x.GermanDubberId).HasColumnName("GermanDubberID");
        builder.Property(x => x.CharacterId).HasColumnName("CharacterID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series_Cast.ActorID -> Person.ID
        builder.HasOne(x => x.Actor).WithMany(x => x.SeriesCastActors).HasForeignKey(x => x.ActorId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Cast.CharacterID -> Person.ID
        builder.HasOne(x => x.Character).WithMany(x => x.SeriesCastCharacters).HasForeignKey(x => x.CharacterId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Cast.EnglishDubberID -> Person.ID
        builder.HasOne(x => x.EnglishDubber).WithMany(x => x.SeriesCastEnglishDubbers).HasForeignKey(x => x.EnglishDubberId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Cast.GermanDubberID -> Person.ID
        builder.HasOne(x => x.GermanDubber).WithMany(x => x.SeriesCastGermanDubbers).HasForeignKey(x => x.GermanDubberId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Cast.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesCasts).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_Cast.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesCasts).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
