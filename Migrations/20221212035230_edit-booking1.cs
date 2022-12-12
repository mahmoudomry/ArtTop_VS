﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtTop.Migrations
{
    public partial class editbooking1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Doctor_DoctorId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Office_OfficeId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_DoctorId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_OfficeId",
                table: "Booking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Booking_DoctorId",
                table: "Booking",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_OfficeId",
                table: "Booking",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Doctor_DoctorId",
                table: "Booking",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Office_OfficeId",
                table: "Booking",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "Id");
        }
    }
}
