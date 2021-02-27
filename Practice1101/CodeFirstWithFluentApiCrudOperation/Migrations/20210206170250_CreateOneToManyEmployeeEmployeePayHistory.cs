using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    public partial class CreateOneToManyEmployeeEmployeePayHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessEntityID",
                table: "EmployeePayHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayHistory_BusinessEntityID",
                table: "EmployeePayHistory",
                column: "BusinessEntityID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePayHistory_RateChangeDate",
                table: "EmployeePayHistory",
                column: "RateChangeDate",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePayHistory_Employee_BusinessEntityID",
                table: "EmployeePayHistory",
                column: "BusinessEntityID",
                principalTable: "Employee",
                principalColumn: "BusinessEntityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePayHistory_Employee_BusinessEntityID",
                table: "EmployeePayHistory");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayHistory_BusinessEntityID",
                table: "EmployeePayHistory");

            migrationBuilder.DropIndex(
                name: "IX_EmployeePayHistory_RateChangeDate",
                table: "EmployeePayHistory");

            migrationBuilder.DropColumn(
                name: "BusinessEntityID",
                table: "EmployeePayHistory");
        }
    }
}
