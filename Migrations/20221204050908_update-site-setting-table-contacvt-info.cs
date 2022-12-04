using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtTop.Migrations
{
    public partial class updatesitesettingtablecontacvtinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactArabicTitle",
                table: "SiteSetting",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ContactDescArabic",
                table: "SiteSetting",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ContactDescEnglish",
                table: "SiteSetting",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ContactEnglishTitle",
                table: "SiteSetting",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "VisionIcon",
                table: "About",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "MissionIcon",
                table: "About",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactArabicTitle",
                table: "SiteSetting");

            migrationBuilder.DropColumn(
                name: "ContactDescArabic",
                table: "SiteSetting");

            migrationBuilder.DropColumn(
                name: "ContactDescEnglish",
                table: "SiteSetting");

            migrationBuilder.DropColumn(
                name: "ContactEnglishTitle",
                table: "SiteSetting");

            migrationBuilder.UpdateData(
                table: "About",
                keyColumn: "VisionIcon",
                keyValue: null,
                column: "VisionIcon",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "VisionIcon",
                table: "About",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "About",
                keyColumn: "MissionIcon",
                keyValue: null,
                column: "MissionIcon",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "MissionIcon",
                table: "About",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
