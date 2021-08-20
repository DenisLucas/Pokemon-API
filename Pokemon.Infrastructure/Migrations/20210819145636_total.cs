using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokemon.Infrastructure.Migrations
{
    public partial class total : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "total",
                table: "pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total",
                table: "pokemons");
        }
    }
}
