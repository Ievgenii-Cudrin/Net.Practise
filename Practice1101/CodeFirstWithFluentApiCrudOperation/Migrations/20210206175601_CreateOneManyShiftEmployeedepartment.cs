using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    public partial class CreateOneManyShiftEmployeedepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShiftID",
                table: "EmployeeDepartmen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmen_ShiftID",
                table: "EmployeeDepartmen",
                column: "ShiftID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartmen_Shift_ShiftID",
                table: "EmployeeDepartmen",
                column: "ShiftID",
                principalTable: "Shift",
                principalColumn: "ShiftID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartmen_Shift_ShiftID",
                table: "EmployeeDepartmen");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDepartmen_ShiftID",
                table: "EmployeeDepartmen");

            migrationBuilder.DropColumn(
                name: "ShiftID",
                table: "EmployeeDepartmen");
        }
    }
}
