using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IrmaProject.Migrations
{
    public partial class AccountEntityModifiedToGoogle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookUserId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "SocialUserId",
                table: "Account",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialUserId",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "FacebookUserId",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Account",
                nullable: true);
        }
    }
}
