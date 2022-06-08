using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_Project.Migrations
{
    public partial class ClarifyingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagTask");

            migrationBuilder.CreateTable(
                name: "BoardTaskTag",
                columns: table => new
                {
                    TagsID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TasksID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardTaskTag", x => new { x.TagsID, x.TasksID });
                    table.ForeignKey(
                        name: "FK_BoardTaskTag_Tags_TagsID",
                        column: x => x.TagsID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardTaskTag_Tasks_TasksID",
                        column: x => x.TasksID,
                        principalTable: "Tasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardTaskTag_TasksID",
                table: "BoardTaskTag",
                column: "TasksID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardTaskTag");

            migrationBuilder.CreateTable(
                name: "TagTask",
                columns: table => new
                {
                    TagsID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TasksID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTask", x => new { x.TagsID, x.TasksID });
                    table.ForeignKey(
                        name: "FK_TagTask_Tags_TagsID",
                        column: x => x.TagsID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagTask_Tasks_TasksID",
                        column: x => x.TasksID,
                        principalTable: "Tasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagTask_TasksID",
                table: "TagTask",
                column: "TasksID");
        }
    }
}
