using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    public partial class CreatePrimaryKeyEmployeeDepartmentShiftId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartmen",
                table: "EmployeeDepartmen");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDepartmen_ShiftID",
                table: "EmployeeDepartmen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartmen",
                table: "EmployeeDepartmen",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmen_BusinessEntityID",
                table: "EmployeeDepartmen",
                column: "BusinessEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartmen",
                table: "EmployeeDepartmen");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDepartmen_BusinessEntityID",
                table: "EmployeeDepartmen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartmen",
                table: "EmployeeDepartmen",
                column: "BusinessEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmen_ShiftID",
                table: "EmployeeDepartmen",
                column: "ShiftID");
        }
    }
}
