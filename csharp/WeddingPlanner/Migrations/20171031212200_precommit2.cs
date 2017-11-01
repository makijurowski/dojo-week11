using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Migrations
{
    public partial class precommit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_rsvps_weddings1",
                table: "rsvps");

            migrationBuilder.DropForeignKey(
                name: "FK_weddings_users_GuestUserId",
                table: "weddings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_weddings",
                table: "weddings");

            migrationBuilder.DropIndex(
                name: "IX_weddings_GuestUserId",
                table: "weddings");

            migrationBuilder.DropColumn(
                name: "GuestUserId",
                table: "weddings");

            migrationBuilder.RenameIndex(
                name: "fk_weddings_users_idx",
                table: "weddings",
                newName: "IX_weddings_user_id");

            migrationBuilder.AlterColumn<int>(
                name: "wedding_id",
                table: "weddings",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_weddings",
                table: "weddings",
                column: "wedding_id");

            migrationBuilder.AddForeignKey(
                name: "FK_rsvps_weddings_wedding_id",
                table: "rsvps",
                column: "wedding_id",
                principalTable: "weddings",
                principalColumn: "wedding_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rsvps_weddings_wedding_id",
                table: "rsvps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_weddings",
                table: "weddings");

            migrationBuilder.RenameIndex(
                name: "IX_weddings_user_id",
                table: "weddings",
                newName: "fk_weddings_users_idx");

            migrationBuilder.AlterColumn<int>(
                name: "wedding_id",
                table: "weddings",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "GuestUserId",
                table: "weddings",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_weddings",
                table: "weddings",
                columns: new[] { "wedding_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_weddings_GuestUserId",
                table: "weddings",
                column: "GuestUserId");

            migrationBuilder.AddForeignKey(
                name: "fk_rsvps_weddings1",
                table: "rsvps",
                columns: new[] { "wedding_id", "user_id" },
                principalTable: "weddings",
                principalColumns: new[] { "wedding_id", "user_id" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_weddings_users_GuestUserId",
                table: "weddings",
                column: "GuestUserId",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
