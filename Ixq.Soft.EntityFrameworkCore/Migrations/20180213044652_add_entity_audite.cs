using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ixq.Soft.EntityFrameworkCore.Migrations
{
    public partial class add_entity_audite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Base_ApplicationUser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreationUserId",
                table: "Base_ApplicationUser",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "Base_ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteUserId",
                table: "Base_ApplicationUser",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Base_ApplicationUser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Base_ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdateUserId",
                table: "Base_ApplicationUser",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Base_ApplicationRole",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreationUserId",
                table: "Base_ApplicationRole",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteTime",
                table: "Base_ApplicationRole",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleteUserId",
                table: "Base_ApplicationRole",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Base_ApplicationRole",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Base_ApplicationRole",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdateUserId",
                table: "Base_ApplicationRole",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Base_ApplicationUser");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Base_ApplicationUser");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "Base_ApplicationUser");

            migrationBuilder.DropColumn(
                name: "DeleteUserId",
                table: "Base_ApplicationUser");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Base_ApplicationUser");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Base_ApplicationUser");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Base_ApplicationUser");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Base_ApplicationRole");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Base_ApplicationRole");

            migrationBuilder.DropColumn(
                name: "DeleteTime",
                table: "Base_ApplicationRole");

            migrationBuilder.DropColumn(
                name: "DeleteUserId",
                table: "Base_ApplicationRole");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Base_ApplicationRole");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Base_ApplicationRole");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Base_ApplicationRole");
        }
    }
}
