using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Data.Migrations
{
    public partial class FirstMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rsvps_Rsvps_RsvpId1",
                table: "Rsvps");

            migrationBuilder.DropIndex(
                name: "IX_Rsvps_RsvpId1",
                table: "Rsvps");

            migrationBuilder.DropColumn(
                name: "RsvpId1",
                table: "Rsvps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RsvpId1",
                table: "Rsvps",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rsvps_RsvpId1",
                table: "Rsvps",
                column: "RsvpId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Rsvps_Rsvps_RsvpId1",
                table: "Rsvps",
                column: "RsvpId1",
                principalTable: "Rsvps",
                principalColumn: "RsvpId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
