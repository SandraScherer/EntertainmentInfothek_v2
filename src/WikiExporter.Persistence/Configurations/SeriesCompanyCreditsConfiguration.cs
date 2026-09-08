using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Series_CompanyCredits</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class SeriesCompanyCreditsConfiguration : IEntityTypeConfiguration<SeriesCompanyCredits>
{
    public void Configure(EntityTypeBuilder<SeriesCompanyCredits> builder)
    {
        builder.ToTable("Series_CompanyCredits");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.SeriesId).HasColumnName("SeriesID");
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

        // FK: Series_CompanyCredits.CompanyID -> Company.ID
        builder.HasOne(x => x.Company).WithMany(x => x.SeriesCompanyCreditss).HasForeignKey(x => x.CompanyId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_CompanyCredits.CountryID -> Country.ID
        builder.HasOne(x => x.Country).WithMany(x => x.SeriesCompanyCreditss).HasForeignKey(x => x.CountryId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_CompanyCredits.DepartmentID -> Department.ID
        builder.HasOne(x => x.Department).WithMany(x => x.SeriesCompanyCreditss).HasForeignKey(x => x.DepartmentId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_CompanyCredits.SeriesID -> Series.ID
        builder.HasOne(x => x.Series).WithMany(x => x.SeriesCompanyCreditss).HasForeignKey(x => x.SeriesId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Series_CompanyCredits.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.SeriesCompanyCreditss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
