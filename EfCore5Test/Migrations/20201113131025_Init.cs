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
                    MyCoolModel_FirstId = table.Column<int>(type: "int", nullable: false),
                    MyCoolModel_SecondId = table.Column<int>(type: "int", nullable: false),
                    FirstId = table.Column<int>(type: "int", nullable: true),
                    SecondId = table.Column<int>(type: "int", nullable: true),
                    SomeText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_my_cools", x => new { x.MyCoolModel_FirstId, x.MyCoolModel_SecondId });
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
