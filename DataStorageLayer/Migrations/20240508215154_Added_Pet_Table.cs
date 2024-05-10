using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStorageLayer.Migrations
{
    /// <inheritdoc />
    public partial class Added_Pet_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Pilots",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Championships = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_TeamId",
                table: "Pilots",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pilots_Teams_TeamId",
                table: "Pilots",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pilots_Teams_TeamId",
                table: "Pilots");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Pilots_TeamId",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Pilots");
        }
    }
}
