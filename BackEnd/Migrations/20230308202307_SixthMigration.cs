using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopSecretProject.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PunchType",
                table: "TimePunches");

            migrationBuilder.RenameColumn(
                name: "PunchTime",
                table: "TimePunches",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TimePunches",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PunchIn",
                table: "TimePunches",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PunchOut",
                table: "TimePunches",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TimePunches");

            migrationBuilder.DropColumn(
                name: "PunchIn",
                table: "TimePunches");

            migrationBuilder.DropColumn(
                name: "PunchOut",
                table: "TimePunches");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "TimePunches",
                newName: "PunchTime");

            migrationBuilder.AddColumn<bool>(
                name: "PunchType",
                table: "TimePunches",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
