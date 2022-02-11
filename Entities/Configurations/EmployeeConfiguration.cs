namespace Entities.Configurations;

using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasData(new Employee
        {
            Id = new Guid("0b2f6d86-47b3-4a9b-ad63-6efd59de2390"),
            Name = "Mohammad Fayed",
            Age = 21,
            CompanyId = new Guid("a51b2d0a-5960-48b1-a9cf-edfe89e369de"),
            Position = "Software Engineer",
        },
        new Employee
        {
            Id = new Guid("1526420e-e93e-467a-8ce5-103faef83fde"),
            Name = "Fatma Farag",
            Age = 21,
            CompanyId = new Guid("558d3d58-915f-4611-b22d-7ef105146956"),
            Position = "Software Engineer",
        },
        new Employee
        {
            Id = new Guid("07691a34-b2ff-4997-9d15-894f085c7a40"),
            Name = "Salma Negm",
            Age = 22,
            CompanyId = new Guid("558d3d58-915f-4611-b22d-7ef105146956"),
            Position = "Software Engineer",
        },
        new Employee
        {
            Id = new Guid("3f6b994b-3b75-451a-a174-cfb1acc63d40"),
            Name = "Abdullah Elhanafy",
            Age = 30,
            CompanyId = new Guid("a51b2d0a-5960-48b1-a9cf-edfe89e369de"),
            Position = "Business Analist"
        });
    }
}