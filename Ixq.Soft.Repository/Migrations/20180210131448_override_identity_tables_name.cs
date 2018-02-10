using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ixq.Soft.Repository.Migrations
{
    public partial class override_identity_tables_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "Base_ApplicationUserToken");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Base_ApplicationUser");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "Base_ApplicationUserRole");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "Base_ApplicationUserLogin");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "Base_ApplicationUserClaim");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Base_ApplicationRole");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "Base_ApplicationRoleClaim");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "Base_ApplicationUserRole",
                newName: "IX_Base_ApplicationUserRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "Base_ApplicationUserLogin",
                newName: "IX_Base_ApplicationUserLogin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "Base_ApplicationUserClaim",
                newName: "IX_Base_ApplicationUserClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "Base_ApplicationRoleClaim",
                newName: "IX_Base_ApplicationRoleClaim_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Base_ApplicationUserToken",
                table: "Base_ApplicationUserToken",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Base_ApplicationUser",
                table: "Base_ApplicationUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Base_ApplicationUserRole",
                table: "Base_ApplicationUserRole",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Base_ApplicationUserLogin",
                table: "Base_ApplicationUserLogin",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Base_ApplicationUserClaim",
                table: "Base_ApplicationUserClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Base_ApplicationRole",
                table: "Base_ApplicationRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Base_ApplicationRoleClaim",
                table: "Base_ApplicationRoleClaim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Base_ApplicationRoleClaim_Base_ApplicationRole_RoleId",
                table: "Base_ApplicationRoleClaim",
                column: "RoleId",
                principalTable: "Base_ApplicationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Base_ApplicationUserClaim_Base_ApplicationUser_UserId",
                table: "Base_ApplicationUserClaim",
                column: "UserId",
                principalTable: "Base_ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Base_ApplicationUserLogin_Base_ApplicationUser_UserId",
                table: "Base_ApplicationUserLogin",
                column: "UserId",
                principalTable: "Base_ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Base_ApplicationUserRole_Base_ApplicationRole_RoleId",
                table: "Base_ApplicationUserRole",
                column: "RoleId",
                principalTable: "Base_ApplicationRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Base_ApplicationUserRole_Base_ApplicationUser_UserId",
                table: "Base_ApplicationUserRole",
                column: "UserId",
                principalTable: "Base_ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Base_ApplicationUserToken_Base_ApplicationUser_UserId",
                table: "Base_ApplicationUserToken",
                column: "UserId",
                principalTable: "Base_ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Base_ApplicationRoleClaim_Base_ApplicationRole_RoleId",
                table: "Base_ApplicationRoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_Base_ApplicationUserClaim_Base_ApplicationUser_UserId",
                table: "Base_ApplicationUserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_Base_ApplicationUserLogin_Base_ApplicationUser_UserId",
                table: "Base_ApplicationUserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_Base_ApplicationUserRole_Base_ApplicationRole_RoleId",
                table: "Base_ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Base_ApplicationUserRole_Base_ApplicationUser_UserId",
                table: "Base_ApplicationUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Base_ApplicationUserToken_Base_ApplicationUser_UserId",
                table: "Base_ApplicationUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Base_ApplicationUserToken",
                table: "Base_ApplicationUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Base_ApplicationUserRole",
                table: "Base_ApplicationUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Base_ApplicationUserLogin",
                table: "Base_ApplicationUserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Base_ApplicationUserClaim",
                table: "Base_ApplicationUserClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Base_ApplicationUser",
                table: "Base_ApplicationUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Base_ApplicationRoleClaim",
                table: "Base_ApplicationRoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Base_ApplicationRole",
                table: "Base_ApplicationRole");

            migrationBuilder.RenameTable(
                name: "Base_ApplicationUserToken",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "Base_ApplicationUserRole",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "Base_ApplicationUserLogin",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "Base_ApplicationUserClaim",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "Base_ApplicationUser",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Base_ApplicationRoleClaim",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "Base_ApplicationRole",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_Base_ApplicationUserRole_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Base_ApplicationUserLogin_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Base_ApplicationUserClaim_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Base_ApplicationRoleClaim_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
