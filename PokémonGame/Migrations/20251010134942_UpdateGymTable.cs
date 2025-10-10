using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokémonGame.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGymTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PokemonId",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Leader",
                table: "Gyms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Gyms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Leader",
                table: "Gyms");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Gyms");
        }
    }
}
