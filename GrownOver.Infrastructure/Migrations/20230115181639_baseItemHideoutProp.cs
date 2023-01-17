using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrownOver.Infrastructure.Migrations
{
    public partial class baseItemHideoutProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomName",
                table: "BaseItemHideouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomName",
                table: "BaseItemHideouts");
        }
    }
}
