using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_Project.Migrations
{
    public partial class AddedTaskPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: new Guid("2912bb7e-4103-4274-ad4b-139005a816c0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: new Guid("ac424a08-20be-45fb-bffb-7493c7ddc226"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: new Guid("b035587f-37f4-4d34-9439-e797d8713c10"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: new Guid("b0985e44-f762-4b45-b28a-7f879265ba37"));

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tasks");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color_A", "Color_B", "Color_G", "Color_R", "Name" },
                values: new object[] { new Guid("2912bb7e-4103-4274-ad4b-139005a816c0"), (byte)0, (byte)0, (byte)0, (byte)0, "School" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color_A", "Color_B", "Color_G", "Color_R", "Name" },
                values: new object[] { new Guid("ac424a08-20be-45fb-bffb-7493c7ddc226"), (byte)0, (byte)0, (byte)0, (byte)0, "Exercise" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color_A", "Color_B", "Color_G", "Color_R", "Name" },
                values: new object[] { new Guid("b035587f-37f4-4d34-9439-e797d8713c10"), (byte)0, (byte)0, (byte)0, (byte)0, "Shopping" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color_A", "Color_B", "Color_G", "Color_R", "Name" },
                values: new object[] { new Guid("b0985e44-f762-4b45-b28a-7f879265ba37"), (byte)0, (byte)0, (byte)0, (byte)0, "Project" });
        }
    }
}
