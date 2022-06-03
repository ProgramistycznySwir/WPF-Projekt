using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_Project.Migrations
{
    public partial class AddedColorToTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Color_A",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Color_B",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Color_G",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Color_R",
                table: "Tags",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color_A",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Color_B",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Color_G",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Color_R",
                table: "Tags");
        }
    }
}
