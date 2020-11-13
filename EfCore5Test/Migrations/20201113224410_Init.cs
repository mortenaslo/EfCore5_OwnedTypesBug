using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCore5Test.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Firsts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firsts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seconds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seconds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyCoolModels",
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
                    table.PrimaryKey("PK_MyCoolModels", x => new { x.MyCoolModel_FirstId, x.MyCoolModel_SecondId });
                    table.ForeignKey(
                        name: "FK_MyCoolModels_Firsts_MyCoolModel_FirstId",
                        column: x => x.MyCoolModel_FirstId,
                        principalTable: "Firsts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyCoolModels_Seconds_MyCoolModel_SecondId",
                        column: x => x.MyCoolModel_SecondId,
                        principalTable: "Seconds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyCoolModels_MyCoolModel_SecondId",
                table: "MyCoolModels",
                column: "MyCoolModel_SecondId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyCoolModels");

            migrationBuilder.DropTable(
                name: "Firsts");

            migrationBuilder.DropTable(
                name: "Seconds");
        }
    }
}
