using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCore5Test.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cool_stuff");

            migrationBuilder.CreateTable(
                name: "my_cools",
                schema: "cool_stuff",
                columns: table => new
                {
                    FirstId = table.Column<int>(nullable: false),
                    SecondId = table.Column<int>(nullable: false),
                    SomeText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_my_cools", x => new { x.FirstId, x.SecondId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "my_cools",
                schema: "cool_stuff");
        }
    }
}
