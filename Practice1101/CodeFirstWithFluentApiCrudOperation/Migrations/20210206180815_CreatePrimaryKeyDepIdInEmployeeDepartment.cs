using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    public partial class CreatePrimaryKeyDepIdInEmployeeDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartmen",
                table: "EmployeeDepartmen");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "EmployeeDepartmen",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartmen",
                table: "EmployeeDepartmen",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmen_ShiftID",
                table: "EmployeeDepartmen",
                column: "ShiftID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartmen",
                table: "EmployeeDepartmen");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDepartmen_ShiftID",
                table: "EmployeeDepartmen");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "EmployeeDepartmen");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartmen",
                table: "EmployeeDepartmen",
                column: "ShiftID");
        }
    }
}
