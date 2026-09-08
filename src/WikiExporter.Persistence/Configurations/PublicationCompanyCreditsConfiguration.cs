using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WikiExporter.Persistence.Entities;

namespace WikiExporter.Persistence.Configurations;

/// <summary>Explicit EF Core mapping for <c>Publication_CompanyCredits</c>. No conventions are relied upon for columns/FKs.</summary>
public sealed class PublicationCompanyCreditsConfiguration : IEntityTypeConfiguration<PublicationCompanyCredits>
{
    public void Configure(EntityTypeBuilder<PublicationCompanyCredits> builder)
    {
        builder.ToTable("Publication_CompanyCredits");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ID").IsRequired();
        builder.Property(x => x.PublicationId).HasColumnName("PublicationID");
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

        // FK: Publication_CompanyCredits.CompanyID -> Company.ID
        builder.HasOne(x => x.Company).WithMany(x => x.PublicationCompanyCreditss).HasForeignKey(x => x.CompanyId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_CompanyCredits.CountryID -> Country.ID
        builder.HasOne(x => x.Country).WithMany(x => x.PublicationCompanyCreditss).HasForeignKey(x => x.CountryId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_CompanyCredits.DepartmentID -> Department.ID
        builder.HasOne(x => x.Department).WithMany(x => x.PublicationCompanyCreditss).HasForeignKey(x => x.DepartmentId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_CompanyCredits.PublicationID -> Publication.ID
        builder.HasOne(x => x.Publication).WithMany(x => x.PublicationCompanyCreditss).HasForeignKey(x => x.PublicationId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);

        // FK: Publication_CompanyCredits.StatusID -> Status.ID
        builder.HasOne(x => x.Status).WithMany(x => x.PublicationCompanyCreditss).HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
