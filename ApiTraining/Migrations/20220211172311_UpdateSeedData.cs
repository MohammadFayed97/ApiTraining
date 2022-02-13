using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTraining.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("558d3d58-915f-4611-b22d-7ef105146956"),
                column: "Address",
                value: "London");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a51b2d0a-5960-48b1-a9cf-edfe89e369de"),
                column: "Address",
                value: "Elfateh, Tanta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("558d3d58-915f-4611-b22d-7ef105146956"),
                column: "Address",
                value: "London, England");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a51b2d0a-5960-48b1-a9cf-edfe89e369de"),
                column: "Address",
                value: "Elfateh, Tanta, Egypt");
        }
    }
}
