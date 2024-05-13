using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStorageLayer.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_AddedObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wins",
                table: "Teams",
                newName: "Poles");

            migrationBuilder.AddColumn<string>(
                name: "Chassis",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Engine",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FastestLaps",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HighestPosition",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeamChief",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chassis",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Engine",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "FastestLaps",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "HighestPosition",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamChief",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "Poles",
                table: "Teams",
                newName: "Wins");
        }
    }
}
