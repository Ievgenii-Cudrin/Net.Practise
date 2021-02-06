using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstWithFluentApiCrudOperation.Migrations
{
    public partial class CreateJobCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobCandidate",
                columns: table => new
                {
                    JobCandidateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCandidate", x => x.JobCandidateID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobCandidate");
        }
    }
}
