using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeddingPlanner.Migrations
{
    public partial class precommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    email = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    first_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    last_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "weddings",
                columns: table => new
                {
                    wedding_id = table.Column<int>(type: "int(11)", nullable: false),
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    bride_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    groom_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    GuestUserId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weddings", x => new { x.wedding_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_weddings_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_weddings_users_GuestUserId",
                        column: x => x.GuestUserId,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rsvps",
                columns: table => new
                {
                    rsvp_id = table.Column<int>(type: "int(11)", nullable: false),
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    wedding_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rsvps", x => new { x.rsvp_id, x.user_id, x.wedding_id });
                    table.ForeignKey(
                        name: "FK_rsvps_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_rsvps_weddings1",
                        columns: x => new { x.wedding_id, x.user_id },
                        principalTable: "weddings",
                        principalColumns: new[] { "wedding_id", "user_id" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fk_rsvps_users1_idx",
                table: "rsvps",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "fk_rsvps_weddings1_idx",
                table: "rsvps",
                columns: new[] { "wedding_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "fk_weddings_users_idx",
                table: "weddings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_weddings_GuestUserId",
                table: "weddings",
                column: "GuestUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rsvps");

            migrationBuilder.DropTable(
                name: "weddings");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
