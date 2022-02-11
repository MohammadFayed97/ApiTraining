namespace Entities.Configurations;

using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");
        builder.HasMany(e => e.Employees).WithOne(e => e.Company).HasForeignKey(e => e.CompanyId).OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new Company
        {
            Id = new Guid("a51b2d0a-5960-48b1-a9cf-edfe89e369de"),
            Name = "InnoTech",
            Address = "Elfateh, Tanta, Egypt",
            Country = "Egypt"
        },
        new Company
        {
            Id = new Guid("558d3d58-915f-4611-b22d-7ef105146956"),
            Name = "SpaceX",
            Address = "London, England",
            Country = "England"
        });
    }
}