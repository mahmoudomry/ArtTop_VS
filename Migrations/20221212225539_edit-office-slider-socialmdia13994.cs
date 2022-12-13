using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtTop.Migrations
{
    public partial class editofficeslidersocialmdia13994 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "OfficeSocialMedias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "OfficeSocialMedias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "OfficeSlider",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "OfficeSlider",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeSocialMedias_DoctorId",
                table: "OfficeSocialMedias",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeSlider_DoctorId",
                table: "OfficeSlider",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeSlider_Doctor_DoctorId",
                table: "OfficeSlider",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeSocialMedias_Doctor_DoctorId",
                table: "OfficeSocialMedias",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficeSlider_Doctor_DoctorId",
                table: "OfficeSlider");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeSocialMedias_Doctor_DoctorId",
                table: "OfficeSocialMedias");

            migrationBuilder.DropIndex(
                name: "IX_OfficeSocialMedias_DoctorId",
                table: "OfficeSocialMedias");

            migrationBuilder.DropIndex(
                name: "IX_OfficeSlider_DoctorId",
                table: "OfficeSlider");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "OfficeSocialMedias");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "OfficeSocialMedias");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "OfficeSlider");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "OfficeSlider");
        }
    }
}
