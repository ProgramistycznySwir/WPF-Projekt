using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF_Project.Migrations
{
    public partial class AddedSeededValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Columns",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "To Do" });

            migrationBuilder.InsertData(
                table: "Columns",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Columns",
                columns: new[] { "ID", "Name" },
                values: new object[] { 3, "Done" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Columns",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Columns",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Columns",
                keyColumn: "ID",
                keyValue: 3);

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
        }
    }
}
