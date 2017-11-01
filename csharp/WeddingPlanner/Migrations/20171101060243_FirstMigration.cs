using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RsvpsRsvpId",
                table: "weddings",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpsUserId",
                table: "weddings",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpsWeddingId",
                table: "weddings",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpsRsvpId",
                table: "users",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpsUserId",
                table: "users",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpsWeddingId",
                table: "users",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpId1",
                table: "rsvps",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpUserId",
                table: "rsvps",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpWeddingId",
                table: "rsvps",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_weddings_RsvpsRsvpId_RsvpsUserId_RsvpsWeddingId",
                table: "weddings",
                columns: new[] { "RsvpsRsvpId", "RsvpsUserId", "RsvpsWeddingId" });

            migrationBuilder.CreateIndex(
                name: "IX_users_RsvpsRsvpId_RsvpsUserId_RsvpsWeddingId",
                table: "users",
                columns: new[] { "RsvpsRsvpId", "RsvpsUserId", "RsvpsWeddingId" });

            migrationBuilder.CreateIndex(
                name: "IX_rsvps_RsvpId1_RsvpUserId_RsvpWeddingId",
                table: "rsvps",
                columns: new[] { "RsvpId1", "RsvpUserId", "RsvpWeddingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_rsvps_rsvps_RsvpId1_RsvpUserId_RsvpWeddingId",
                table: "rsvps",
                columns: new[] { "RsvpId1", "RsvpUserId", "RsvpWeddingId" },
                principalTable: "rsvps",
                principalColumns: new[] { "rsvp_id", "user_id", "wedding_id" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_rsvps_RsvpsRsvpId_RsvpsUserId_RsvpsWeddingId",
                table: "users",
                columns: new[] { "RsvpsRsvpId", "RsvpsUserId", "RsvpsWeddingId" },
                principalTable: "rsvps",
                principalColumns: new[] { "rsvp_id", "user_id", "wedding_id" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_weddings_rsvps_RsvpsRsvpId_RsvpsUserId_RsvpsWeddingId",
                table: "weddings",
                columns: new[] { "RsvpsRsvpId", "RsvpsUserId", "RsvpsWeddingId" },
                principalTable: "rsvps",
                principalColumns: new[] { "rsvp_id", "user_id", "wedding_id" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rsvps_rsvps_RsvpId1_RsvpUserId_RsvpWeddingId",
                table: "rsvps");

            migrationBuilder.DropForeignKey(
                name: "FK_users_rsvps_RsvpsRsvpId_RsvpsUserId_RsvpsWeddingId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_weddings_rsvps_RsvpsRsvpId_RsvpsUserId_RsvpsWeddingId",
                table: "weddings");

            migrationBuilder.DropIndex(
                name: "IX_weddings_RsvpsRsvpId_RsvpsUserId_RsvpsWeddingId",
                table: "weddings");

            migrationBuilder.DropIndex(
                name: "IX_users_RsvpsRsvpId_RsvpsUserId_RsvpsWeddingId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_rsvps_RsvpId1_RsvpUserId_RsvpWeddingId",
                table: "rsvps");

            migrationBuilder.DropColumn(
                name: "RsvpsRsvpId",
                table: "weddings");

            migrationBuilder.DropColumn(
                name: "RsvpsUserId",
                table: "weddings");

            migrationBuilder.DropColumn(
                name: "RsvpsWeddingId",
                table: "weddings");

            migrationBuilder.DropColumn(
                name: "RsvpsRsvpId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RsvpsUserId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RsvpsWeddingId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RsvpId1",
                table: "rsvps");

            migrationBuilder.DropColumn(
                name: "RsvpUserId",
                table: "rsvps");

            migrationBuilder.DropColumn(
                name: "RsvpWeddingId",
                table: "rsvps");
        }
    }
}
