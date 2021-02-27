using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    public partial class CreateOneToManyEmployeeSalesPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessEntityID",
                table: "SalesPerson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesPerson_BusinessEntityID",
                table: "SalesPerson",
                column: "BusinessEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPerson_Employee_BusinessEntityID",
                table: "SalesPerson",
                column: "BusinessEntityID",
                principalTable: "Employee",
                principalColumn: "BusinessEntityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesPerson_Employee_BusinessEntityID",
                table: "SalesPerson");

            migrationBuilder.DropIndex(
                name: "IX_SalesPerson_BusinessEntityID",
                table: "SalesPerson");

            migrationBuilder.DropColumn(
                name: "BusinessEntityID",
                table: "SalesPerson");
        }
    }
}
