using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtTop.Migrations
{
    public partial class editofficeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubServices_Office_OfficeId",
                table: "SubServices");

            migrationBuilder.DropIndex(
                name: "IX_SubServices_OfficeId",
                table: "SubServices");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "SubServices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "SubServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubServices_OfficeId",
                table: "SubServices",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubServices_Office_OfficeId",
                table: "SubServices",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "Id");
        }
    }
}
