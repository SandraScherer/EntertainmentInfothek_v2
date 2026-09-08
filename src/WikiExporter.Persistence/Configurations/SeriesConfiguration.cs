using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesConfiguration : IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> builder)
    {
        builder.ToTable("Series");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalTitle).HasColumnName("OriginalTitle");
        builder.Property(x => x.EnglishTitle).HasColumnName("EnglishTitle");
        builder.Property(x => x.GermanTitle).HasColumnName("GermanTitle");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
        builder.Property(x => x.NoOfSeasons).HasColumnName("NoOfSeasons");
        builder.Property(x => x.NoOfEpisodes).HasColumnName("NoOfEpisodes");
        builder.Property(x => x.Budget).HasColumnName("Budget");
        builder.Property(x => x.WorldwideGross).HasColumnName("WorldwideGross");
        builder.Property(x => x.WorldwideGrossDate).HasColumnName("WorldwideGrossDate");
        builder.Property(x => x.CastStatusId).HasColumnName("CastStatusID");
        builder.Property(x => x.CrewStatusId).HasColumnName("CrewStatusID");
        builder.Property(x => x.ConnectionId).HasColumnName("ConnectionID");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Series.CastStatusID -> Status.ID
        builder.HasOne(x => x.CastStatus).WithMany(x => x.SeriesCastStatuss).HasForeignKey(x => x.CastStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series.ConnectionID -> Connection.ID
        builder.HasOne(x => x.Connection).WithMany(x => x.Seriess).HasForeignKey(x => x.ConnectionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series.CrewStatusID -> Status.ID
        builder.HasOne(x => x.CrewStatus).WithMany(x => x.SeriesCrewStatuss).HasForeignKey(x => x.CrewStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesStatuss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series.TypeID -> Type.ID
        builder.HasOne(x => x.Type).WithMany(x => x.Seriess).HasForeignKey(x => x.TypeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
