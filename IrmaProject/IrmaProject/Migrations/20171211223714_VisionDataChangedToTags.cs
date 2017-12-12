using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IrmaProject.Migrations
{
    public partial class VisionDataChangedToTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisionData",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "VisionData",
                table: "Images",
                nullable: true);
        }
    }
}
