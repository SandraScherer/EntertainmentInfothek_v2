using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameConfiguration : IEntityTypeConfiguration<VideoGame>
{
    public void Configure(EntityTypeBuilder<VideoGame> builder)
    {
        builder.ToTable("VideoGame");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.OriginalTitle).HasColumnName("OriginalTitle");
        builder.Property(x => x.EnglishTitle).HasColumnName("EnglishTitle");
        builder.Property(x => x.GermanTitle).HasColumnName("GermanTitle");
        builder.Property(x => x.TypeId).HasColumnName("TypeID");
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

        // FK: VideoGame.CastStatusID -> Status.ID
        builder.HasOne(x => x.CastStatus).WithMany(x => x.VideoGameCastStatuss).HasForeignKey(x => x.CastStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame.CrewStatusID -> Status.ID
        builder.HasOne(x => x.CrewStatus).WithMany(x => x.VideoGameCrewStatuss).HasForeignKey(x => x.CrewStatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame.ConnectionID -> Connection.ID
        builder.HasOne(x => x.Connection).WithMany(x => x.VideoGames).HasForeignKey(x => x.ConnectionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGameStatuss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame.TypeID -> Type.ID
        builder.HasOne(x => x.Type).WithMany(x => x.VideoGames).HasForeignKey(x => x.TypeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
