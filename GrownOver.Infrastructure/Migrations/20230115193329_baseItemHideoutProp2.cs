using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrownOver.Infrastructure.Migrations
{
    public partial class baseItemHideoutProp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Durability",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Durability",
                table: "Armors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Durability",
                table: "Weapons",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Durability",
                table: "Armors",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
