using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_Project.Migrations
{
    public partial class SimplifyingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TagCategories_Category_ID",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "TagCategories");

            migrationBuilder.DropIndex(
                name: "IX_Tags_Category_ID",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Category_ID",
                table: "Tags");

            migrationBuilder.AddColumn<Guid>(
                name: "Column_ID",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Column_ID",
                table: "Tasks",
                column: "Column_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Columns_Column_ID",
                table: "Tasks",
                column: "Column_ID",
                principalTable: "Columns",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Columns_Column_ID",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_Column_ID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Column_ID",
                table: "Tasks");

            migrationBuilder.AddColumn<Guid>(
                name: "Category_ID",
                table: "Tags",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TagCategories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Limit = table.Column<uint>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagCategories", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Category_ID",
                table: "Tags",
                column: "Category_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TagCategories_Category_ID",
                table: "Tags",
                column: "Category_ID",
                principalTable: "TagCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
