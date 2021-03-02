using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudOperationEFCodeFirst0502.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalIDNumber = table.Column<int>(type: "int", nullable: false),
                    LoginID = table.Column<int>(type: "int", nullable: false),
                    OrganizationLevel = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_Employee_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepartment",
                columns: table => new
                {
                    EmployeeDepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    ShiftID = table.Column<int>(type: "int", nullable: false),
                    StartDateDocument = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndStateDocument = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeBusinessEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartment", x => x.EmployeeDepartmentID);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartment_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartment_Employee_EmployeeBusinessEntityID",
                        column: x => x.EmployeeBusinessEntityID,
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartment_Shift_ShiftID",
                        column: x => x.ShiftID,
                        principalTable: "Shift",
                        principalColumn: "ShiftID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePayHistory",
                columns: table => new
                {
                    EmployeePayHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    PayFrequency = table.Column<int>(type: "int", nullable: false),
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false),
                    EmployeeBusinessEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayHistory", x => x.EmployeePayHistoryId);
                    table.ForeignKey(
                        name: "FK_EmployeePayHistory_Employee_EmployeeBusinessEntityID",
                        column: x => x.EmployeeBusinessEntityID,
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobCandidate",
                columns: table => new
                {
                    JobCandidateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false),
                    EmployeeBusinessEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCandidate", x => x.JobCandidateID);
                    table.ForeignKey(
                        name: "FK_JobCandidate_Employee_EmployeeBusinessEntityID",
                        column: x => x.EmployeeBusinessEntityID,
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                columns: table => new
                {
                    SalesPersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessEntitiID = table.Column<int>(type: "int", nullable: false),
                    SalesQuota = table.Column<int>(type: "int", nullable: false),
                    EmployeeBusinessEntityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPerson", x => x.SalesPersonID);
                    table.ForeignKey(
                        name: "FK_SalesPerson_Employee_EmployeeBusinessEntityID",
                        column: x => x.EmployeeBusinessEntityID,
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PersonID",
                table: "Employee",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartment_DepartmentID",
                table: "EmployeeDepartment",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartment_EmployeeBusinessEntityID",
                table: "EmployeeDepartment",
                column: "EmployeeBusinessEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartment_ShiftID",
                table: "EmployeeDepartment",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayHistory_EmployeeBusinessEntityID",
                table: "EmployeePayHistory",
                column: "EmployeeBusinessEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_JobCandidate_EmployeeBusinessEntityID",
                table: "JobCandidate",
                column: "EmployeeBusinessEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPerson_EmployeeBusinessEntityID",
                table: "SalesPerson",
                column: "EmployeeBusinessEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDepartment");

            migrationBuilder.DropTable(
                name: "EmployeePayHistory");

            migrationBuilder.DropTable(
                name: "JobCandidate");

            migrationBuilder.DropTable(
                name: "SalesPerson");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
