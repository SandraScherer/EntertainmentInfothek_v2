using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Episode_CompanyCredits</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class EpisodeCompanyCreditsConfiguration : IEntityTypeConfiguration<EpisodeCompanyCredits>
{
    public void Configure(EntityTypeBuilder<EpisodeCompanyCredits> builder)
    {
        builder.ToTable("Episode_CompanyCredits");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.EpisodeId).HasColumnName("EpisodeID");
        builder.Property(x => x.CompanyId).HasColumnName("CompanyID");
        builder.Property(x => x.DepartmentId).HasColumnName("DepartmentID");
        builder.Property(x => x.CountryId).HasColumnName("CountryID");
        builder.Property(x => x.EnglishRole).HasColumnName("EnglishRole");
        builder.Property(x => x.GermanRole).HasColumnName("GermanRole");
        builder.Property(x => x.Order).HasColumnName("Order");
        builder.Property(x => x.Details).HasColumnName("Details");
        builder.Property(x => x.Notes).HasColumnName("Notes");
        builder.Property(x => x.StatusId).HasColumnName("StatusID");
        builder.Property(x => x.LastUpdated).HasColumnName("LastUpdated");

        // FK: Episode_CompanyCredits.CompanyID -> Company.ID
        builder.HasOne(x => x.Company).WithMany(x => x.EpisodeCompanyCreditss).HasForeignKey(x => x.CompanyId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_CompanyCredits.CountryID -> Country.ID
        builder.HasOne(x => x.Country).WithMany(x => x.EpisodeCompanyCreditss).HasForeignKey(x => x.CountryId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_CompanyCredits.DepartmentID -> Department.ID
        builder.HasOne(x => x.Department).WithMany(x => x.EpisodeCompanyCreditss).HasForeignKey(x => x.DepartmentId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_CompanyCredits.EpisodeID -> Episode.ID
        builder.HasOne(x => x.Episode).WithMany(x => x.EpisodeCompanyCreditss).HasForeignKey(x => x.EpisodeId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Episode_CompanyCredits.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.EpisodeCompanyCreditss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
