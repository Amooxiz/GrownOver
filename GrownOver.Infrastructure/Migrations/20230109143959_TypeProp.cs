using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrownOver.Infrastructure.Migrations
{
    public partial class TypeProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "BaseItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "BaseItems");
        }
    }
}
