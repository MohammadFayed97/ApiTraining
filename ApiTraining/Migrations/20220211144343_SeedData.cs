using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTraining.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "Country", "Name" },
                values: new object[] { new Guid("558d3d58-915f-4611-b22d-7ef105146956"), "London, England", "England", "SpaceX" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "Country", "Name" },
                values: new object[] { new Guid("a51b2d0a-5960-48b1-a9cf-edfe89e369de"), "Elfateh, Tanta, Egypt", "Egypt", "InnoTech" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("07691a34-b2ff-4997-9d15-894f085c7a40"), 22, new Guid("558d3d58-915f-4611-b22d-7ef105146956"), "Salma Negm", "Software Engineer" },
                    { new Guid("0b2f6d86-47b3-4a9b-ad63-6efd59de2390"), 21, new Guid("a51b2d0a-5960-48b1-a9cf-edfe89e369de"), "Mohammad Fayed", "Software Engineer" },
                    { new Guid("1526420e-e93e-467a-8ce5-103faef83fde"), 21, new Guid("558d3d58-915f-4611-b22d-7ef105146956"), "Fatma Farag", "Software Engineer" },
                    { new Guid("3f6b994b-3b75-451a-a174-cfb1acc63d40"), 30, new Guid("a51b2d0a-5960-48b1-a9cf-edfe89e369de"), "Abdullah Elhanafy", "Business Analist" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("07691a34-b2ff-4997-9d15-894f085c7a40"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("0b2f6d86-47b3-4a9b-ad63-6efd59de2390"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("1526420e-e93e-467a-8ce5-103faef83fde"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("3f6b994b-3b75-451a-a174-cfb1acc63d40"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("558d3d58-915f-4611-b22d-7ef105146956"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a51b2d0a-5960-48b1-a9cf-edfe89e369de"));
        }
    }
}
