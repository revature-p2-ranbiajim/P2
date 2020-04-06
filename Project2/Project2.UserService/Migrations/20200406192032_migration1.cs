using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.UserService.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.Username);
                });

            migrationBuilder.InsertData(
                table: "UserModels",
                columns: new[] { "Username", "EmailAddress", "FirstName", "LastName", "Password" },
                values: new object[] { "Randall1", "randall@email.com", "Randall", "Steinkamp", "password" });

            migrationBuilder.InsertData(
                table: "UserModels",
                columns: new[] { "Username", "EmailAddress", "FirstName", "LastName", "Password" },
                values: new object[] { "Jim1", "jim@email.com", "Jim", "Gazaway", "password" });

            migrationBuilder.InsertData(
                table: "UserModels",
                columns: new[] { "Username", "EmailAddress", "FirstName", "LastName", "Password" },
                values: new object[] { "Bianca1", "bianca@email.com", "Bianca", "Visconti", "password" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserModels");
        }
    }
}
