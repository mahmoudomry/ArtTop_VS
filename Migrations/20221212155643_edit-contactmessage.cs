using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtTop.Migrations
{
    public partial class editcontactmessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted_at",
                table: "ContactMessages",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "ContactMessages",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inserted_at",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "ContactMessages");
        }
    }
}
