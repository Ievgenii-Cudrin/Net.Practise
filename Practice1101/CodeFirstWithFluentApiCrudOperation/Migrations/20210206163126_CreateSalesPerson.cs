using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    public partial class CreateSalesPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesPerson",
                columns: table => new
                {
                    SalesPersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesQuota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPerson", x => x.SalesPersonID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesPerson");
        }
    }
}
