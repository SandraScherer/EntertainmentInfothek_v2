using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>VideoGame_CompanyCredits</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class VideoGameCompanyCreditsConfiguration : IEntityTypeConfiguration<VideoGameCompanyCredits>
{
    public void Configure(EntityTypeBuilder<VideoGameCompanyCredits> builder)
    {
        builder.ToTable("VideoGame_CompanyCredits");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.VideoGameId).HasColumnName("VideoGameID");
        builder.Property(x => x.CompanyId).HasColumnName("CompanyID");
        builder.Property(x => x.DepartmentId).HasColumnName("DepartmentID");
        builder.Property(x => x.PlatformId).HasColumnName("PlatformID");
        builder.Property(x => x.CountryId).HasColumnName("CountryID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: VideoGame_CompanyCredits.CompanyID -> Company.ID
        builder.HasOne(x => x.Company).WithMany(x => x.VideoGameCompanyCreditss).HasForeignKey(x => x.CompanyId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_CompanyCredits.CountryID -> Country.ID
        builder.HasOne(x => x.Country).WithMany(x => x.VideoGameCompanyCreditss).HasForeignKey(x => x.CountryId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_CompanyCredits.DepartmentID -> Department.ID
        builder.HasOne(x => x.Department).WithMany(x => x.VideoGameCompanyCreditss).HasForeignKey(x => x.DepartmentId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_CompanyCredits.PlatformID -> Platform.ID
        builder.HasOne(x => x.Platform).WithMany(x => x.VideoGameCompanyCreditss).HasForeignKey(x => x.PlatformId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_CompanyCredits.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.VideoGameCompanyCreditss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: VideoGame_CompanyCredits.VideoGameID -> VideoGame.ID
        builder.HasOne(x => x.VideoGame).WithMany(x => x.VideoGameCompanyCreditss).HasForeignKey(x => x.VideoGameId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
