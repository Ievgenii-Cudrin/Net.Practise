using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    public partial class CreateOneManyEmployeeEmployeeDepartmen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartmen",
                table: "EmployeeDepartmen");

            migrationBuilder.AddColumn<int>(
                name: "BusinessEntityID",
                table: "EmployeeDepartmen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartmen",
                table: "EmployeeDepartmen",
                column: "BusinessEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartmen_Employee_BusinessEntityID",
                table: "EmployeeDepartmen",
                column: "BusinessEntityID",
                principalTable: "Employee",
                principalColumn: "BusinessEntityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartmen_Employee_BusinessEntityID",
                table: "EmployeeDepartmen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartmen",
                table: "EmployeeDepartmen");

            migrationBuilder.DropColumn(
                name: "BusinessEntityID",
                table: "EmployeeDepartmen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartmen",
                table: "EmployeeDepartmen",
                column: "StartDateDocument");
        }
    }
}
