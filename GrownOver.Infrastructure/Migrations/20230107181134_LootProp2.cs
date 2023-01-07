using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrownOver.Infrastructure.Migrations
{
    public partial class LootProp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Loot",
                table: "BaseItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Loot",
                table: "BaseItems");
        }
    }
}
