using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    public partial class CreateOneToManyPersonEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PersonID",
                table: "Employee",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Persons_PersonID",
                table: "Employee",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Persons_PersonID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_PersonID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Employee");
        }
    }
}
