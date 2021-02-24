using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    public partial class CreateShiftUniqKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Shift_ShiftID",
                table: "Shift",
                column: "ShiftID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shift_ShiftID",
                table: "Shift");
        }
    }
}
