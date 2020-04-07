using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.GridService.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GridModels",
                columns: table => new
                {
                    GridId = table.Column<long>(nullable: false),
                    SaveGrid = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Width = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GridModels", x => x.GridId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GridModels");
        }
    }
}
