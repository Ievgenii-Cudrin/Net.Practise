using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    public partial class CreateEmployeeDepart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDepartment");

            migrationBuilder.CreateTable(
                name: "EmployeeDepartmen",
                columns: table => new
                {
                    StartDateDocument = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndStateDocument = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartmen", x => x.StartDateDocument);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDepartmen");

            migrationBuilder.CreateTable(
                name: "EmployeeDepartment",
                columns: table => new
                {
                    StartDateDocument = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndStateDocument = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartment", x => x.StartDateDocument);
                });
        }
    }
}
