using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Migrations
{
    public partial class precommit22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_weddings_users",
                table: "weddings");

            migrationBuilder.DropIndex(
                name: "fk_rsvps_weddings1_idx",
                table: "rsvps");

            migrationBuilder.RenameIndex(
                name: "fk_rsvps_users1_idx",
                table: "rsvps",
                newName: "IX_rsvps_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_rsvps_wedding_id",
                table: "rsvps",
                column: "wedding_id");

            migrationBuilder.AddForeignKey(
                name: "FK_weddings_users_user_id",
                table: "weddings",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_weddings_users_user_id",
                table: "weddings");

            migrationBuilder.DropIndex(
                name: "IX_rsvps_wedding_id",
                table: "rsvps");

            migrationBuilder.RenameIndex(
                name: "IX_rsvps_user_id",
                table: "rsvps",
                newName: "fk_rsvps_users1_idx");

            migrationBuilder.CreateIndex(
                name: "fk_rsvps_weddings1_idx",
                table: "rsvps",
                columns: new[] { "wedding_id", "user_id" });

            migrationBuilder.AddForeignKey(
                name: "fk_weddings_users",
                table: "weddings",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
