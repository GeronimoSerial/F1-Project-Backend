using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataStorageLayer.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_Pilot_RemovePodiumsThisSeasson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PodiumsThisSeason",
                table: "Pilots");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PodiumsThisSeason",
                table: "Pilots",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
