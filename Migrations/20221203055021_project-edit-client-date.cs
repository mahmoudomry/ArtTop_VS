using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtTop.Migrations
{
    public partial class projecteditclientdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HeaderLogo",
                table: "SiteSetting",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FeatureImg2",
                table: "SiteSetting",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "FeatureImg1",
                table: "SiteSetting",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Project",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ClientLogo",
                table: "Project",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Project",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ClientLogo",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Project");

            migrationBuilder.UpdateData(
                table: "SiteSetting",
                keyColumn: "HeaderLogo",
                keyValue: null,
                column: "HeaderLogo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "HeaderLogo",
                table: "SiteSetting",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SiteSetting",
                keyColumn: "FeatureImg2",
                keyValue: null,
                column: "FeatureImg2",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FeatureImg2",
                table: "SiteSetting",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "SiteSetting",
                keyColumn: "FeatureImg1",
                keyValue: null,
                column: "FeatureImg1",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "FeatureImg1",
                table: "SiteSetting",
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
