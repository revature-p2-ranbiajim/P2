using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.GridService.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GridModels",
                columns: table => new
                {
                    GridModelId = table.Column<long>(nullable: false),
                    GridModelInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GridModels", x => x.GridModelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GridModels");
        }
    }
}
