using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_Project.Migrations
{
    public partial class AddedIsFinishedToSubTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: new Guid("5c978646-9aa5-4231-8242-d4dc96a8fa7a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: new Guid("85e45b4f-462b-460a-ad0a-c77d9ada38e7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: new Guid("9cf87582-ad39-4531-9614-fcdbf7adeb96"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: new Guid("e24d1c51-0880-4745-a08a-6ba9f23a41ac"));

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "SubTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color_A", "Color_B", "Color_G", "Color_R", "Name" },
                values: new object[] { new Guid("95d8e949-76e6-4aa4-b695-1225fcfdd1c5"), (byte)0, (byte)0, (byte)0, (byte)0, "Exercise" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color_A", "Color_B", "Color_G", "Color_R", "Name" },
                values: new object[] { new Guid("b5ed1070-5d31-47a5-86cc-751ffe8ab3de"), (byte)0, (byte)0, (byte)0, (byte)0, "Shopping" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color_A", "Color_B", "Color_G", "Color_R", "Name" },
                values: new object[] { new Guid("d58f15b0-c515-45b4-93fb-db9db0f16236"), (byte)0, (byte)0, (byte)0, (byte)0, "School" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color_A", "Color_B", "Color_G", "Color_R", "Name" },
                values: new object[] { new Guid("ded28ec5-b198-4b0b-89c1-e3edec9593b3"), (byte)0, (byte)0, (byte)0, (byte)0, "Project" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: new Guid("95d8e949-76e6-4aa4-b695-1225fcfdd1c5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: new Guid("b5ed1070-5d31-47a5-86cc-751ffe8ab3de"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: new Guid("d58f15b0-c515-45b4-93fb-db9db0f16236"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: new Guid("ded28ec5-b198-4b0b-89c1-e3edec9593b3"));

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "SubTasks");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color_A", "Color_B", "Color_G", "Color_R", "Name" },
                values: new object[] { new Guid("5c978646-9aa5-4231-8242-d4dc96a8fa7a"), (byte)0, (byte)0, (byte)0, (byte)0, "School" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color_A", "Color_B", "Color_G", "Color_R", "Name" },
                values: new object[] { new Guid("85e45b4f-462b-460a-ad0a-c77d9ada38e7"), (byte)0, (byte)0, (byte)0, (byte)0, "Project" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color_A", "Color_B", "Color_G", "Color_R", "Name" },
                values: new object[] { new Guid("9cf87582-ad39-4531-9614-fcdbf7adeb96"), (byte)0, (byte)0, (byte)0, (byte)0, "Exercise" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color_A", "Color_B", "Color_G", "Color_R", "Name" },
                values: new object[] { new Guid("e24d1c51-0880-4745-a08a-6ba9f23a41ac"), (byte)0, (byte)0, (byte)0, (byte)0, "Shopping" });
        }
    }
}
