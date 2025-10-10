using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokémonGame.Migrations
{
    /// <inheritdoc />
    public partial class CategoryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StartingPokemonHP",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartingPokemonId",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartingPokemonHP",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "StartingPokemonId",
                table: "Trainers");
        }
    }
}
