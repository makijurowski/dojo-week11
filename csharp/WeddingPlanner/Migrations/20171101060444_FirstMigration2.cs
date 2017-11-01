using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Migrations
{
    public partial class FirstMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RsvpsRsvpId",
                table: "weddings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpsUserId",
                table: "weddings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpsWeddingId",
                table: "weddings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpsRsvpId",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpsUserId",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RsvpsWeddingId",
                table: "users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_weddings_RsvpsRsvpId_RsvpsUserId_RsvpsWeddingId",
                table: "weddings",
                columns: new[] { "RsvpsRsvpId", "RsvpsUserId", "RsvpsWeddingId" });

            migrationBuilder.CreateIndex(
                name: "IX_users_RsvpsRsvpId_RsvpsUserId_RsvpsWeddingId",
                table: "users",
                columns: new[] { "RsvpsRsvpId", "RsvpsUserId", "RsvpsWeddingId" });

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
    }
}
