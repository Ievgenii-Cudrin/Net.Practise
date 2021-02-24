using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    public partial class CreateOneToManyEmployeeJobCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessEntityID",
                table: "JobCandidate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobCandidate_BusinessEntityID",
                table: "JobCandidate",
                column: "BusinessEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobCandidate_Employee_BusinessEntityID",
                table: "JobCandidate",
                column: "BusinessEntityID",
                principalTable: "Employee",
                principalColumn: "BusinessEntityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobCandidate_Employee_BusinessEntityID",
                table: "JobCandidate");

            migrationBuilder.DropIndex(
                name: "IX_JobCandidate_BusinessEntityID",
                table: "JobCandidate");

            migrationBuilder.DropColumn(
                name: "BusinessEntityID",
                table: "JobCandidate");
        }
    }
}
